using RBACProject.IRepository;
using RBACProject.Model;
using System.Linq;
using System.Collections.Generic;
using System;

namespace RBACProject.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
       public List<UserModel> GetUserListPage(UserModel userModel,PageInfo pageInfo,ref int totalCount)
        {
            //查询，非null则添加上去

            //获取总数量
            totalCount = SqlSugarHelper.db.Queryable<UserModel>()
            .WhereIF(!string.IsNullOrEmpty(userModel.UserName), it => it.UserName.Contains(userModel.UserName))
            .WhereIF((userModel.Status != null), it => it.Status == userModel.Status)
            .WhereIF((userModel.DeptId != null), it => it.DeptId == userModel.DeptId)
            .ToList().Count();

            //进行分页
            List<UserModel> userModels = SqlSugarHelper.db.Queryable<UserModel>()
            .WhereIF(!string.IsNullOrEmpty(userModel.UserName), it => it.UserName.Contains(userModel.UserName))
            .WhereIF((userModel.Status != null), it => it.Status == userModel.Status)
            .WhereIF((userModel.DeptId != null), it => it.DeptId == userModel.DeptId)
            .ToPageList(pageInfo.page, pageInfo.limit,ref totalCount);

            return userModels;


        }

        public bool DeleteUser(int id)
        {
            try
            {
                //开启事务
                SqlSugarHelper.db.Ado.BeginTran();
                SqlSugarHelper.db.Deleteable<UserRoleModel>().Where(it => it.UserId == id).ExecuteCommand();
                SqlSugarHelper.db.Deleteable<UserModel>().Where(it => it.Id == id).ExecuteCommand();
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

        public List<RoleModel> GetUserRoleModels(int id)
        {
            List<RoleModel> roleModels = SqlSugarHelper.db.Queryable<UserModel>()
         .InnerJoin<UserRoleModel>((u, ur) => u.Id == ur.UserId)//多个条件用&&
         .InnerJoin<RoleModel>((u, ur, r) => ur.RoleId == r.Id)
         .Where((u, ur, r) => u.Id == id)
         .Select((u, ur, r) => r)
         .ToList();

            return roleModels;
        }




    }
}
