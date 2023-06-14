using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.Common;

namespace RBACProject.filter
{
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        //public bool Ignore = true;
        //public LoginAuthorizeAttribute(bool ignore = true)
        //{
        //    Ignore = ignore;
        //}

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (Ignore == false)
        //    {
        //        return;
        //    }
        //    if (WebHelper.GetSession("mySeesion") == null)
        //    {
        //        WebHelper.WriteCookie("nfine_login_error", "overdue");
        //        filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
        //        return;
        //    }
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (WebHelper.GetSession("mySeesion") != null)
            {
                // 如果用户已登录，则验证用户是否有相应的授权
                // 允许访问
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // 处理未授权的情况，返回到自定义的错误页面
            WebHelper.WriteCookie("nfine_login_error", "overdue");
            filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
        }



    }
}