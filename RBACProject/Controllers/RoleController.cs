using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Repository;
using RBACProject.IRepository;
using RBACProject.Model;
using RBACProject.Common;

namespace RBACProject.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        ActionRepository actionRepository = new ActionRepository();
        RoleRepository roleRepository = new RoleRepository();
        UserRoleRepository userRoleRepository = new UserRoleRepository();
        MenuRepository menuRepository = new MenuRepository();


        // GET: Role
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

            return View();
        }

        public ActionResult GetRoleList(string RoleName, string status, PageInfo pageInfo)
        {
            RoleModel roleModel = new RoleModel();

            if (!string.IsNullOrEmpty(RoleName))
            {
                roleModel.RoleName = RoleName;
            }
            if (!string.IsNullOrEmpty(status))
            {
                roleModel.Status = Convert.ToInt32(status);
            }

            int totalCount = 0;

            //获取到搜索后的结果
            List<RoleModel> roleModels = roleRepository.GetRoleListPage(roleModel, pageInfo, ref totalCount);

            TableResult<RoleModel> tableResult = new TableResult<RoleModel>()
            {
                code = 0,
                count = totalCount,
                data = roleModels

            };

            return Json(tableResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RoleDetail(int id)
        {
            RoleModel roleModel = roleRepository.QuerySingle(it => it.Id == id);


            return View(roleModel);
        }

        //
        public ActionResult DeleteRole(RoleModel roleModel)
        {
            ApiResult<RoleModel> apiResult = new ApiResult<RoleModel>()
            {
                state = 400,
                msg = "删除失败"
            };

            if (roleRepository.Delete(roleModel))
            {
                apiResult.state = 200;
                apiResult.msg = "删除成功";
            }
            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditRole(int id)
        {

            RoleModel roleModel = roleRepository.QuerySingle(it => it.Id == id);

            return View(roleModel);
        }

        public ActionResult EditRoleSumbit(RoleModel roleModel)
        {

            roleModel.Status = Convert.ToInt32(Request["Status"]);

            //把修改人，修改时间，ip这些加上

            ApiResult<RoleModel> apiResult = new ApiResult<RoleModel>()
            {
                state = 400,
                msg = "修改失败"

            };

            roleModel.UpdateBy = "session里面的user";
            roleModel.UpdateOn = DateTime.Now;


            if (roleRepository.Update(roleModel))
            {

                apiResult.state = 200;
                apiResult.msg = "修改成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddRole()
        {

            return View();
        }
        public ActionResult AddRoleSumbit(RoleModel roleModel)
        {
            ApiResult<RoleModel> apiResult = new ApiResult<RoleModel>()
            {
                state = 400,
                msg = "添加失败"

            };

            roleModel.Status = Convert.ToInt32(Request["Status"]);
            roleModel.CreateBy = "当前操作者，session里面的user";
            roleModel.CreateOn = DateTime.Now;
            roleModel.UpdateBy = "当前操作者，session里面的user";
            roleModel.UpdateOn = DateTime.Now;

            var insertOk = roleRepository.Insert(roleModel);
            if (insertOk)
            {
                apiResult.state = 200;
                apiResult.msg = "添加成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AssignRole(string Id)
        {
            //operatorModel.UserId
            //取到的用户的角色可能有2个，可能有3个，他们的权限也不一致，怎样获取他们所有的权限信息呢
            //需要进行合并，合并后去重

            //ViewBag.RoleId = 4;//后期取session里面的roleId

            //int userId = 10;//这里到时可以取session数据里面的id
            //List<int> roleIds = userRoleRepository.queryByWhere(it => it.UserId == userId).Select(it => it.RoleId).ToList();

            ViewBag.RoleId = Convert.ToInt32(Id); 

            return View();
        }

        public ActionResult RoleMenuActionList()
        {
            //首先是要获取到所有的菜单和操作信息先

            List<MenuModel> list = roleRepository.GetRoleMenuList(4);
            var result = new { code = 0, count = list.Count(), data = list };
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lists"> 前端传过来的选中的数据 </param>
        /// <param name="roleId"> 要获取前端传过来的选中的角色id--roleId </param>
        /// <returns></returns>
        public ActionResult AssignRoleMenuActionSave(List<RoleMenuActionModel> list, string roleId)
        {


            //后台需要你选中的信息
            //包括菜单、操作

            //怎样获取选中的菜单数据，然后传到后台这里来呢
            //获取input里面的name的值获取菜单数据

            //怎样获取选中的操作数据，然后传到后台这里来呢
            //通过获取input里面的value获取操作数据

            //删除role-menu-action里面，role = roleId的所有数据，然后再插进去新的数据
            //这里要用到事务


            ApiResult<RoleMenuActionModel> apiResult = new ApiResult<RoleMenuActionModel>()
            {
                state = 400,
                msg = "保存失败"
            };

            if (roleRepository.SaveMenuRoleAction(list,Convert.ToInt32(roleId)))
            {
                apiResult.state = 200;
                apiResult.msg = "保存成功";
            }
            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

    }
}