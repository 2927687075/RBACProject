using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Model;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Common;
using RBACProject.IService;
using RBACProject.Service;



namespace RBACProject.Controllers
{
    public class ActionController : Controller
    {
        ActionRepository actionRepository = new ActionRepository();
        UserRepository userRepository = new UserRepository();

        public IActionService actionService;
        public IUserService userService;

        public ActionController(IActionService _actionService,IUserService _userService)
        {
            actionService = _actionService;
            userService = _userService;
        }


        /// <summary>
        /// id 是菜单id，根据菜单Id获取它的所有action的信息
        /// action的数据包括有表内的，也有表外的
        /// </summary>
        /// <param name="id">菜单Id</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            //获取mySession里面的登录者的信息
            //获取当前操作者的角色id
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
            //List<RoleModel> roleModels = userRepository.GetUserRoleModels(operatorModel.UserId);
            List<RoleModel> roleModels = userService.GetUserRoleModels(operatorModel.UserId);
            List<int> roleIds = new List<int>();
            foreach (var roleModel in roleModels)
            {
                roleIds.Add(roleModel.Id);
            }

            var _menuId = id == null ? 0 : id.Value;

            if (id != null)
            {
                //获取表内表外的操作数据
                ViewData["ActionList"] = actionRepository.GetActionList(_menuId, roleIds, PositionEnum.FormInside);
                ViewData["ActionFormRightTop"] = actionRepository.GetActionList(_menuId, roleIds, PositionEnum.FormRightTop);
            }

            return View();
        }

        public ActionResult GetActionList(string ActionName, string status, PageInfo pageInfo)
        {
            ActionModel actionModel = new ActionModel();

            if (!string.IsNullOrEmpty(ActionName))
            {
                actionModel.ActionName = ActionName;
            }
            if (!string.IsNullOrEmpty(status))
            {
                actionModel.Status = Convert.ToInt32(status);
            }

            int totalCount = 0;

            //获取到搜索后的结果
            List<ActionModel> actionModels = actionRepository.GetActionListPage(actionModel, pageInfo, ref totalCount);

            TableResult<ActionModel> tableResult = new TableResult<ActionModel>()
            {
                code = 0,
                count = totalCount,
                data = actionModels

            };

            return Json(tableResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ActionDetail(int id)
        {
            ActionModel actionModel = actionRepository.QuerySingle(it => it.Id == id);

            return View(actionModel);
        }

        public ActionResult EditAction(int id)
        {

            ActionModel actionModel = actionRepository.QuerySingle(it => it.Id == id);

            return View(actionModel);
        }

        public ActionResult EditActionSumbit(ActionModel actionModel)
        {

            actionModel.Status = Convert.ToInt32(Request["Status"]);

            ApiResult<UserModel> apiResult = new ApiResult<UserModel>()
            {
                state = 400,
                msg = "修改失败"

            };

            //把修改人，修改时间，ip这些加上
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
            actionModel.UpdateBy = operatorModel.UserName;
            actionModel.UpdateOn = DateTime.Now;

            if (actionRepository.Update(actionModel))
            {

                apiResult.state = 200;
                apiResult.msg = "修改成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddAction()
        {

            return View();
        }
        public ActionResult AddActionSumbit(ActionModel actionModel)
        {
            ApiResult<ActionModel> apiResult = new ApiResult<ActionModel>()
            {
                state = 400,
                msg = "添加失败"

            };

            //把修改人，修改时间，ip这些加上
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
            actionModel.CreateBy = operatorModel.UserName;
            actionModel.CreateOn = DateTime.Now;
            actionModel.UpdateBy = operatorModel.UserName;
            actionModel.UpdateOn = DateTime.Now;

            var insertOk = actionRepository.Insert(actionModel);
            if (insertOk)
            {
                apiResult.state = 200;
                apiResult.msg = "添加成功";
            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteAction(ActionModel actionModel)
        {
            ApiResult<ActionModel> apiResult = new ApiResult<ActionModel>()
            {
                state = 400,
                msg = "删除失败"
            };

            if (actionRepository.Delete(actionModel))
            {
                apiResult.state = 200;
                apiResult.msg = "删除成功";
            }
            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }



    }
}