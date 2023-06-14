using RBACProject.IRepository;
using RBACProject.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RBACProject.Repository
{
    public class RoleRepository : BaseRepository<RoleModel>, IRoleRepository
    {
        public List<RoleModel> GetRoleListPage(RoleModel roleModel, PageInfo pageInfo, ref int totalCount)
        {
            //查询，非null则添加上去

            //进行分页
            List<RoleModel> roleModels = SqlSugarHelper.db.Queryable<RoleModel>()
            .WhereIF(!string.IsNullOrEmpty(roleModel.RoleName), it => it.RoleName.Contains(roleModel.RoleName))
            .WhereIF((roleModel.Status != null), it => it.Status == roleModel.Status)
            .ToPageList(pageInfo.page, pageInfo.limit, ref totalCount);

            return roleModels;

        }


        //获取菜单-操作权限
        public List<MenuModel> GetRoleMenuList(int roleId)
        {
            //获取所有的菜单
            List<MenuModel> menuModels = SqlSugarHelper.db.Queryable<MenuModel>().ToList();

            //获取角色拥有的菜单
            List<MenuModel> menus = SqlSugarHelper.db.Queryable<MenuModel>()
        .InnerJoin<RoleMenuActionModel>((m, rma) => m.Id == rma.MenuId)
        .Where((m, rma) => rma.RoleId == roleId)
        .Select((m, rma) => m)
        .ToList();

            foreach (var menuModel in menuModels)
            {
                //根据菜单和角色id，获取每一个菜单对应的操作数据
                //返回什么样的数据呢

                //菜单一有4个操作按钮，菜单二有3个操作按钮，菜单三有五个操作按钮
                //这个表在menu-action表中，
                //应该根据menuId去获取它对应的action信息，然后再把对应的action显示在页面上

                List<ActionModel> actionModels = SqlSugarHelper.db.Queryable<ActionModel>()
            .InnerJoin<MenuActionModel>((a, ma) => a.Id == ma.ActionId)//多个条件用&&
            .InnerJoin<MenuModel>((a, ma, m) => ma.MenuId == m.Id)
            .Where((a, ma, m) => m.Id == menuModel.Id)
            .Select((a, ma, m) => a)
            .ToList();

                //怎样进行菜单和操作权限的选中呢？
                //选中的菜单和操作权限在 角色-菜单-操作 表中

                //菜单
                //选中的菜单--根据角色Id获取所有的菜单，将菜单和全部的菜单进行对比
                //对比得上，就设置为isChecked为True
                foreach (var menu in menus)
                {
                    if (menuModel.Id == menu.Id)
                    {
                        menuModel.IsChecked = true;
                    }
                }

                //操作
                //获取角色拥有的菜单-操作权限
                List<ActionModel> actions = SqlSugarHelper.db.Queryable<ActionModel>()
            .InnerJoin<RoleMenuActionModel>((a, rma) => a.Id == rma.ActionId)
            .Where((a, rma) => rma.RoleId == roleId && rma.MenuId == menuModel.Id)
            .Select((a, rma) => a)
            .ToList();

                StringBuilder sb = new StringBuilder();
                foreach (var actionModel in actionModels)
                {
                    //执行标记
                    bool hasExecute = true;

                    //< input name = 'cbx_2' lay - skin = 'primary' value = '1' title = '添加' type = 'checkbox' checked= '' >

                    //那你怎么知道action他是不是选中
                    //去数据库里面查--上面查到了

                    //actionModel 1 2 3 4 5
                    //action  2 3

                    //1 和 2 3 进行对比，对比得上
                    foreach (var action in actions)
                    {
                        if (action.Id == actionModel.Id)
                        {
                            sb.AppendFormat(@"<input name='cbx_{0}' lay-skin='primary' value={1} title={2} type='checkbox' checked >", menuModel.Id,actionModel.Id, actionModel.ActionName);

                            hasExecute = false;

                            //匹配上了就跳出这个循环，不再执行后面的循环
                            break;
                        }

                    }

                    //hasExecute为false说明已经执行过了，不用再执行
                    if (hasExecute)
                    {
                        sb.AppendFormat(@"<input name='cbx_{0}' lay-skin='primary' value={1} title={2} type='checkbox' >",menuModel.Id, actionModel.Id, actionModel.ActionName);
                    }
                    

                    menuModel.MenuActionHtml = sb.ToString();
                }



            }
            
            return menuModels;


        }

        public bool SaveMenuRoleAction(List<RoleMenuActionModel> roleMenuActions,int roleId)
        {
            try
            {
                SqlSugarHelper.db.Ado.BeginTran();

                SqlSugarHelper.db.Deleteable<RoleMenuActionModel>().Where(it => it.RoleId == roleId).ExecuteCommand();
                SqlSugarHelper.db.Insertable<RoleMenuActionModel>(roleMenuActions).IgnoreColumns(it => it.id).ExecuteCommand();
                SqlSugarHelper.db.Ado.CommitTran();

                return true;


            }
            catch (System.Exception ex)
            {
                SqlSugarHelper.db.RollbackTran();

                return false;
            }
        }

    }
}
