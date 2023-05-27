using RightControl.Model;

namespace RightControl.IRepository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        /// <summary>
        /// 获取个人详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserModel GetDetail(int Id);
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserModel CheckLogin(string username, string password);
        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int ModifyPwd(PassWordModel model);
    }
}
