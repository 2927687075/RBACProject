using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBACProject.Model;
using RBACProject.IService;
using RBACProject.IRepository;

namespace RBACProject.Service
{
    public class UserService : BaseService<UserModel>, IUserService
    {

        public IUserRepository userRepository { get; set; }

        public bool DeleteUser(int id)
        {
            return userRepository.DeleteUser(id);
        }

        public List<UserModel> GetUserListPage(UserModel userModel, PageInfo pageInfo, ref int totalCount)
        {
           return userRepository.GetUserListPage(userModel,pageInfo,ref totalCount);
        }

        public List<RoleModel> GetUserRoleModels(int id)
        {
            return userRepository.GetUserRoleModels(id);
        }
    }
}
