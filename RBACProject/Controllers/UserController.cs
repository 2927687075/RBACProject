using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Common;
using RBACProject.Model;
using Mapster;

namespace RBACProject.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        ActionRepository actionRepository = new ActionRepository();
        UserRepository userRepository = new UserRepository();
        DeptRepository deptRepository = new DeptRepository();
        RoleRepository roleRepository = new RoleRepository();
        UserRoleRepository userRoleRepository = new UserRoleRepository();

        // GET: User
        public ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = 4;
            if (id != null)
            {
                //获取表内表外的操作数据
                ViewData["ActionList"] = actionRepository.GetActionList(_menuId, _roleId, PositionEnum.FormInside);
                ViewData["ActionFormRightTop"] = actionRepository.GetActionList(_menuId, _roleId, PositionEnum.FormRightTop);
            }


            List<DeptResult> deptResults = new List<DeptResult>();

            //获取所有的部门名称
            List<DeptModel> deptModels = deptRepository.queryAll();
            foreach (var deptModel in deptModels)
            {
                DeptResult deptResult = new DeptResult();
                deptResult.Value = deptModel.DeptId;
                deptResult.Text = deptModel.DeptName;

                deptResults.Add(deptResult);
            }

            ViewBag.department = deptResults;

            return View();
        }

        public ActionResult GetUserList(string UserName, string deptId, string status, PageInfo pageInfo) 
        {
            UserModel userModel = new UserModel();

            if (!string.IsNullOrEmpty(UserName))
            {
                userModel.UserName = UserName;
            }
            if (!string.IsNullOrEmpty(deptId))
            {
                userModel.DeptId = Convert.ToInt32(deptId);
            }
            if (!string.IsNullOrEmpty(status))
            {
                userModel.Status = Convert.ToInt32(status);
            }

            int totalCount = 0;

            //获取到搜索后的结果
            List<UserModel> userModels = userRepository.GetUserListPage(userModel,pageInfo,ref totalCount);

            //获取所有的用户信息和部门信息
            //List<UserModel> users = userRepository.queryAll();
            List<DeptModel> depts = deptRepository.queryAll();

            //对象赋值，使用Mapster进行对象的赋值
            List<UserModelResult> userModelResults = userModels.Adapt<List<UserModelResult>>();

            //如果userModelResult.DeptId 和 dept.DeptId 匹配得上，就将dept的Name赋值给userModelResult
            foreach (var userModelResult in userModelResults)
            {
                foreach (var dept in depts)
                {
                    if (userModelResult.DeptId == dept.DeptId)
                    {
                        userModelResult.deptName = dept.DeptName;
                    }
                }
            }

            TableResult<UserModelResult> tableResult = new TableResult<UserModelResult>()
            {
                code = 0,
                count = totalCount,
                data = userModelResults

            };

            return Json(tableResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserDetail(int id)
        {
            UserModel userModel = userRepository.QuerySingle(it => it.Id == id);
            DeptModel deptModel = deptRepository.QuerySingle(it => it.DeptId == userModel.DeptId);


            //对象赋值，使用Mapster进行对象的赋值
            UserModelResult userModelResult = userModel.Adapt<UserModelResult>();
            userModelResult.deptName = deptModel.DeptName;
            

            return View(userModelResult);
        }

        public ActionResult InitPwd(int Id)
        {
            ApiResult<UserModel> apiResult = new ApiResult<UserModel>();

            var initPwd = Md5.md5(Configs.GetValue("InitUserPwd"), 32);

            UserModel userModel = userRepository.QuerySingle(it => it.Id == Id);
            userModel.PassWord = initPwd;

            if (userRepository.Update(userModel))
            {
                apiResult.state = 200;
                apiResult.msg = "重置成功";

            }
            else
            {
                apiResult.state = 400;
                apiResult.msg = "重置失败";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUser(int Id)
        {
            ApiResult<UserModel> apiResult = new ApiResult<UserModel>()
            {
                state = 400,
                msg = "删除失败"
            };

            if (userRepository.DeleteUser(Id))
            {
                apiResult.state = 200;
                apiResult.msg = "删除成功";
            }
            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditUser(int id)
        {
          
            UserModel userModel = userRepository.QuerySingle(it => it.Id == id);
            DeptModel deptModel = deptRepository.QuerySingle(it => it.DeptId == userModel.DeptId);

            //对象赋值，使用Mapster进行对象的赋值
            UserModelResult userModelResult = userModel.Adapt<UserModelResult>();
            userModelResult.deptName = deptModel.DeptName;

            List<DeptResult> deptResults = new List<DeptResult>();

            //获取所有的部门名称
            List<DeptModel> deptModels = deptRepository.queryAll();
            foreach (var item in deptModels)
            {
                DeptResult deptResult = new DeptResult();
                deptResult.Value = item.DeptId;
                deptResult.Text = item.DeptName;

                deptResults.Add(deptResult);
            }

            ViewBag.department = deptResults;

            List<RoleModel> allRoleModels = roleRepository.queryAll();
            List<RoleModel> userRoleModels = userRepository.GetUserRoleModels(id);
            ViewData["allRoleModels"] = allRoleModels;
            ViewData["userRoleModels"] = userRoleModels;

            return View(userModelResult);
        }

        public ActionResult EditUserSumbit(UserModel userModel)
        {

            userModel.DeptId = Convert.ToInt32(Request["department"]);
            userModel.Status = Convert.ToInt32(Request["Status"]);

            //获取用户所拥有的角色Id，从request参数里面获取，name的值不为空则选中
            List<int> roleIds = new List<int>();
            List<RoleModel> roleModels = roleRepository.queryAll();
            foreach (var roleModel in roleModels)
            {
                string roleId = Request[roleModel.RoleName];
                if (!string.IsNullOrEmpty(roleId))
                {
                    roleIds.Add(Convert.ToInt32(roleId));
                }
            }

            //先把改用户原来的角色信息先删除
            //如果用户角色表中没数据，删除就会出错，这里要进行判断一下
            var isDeleteOk = true;
            if (userRoleRepository.queryByWhere(it => it.UserId == userModel.Id).Count() > 0)
            {
                isDeleteOk = userRoleRepository.DeleteByWhere(it => it.UserId == userModel.Id);
            }

            
            if (isDeleteOk)
            {
                foreach (var item in roleIds)
                {
                    UserRoleModel userRoleModel = new UserRoleModel()
                    {
                        UserId = userModel.Id,
                        RoleId = item
                    };
                    //插入新加的角色信息
                    userRoleRepository.Insert(userRoleModel);
                }
                
            }
           
            //把修改人，修改时间，ip这些加上

            ApiResult<UserModel> apiResult = new ApiResult<UserModel>()
            {
                state = 400,
                msg = "修改失败"

            };

            userModel.UpdateBy = userModel.UserName;
            userModel.UpdateOn = DateTime.Now;

            if (userRepository.Update(userModel))
            {

                apiResult.state = 200;
                apiResult.msg = "修改成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddUser()
        {

            List<DeptResult> deptResults = new List<DeptResult>();

            //获取所有的部门名称
            List<DeptModel> deptModels = deptRepository.queryAll();
            foreach (var item in deptModels)
            {
                DeptResult deptResult = new DeptResult();
                deptResult.Value = item.DeptId;
                deptResult.Text = item.DeptName;

                deptResults.Add(deptResult);
            }

            ViewBag.department = deptResults;

            //获取角色信息
            List<RoleModel> allRoleModels = roleRepository.queryAll();
            ViewData["allRoleModels"] = allRoleModels;

            return View();
        }
        public ActionResult AddUserSumbit(UserModel userModel)
        {
            ApiResult<UserModel> apiResult = new ApiResult<UserModel>() { 
                state = 400,
                msg = "添加失败"
            
            };

            userModel.DeptId = Convert.ToInt32(Request["department"]);
            userModel.Status = Convert.ToInt32(Request["Status"]);
            userModel.CreateBy = "当前操作者，session里面的user";
            userModel.CreateOn = DateTime.Now;
            userModel.UpdateBy = "当前操作者，session里面的user";
            userModel.UpdateOn = DateTime.Now;

            var insertOk = userRepository.Insert(userModel);
            if (insertOk)
            {
                apiResult.state = 200;
                apiResult.msg = "添加成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserInfo()
        {
            //session里面获取userId
            int userId = 10;

            UserModel userModel = userRepository.QuerySingle(it => it.Id == userId);

            return View(userModel);
        }

        [HttpPost]
        public ActionResult GetUserInfo(UserModel userModel)
        {
            ApiResult<UserModel> apiResult = new ApiResult<UserModel>()
            {
                state = 400,
                msg = "修改失败"

            };

            userModel.UpdateBy = "当前操作者，session里面的user";
            userModel.UpdateOn = DateTime.Now;

            var insertOk = userRepository.Update(userModel);
            if (insertOk)
            {
                apiResult.state = 200;
                apiResult.msg = "修改成功";
            }

            return View(userModel);
        }


        public ActionResult UpdatePwd()
        {
            //获取当前session的userId
            int userId = 10;

            UserModel userModel = userRepository.QuerySingle(it => it.Id == userId);
            

            return View(userModel);
        }

        [HttpPost]
        public ActionResult UpdatePwd(UserModel userModel)
        {
            string oldPwd = Request["OldPassword"];
            string newPassword = Request["Password"];
            string rePassword = Request["Repassword"];

            if (newPassword != rePassword)
            {
                //两次密码输入不一致

                
            }


            //获取当前session的userId
            int userId = 10;

            UserModel user = userRepository.QuerySingle(it => it.Id == userId);
            if (user.PassWord==Md5.md5(oldPwd,32))
            {
                user.PassWord = Md5.md5(newPassword, 32);
                user.UpdateBy = "当前操作者，session里面的user";
                user.UpdateOn = DateTime.Now;

                var insertOk = userRepository.Update(user);
            }

            return View(user);
        }



        
    }
}