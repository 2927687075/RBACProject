using RBACProject.Model;
using System.Collections.Generic;

namespace RBACProject.IRepository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        List<UserModel> GetUserListPage(UserModel userModel, PageInfo pageInfo,ref int totalCount);

        bool DeleteUser(int id);
        List<RoleModel> GetUserRoleModels(int id);

    }
}
