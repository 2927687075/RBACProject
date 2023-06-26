using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Common;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Model;
using System.Configuration;
using RBACProject.Common;

namespace RBACProject.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();

        [HttpGet]
        public ActionResult Index()
        {
            //获取配置文件的数据
            ViewBag.CopyRight = ConfigurationManager.AppSettings["CopyRight"];

            try
            {
                var t = Session["mySession"];
                if (t!=null)
                {
                    //获取mySession里面的登录者的信息
                    var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());

                    //怎样把一个model类型的string数据转回model类型
                    //序列化和反序列化
                    //对象=》json=》string
                    OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);
                    ViewBag.Username = operatorModel.UserName;
                    ViewBag.ImgUrl = operatorModel.HeadShot;
                }

            }
            catch (Exception)
            {

                
            }
            
            
            return View();
        }

    }
}