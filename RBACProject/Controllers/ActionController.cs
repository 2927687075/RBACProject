using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Model;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Common;



namespace RBACProject.Controllers
{
    [AllowAnonymous]
    public class ActionController : Controller
    {
        ActionRepository actionRepository = new ActionRepository();


        /// <summary>
        /// id 是菜单id，根据菜单Id获取它的所有action的信息
        /// action的数据包括有表内的，也有表外的
        /// </summary>
        /// <param name="id">菜单Id</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            var _menuId = id == null ? 0 : id.Value;
            var _roleId = 4;//当前操作人员的id，后期换成session里面user的角色Id
            if (id != null)
            {
                //获取表内表外的操作数据
                ViewData["ActionList"] = actionRepository.GetActionList(_menuId, _roleId, PositionEnum.FormInside);
                ViewData["ActionFormRightTop"] = actionRepository.GetActionList(_menuId, _roleId, PositionEnum.FormRightTop);
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

            actionModel.UpdateBy = "session里面的user";
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

            actionModel.CreateBy = "当前操作者，session里面的user";
            actionModel.CreateOn = DateTime.Now;
            actionModel.UpdateBy = "当前操作者，session里面的user";
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