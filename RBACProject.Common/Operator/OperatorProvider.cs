using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Common
{
    /// <summary>
    /// 操作提供者
    /// </summary>
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "loginkey_2023";
        //value的值为Cookie
        private string LoginProvider = Configs.GetValue("LoginProvider");

        [Obsolete]
        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            if (LoginProvider == "Cookie")
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            else
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            return operatorModel;
        }

        [Obsolete]
        public void AddCurrent(OperatorModel operatorModel)
        {
            //如果LoginProvider的值为Cookie，则生成cookie信息，否则生成session信息
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
            }
            WebHelper.WriteCookie("secom_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
            WebHelper.WriteCookie("secom_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
