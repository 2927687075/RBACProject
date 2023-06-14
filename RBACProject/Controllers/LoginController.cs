using RBACProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Model;
using RBACProject.IRepository;
using RBACProject.Repository;
using System.Net;

namespace RBACProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserRepository userRepository = new UserRepository();
        LoginInfoRepository loginInfoRepository = new LoginInfoRepository();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAuthCode()
        {

            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");

        }

        public string CheckLogin(string username,string password)
        {
            ApiResult<UserModel> apiResult =  new ApiResult<UserModel>() { 
                state = 404,
                msg = "登录失败",
            };

            LoginInfoModel loginInfo = new LoginInfoModel();

            //记录登录信息
            loginInfo.UserName = username;


            loginInfo.IpAddress = Utils.GetIp();
            loginInfo.LoginLocation = "";
            #region Login.browser
            if (Request.UserAgent.Contains("Chrome"))
            {
                loginInfo.Browser = "Google Chrome";
            }
            else if (Request.UserAgent.Contains("Firefox"))
            {
                loginInfo.Browser = "Mozilla Firefox";
            }
            else if (Request.UserAgent.Contains("Edg"))
            {
                loginInfo.Browser = "Microsoft Edge";
            }
            else
            {
                loginInfo.Browser = "Other Browser";
            }
            #endregion
            #region loginInfo.OS
            if (Environment.OSVersion.VersionString.Contains("Windows NT 10"))
            {
                loginInfo.OS = "Windows 10";
            }
            else if (Environment.OSVersion.VersionString.Contains("Windows NT 11"))
            {
                loginInfo.OS = "Windows 11";
            }
            else if (Environment.OSVersion.VersionString.Contains("Windows NT 7"))
            {
                loginInfo.OS = "Windows 7";
            }
            else
            {
                loginInfo.OS = "Other Windows System";
            } 
            #endregion
            loginInfo.LoginTime = DateTime.Now;

            //验证用户名和密码是否正确
            UserModel userModel = userRepository.QuerySingle(it => it.UserName == username && it.PassWord == password);

            if (userModel != null)
            {
                apiResult.state = 200;
                apiResult.msg = "登录成功";
                apiResult.data = userModel;
                loginInfo.Message = "登录成功";

                //当前操作者的信息
                OperatorModel operatorModel = new OperatorModel();
                operatorModel.UserId = userModel.Id;
                operatorModel.UserName = userModel.UserName;
                operatorModel.RealName = userModel.RealName;
                operatorModel.HeadShot = userModel.HeadShot;
                operatorModel.LoginIPAddress = loginInfo.IpAddress;
                operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                operatorModel.LoginTime = DateTime.Now;
                operatorModel.LoginToken = Guid.NewGuid().ToString();


                //把用户信息写到session里面或者cookie里面
                WebHelper.WriteCookie("myCookie", operatorModel.ToJson());
                WebHelper.WriteSession("mySession", operatorModel.ToJson());

            }
            else
            {
                loginInfo.Message = "登录失败";

            }

            loginInfoRepository.Insert(loginInfo);


            return MyJson.ToJson(apiResult);

        }



    }
}