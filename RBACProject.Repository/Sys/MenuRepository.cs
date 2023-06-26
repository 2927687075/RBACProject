
using RBACProject.IRepository;
using RBACProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace RBACProject.Repository
{
    public class MenuRepository : BaseRepository<MenuModel>, IMenuRepository
    {
        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<MenuTree> GetMenuList(List<int> roleIds, int parentId,bool isSelect)
        {

            List<MenuTree> menuTrees = new List<MenuTree>();
            List<MenuModel> menuModels = GetChildrenMenuList(roleIds, parentId);

            foreach (var item in menuModels)
            {
                //递归
                MenuTree menuTree = new MenuTree();
                menuTree.id = item.Id;
                menuTree.name = item.MenuName;
                menuTree.title = item.MenuName;
                menuTree.icon = item.MenuIcon;
                menuTree.children = GetMenuList(roleIds, item.Id, isSelect);
                menuTree.alias = null;
                menuTree.href = isSelect == false ? item.MenuUrl : null;
                menuTree.spread = false;

                menuTrees.Add(menuTree);

            }

            return menuTrees;

        }

        ///// <summary>
        ///// 获取所有的菜单信息(根据角色Id)
        ///// </summary>
        ///// <param name="roleId"></param>
        ///// <returns></returns>
        //public List<MenuModel> GetAllMenuListByRoleId(int roleId)
        //{
        //    List<MenuModel> menuModels = SqlSugarHelper.db.Queryable<RoleModel>()
        // .InnerJoin<RoleMenuActionModel>((r, rma) => r.Id == rma.RoleId)
        // .InnerJoin<MenuModel>((r, rma, m) => rma.MenuId == m.Id)
        // .Where((r, rma, m) => r.Id == roleId)
        // .Select((r, rma, m) => m)
        // .Distinct()
        // .ToList();
        //    return menuModels;
        //}

        public List<MenuModel> GetAllMenuListByRoleId(List<int> roleIds)
        {
            List<MenuModel> menuModels = SqlSugarHelper.db.Queryable<RoleModel>()
         .InnerJoin<RoleMenuActionModel>((r, rma) => r.Id == rma.RoleId)
         .InnerJoin<MenuModel>((r, rma, m) => rma.MenuId == m.Id)
         .Where((r, rma, m) => roleIds.Contains(r.Id))
         .Select((r, rma, m) => m)
         .Distinct()
         .ToList();
            return menuModels;
        }



        //public List<MenuModel> GetChildrenMenuList(int roleId, int parentId)
        //{
        //    List<MenuModel> menuModels = GetAllMenuListByRoleId(roleId);
        //    List<MenuModel> childrenMenus = menuModels.Where(it => it.ParentId == parentId).ToList();


        //    return childrenMenus;
        //}

        public List<MenuModel> GetChildrenMenuList(List<int> roleIds, int parentId)
        {
            List<MenuModel> menuModels = GetAllMenuListByRoleId(roleIds);
            List<MenuModel> childrenMenus = menuModels.Where(it => it.ParentId == parentId).ToList();


            return childrenMenus;
        }

        public bool DeleteMenu(int menuId)
        {
            try
            {

                //开启事务
                SqlSugarHelper.db.Ado.BeginTran();
                SqlSugarHelper.db.Deleteable<RoleMenuActionModel>().Where(it => it.MenuId == menuId).ExecuteCommand();
                SqlSugarHelper.db.Deleteable<MenuActionModel>().Where(it => it.MenuId == menuId).ExecuteCommand();
                SqlSugarHelper.db.Deleteable<MenuModel>().Where(it => it.Id == menuId).ExecuteCommand();

                //提交事务
                SqlSugarHelper.db.Ado.CommitTran();
                return true;
            }
            catch (Exception)
            {

                //回滚事务
                SqlSugarHelper.db.Ado.RollbackTran();
                return false;
            }

        }

        //public bool UpdateMenu(MenuModel menuModel)
        //{

        //    return SqlSugarHelper.db.Updateable<MenuModel>(menuModel).IgnoreColumns("id").Where(it => it.Id == menuModel.Id).ExecuteCommand() > 0;
        //}

    }
}
