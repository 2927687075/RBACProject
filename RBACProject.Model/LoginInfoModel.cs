using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_loginInfo")]
    /// <summary>
    /// 登录信息
    /// </summary>
    public class LoginInfoModel
    {
        [SugarColumn(IsIgnore = true)]
        [Display(Name = "自增id")]
        /// <summary>
        /// 自增id
        /// </summary>
        public int InfoID { get; set; }

        [Display(Name = "用户名")]
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        [Display(Name = "登录ip")]
        /// <summary>
        /// 登录ip
        /// </summary>
        public string IpAddress { get; set; }

        [Display(Name = "登录位置")]
        /// <summary>
        /// 登录位置
        /// </summary>
        public string LoginLocation { get; set; }

        [Display(Name = "浏览器")]
        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        [Display(Name = "操作系统")]
        /// <summary>
        /// 操作系统
        /// </summary>
        public string OS { get; set; }

        [Display(Name = "登录信息")]
        /// <summary>
        /// 登录信息
        /// </summary>
        public string Message { get; set; }

        [Display(Name = "登录时间")]
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

    }
}