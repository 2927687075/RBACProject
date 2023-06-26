using System.Collections.Generic;
using System.Web.Mvc;
using RBACProject.Common;
using RBACProject.Repository;
using RBACProject.Model;

using System;

namespace RBACProject.Controllers
{
    public class PermissionController : Controller
    {
        UserRepository userRepository = new UserRepository();
        MenuRepository menuRepository =  new MenuRepository();
        ActionRepository actionRepository =  new ActionRepository();

        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenuList(bool isIndex = false,bool isSelect = false)
        {
            //获取mySession里面的登录者的信息
            //获取当前操作者的角色id
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
            List<RoleModel> roleModels = userRepository.GetUserRoleModels(operatorModel.UserId);
            List<int> roleIds = new List<int>();
            foreach (var roleModel in roleModels)
            {
                roleIds.Add(roleModel.Id);
            }

            List<MenuTree> menuTrees = menuRepository.GetMenuList(roleIds,0,isSelect);

            //返回菜单json数据
            return Json(menuTrees, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Menu(int? id)
        {
            //获取mySession里面的登录者的信息
            //获取当前操作者的角色id
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
            List<RoleModel> roleModels = userRepository.GetUserRoleModels(operatorModel.UserId);
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

        /// <summary>
        /// 获取所有的菜单，前端根据parentId自行形成树形结构数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public JsonResult GetAllMenu(int page,int limit)
        {

            //4为管理员
            //返回菜单json数据
            List<MenuModel> menuModels = menuRepository.queryAll();
            var result = new { code = 0, count = menuModels.Count, data = menuModels };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuAdd()
        {
            return View();
        }
        public ActionResult MenuAddSubmit(MenuModel model)
        {

            ApiResult<MenuModel> apiResult =  new ApiResult<MenuModel>();

            //获取mySession里面的登录者的信息
            //获取当前操作者的userId
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);

            //把菜单信息添加到数据库里面去
            model.CreateOn = DateTime.Now;
            model.CreateBy = operatorModel.UserName;
            model.UpdateOn = DateTime.Now; 
            model.UpdateBy = operatorModel.UserName;
            bool insertOk =  menuRepository.Insert(model);
            
            if (insertOk)
            {
                apiResult.msg = "添加成功";
                apiResult.state = 200;
                apiResult.data = model;

            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MenuDelete(MenuModel menuModel)
        {
            ApiResult<MenuModel> apiResult = new ApiResult<MenuModel>() { 
                state = 400,
                msg = "删除失败"
            };

            //删除菜单时,同时删除菜单权限,菜单角色权限记录
            var result = menuRepository.DeleteMenu(menuModel.Id);
            if (result)
            {
                apiResult.state = 200;
                apiResult.msg = "删除成功";
            }
            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MenuEdit(int menuId)
        {
            MenuModel menuModel = menuRepository.QuerySingle(it => it.Id == menuId);

            if (menuModel.ParentId != 0)
            {
                MenuModel menuParentModel = menuRepository.QuerySingle(it => it.Id == menuModel.ParentId);
                ViewBag.ParentMenuName = menuParentModel.MenuName;
            }

            return View(menuModel);
        }

        public ActionResult MenuEditSumbit(MenuModel menuModel)
        {
            ApiResult<MenuModel> apiResult = new ApiResult<MenuModel>()
            {
                state = 400,
                msg = "修改失败"

            };

            //获取mySession里面的登录者的信息
            //获取当前操作者的userId
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);

            //修改的时间、修改人
            menuModel.UpdateOn = DateTime.Now;
            menuModel.UpdateBy = operatorModel.UserName;

            var reault = menuRepository.Update(menuModel);
            if (reault)
            {
                apiResult.state = 200;
                apiResult.msg = "修改成功";

            }

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuQuery(int menuId)
        {
            MenuModel menuModel = menuRepository.QuerySingle(it => it.Id == menuId);

            if (menuModel.ParentId != 0)
            {
                MenuModel menuParentModel = menuRepository.QuerySingle(it => it.Id == menuModel.ParentId);
                ViewBag.ParentMenuName = menuParentModel.MenuName;
            }

            return View(menuModel);
        }

        public ActionResult MenuQuerySumbit(MenuModel menuModel)
        {
            ApiResult<MenuModel> apiResult = new ApiResult<MenuModel>()
            {
                state = 200

            };

            return Json(apiResult, JsonRequestBehavior.AllowGet);
        }

    }
}