
using RBACProject.Common;
using RBACProject.IRepository;
using RBACProject.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RBACProject.Repository
{
    public class ActionRepository : BaseRepository<ActionModel>, IActionRepository
    {
       //根据角色id获取它的操作权限
       /// <summary>
       /// 角色-权限表-角色菜单权限表
       /// </summary>
       /// <param name="roleId"></param>
       public List<ActionModel> GetActionList(int menuId,int roleId,PositionEnum outOrIn)
        {
            //表内的权限，表外的权限

            List<ActionModel> actionModels = SqlSugarHelper.db.Queryable<RoleModel>()
         .InnerJoin<RoleMenuActionModel>((r, rma) => r.Id == rma.RoleId)//多个条件用&&
         .InnerJoin<ActionModel>((r, rma, a) => rma.ActionId == a.Id)
         .Where((r,rma,a) => rma.MenuId == menuId && r.Id == roleId && a.Position == (int)outOrIn)
         .OrderBy((r, rma, a) => a.Id)
         .Select((r, rma, a) => a)
         .ToList();

            return actionModels;

        }

        public List<ActionModel> GetActionListPage(ActionModel actionModel, PageInfo pageInfo, ref int totalCount)
        {
            //查询，非null则添加上去

            //获取总数量
            totalCount = SqlSugarHelper.db.Queryable<ActionModel>()
            .WhereIF(!string.IsNullOrEmpty(actionModel.ActionName), it => it.ActionName.Contains(actionModel.ActionName))
            .WhereIF((actionModel.Status != null), it => it.Status == actionModel.Status)
            .ToList().Count;

            //进行分页
            List<ActionModel> actionModels = SqlSugarHelper.db.Queryable<ActionModel>()
            .WhereIF(!string.IsNullOrEmpty(actionModel.ActionName), it => it.ActionName.Contains(actionModel.ActionName))
            .WhereIF((actionModel.Status != null), it => it.Status == actionModel.Status)
            .ToPageList(pageInfo.page, pageInfo.limit, ref totalCount);

            return actionModels;


        }

    }
}
