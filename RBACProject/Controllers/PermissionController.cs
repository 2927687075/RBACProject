using System.Collections.Generic;
using System.Web.Mvc;
using RBACProject.Common;
using RBACProject.Repository;
using RBACProject.Model;

using System;

namespace RBACProject.Controllers
{
    [AllowAnonymous]
    public class PermissionController : Controller
    {

        MenuRepository menuRepository =  new MenuRepository();
        ActionRepository actionRepository =  new ActionRepository();

        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMenuList(bool isIndex = false,bool isSelect = false)
        {
            //返回菜单json数据

            List<MenuTree> menuTrees = menuRepository.GetMenuList(4,0,isSelect);
            return Json(menuTrees, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Menu(int? id)
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

            //把菜单信息添加到数据库里面去
            model.CreateOn = DateTime.Now;
            model.CreateBy = "超级管理员";
            model.UpdateOn = DateTime.Now; 
            model.UpdateBy = "超级管理员";
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