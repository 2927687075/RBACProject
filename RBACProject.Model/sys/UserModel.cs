using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DapperExtensions;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_user")]
    /// <summary>
    /// 用户
    /// </summary>
    public class UserModel
    {

        [Display(Name = "ID")]
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "用户名")]
        /// <summary>
        /// 用户名（登录）
        /// </summary>
        public string UserName { get; set; }

        [Display(Name = "姓名")]
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }

        [Display(Name = "密码")]
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        [Display(Name = "性别")]
        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Gender { get; set; }

        [Display(Name = "手机")]
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }

        [Display(Name = "邮箱")]
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        [Display(Name = "备注")]
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        [Display(Name = "头像")]
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadShot { get; set; }

        [Display(Name = "状态")]
        /// <summary>
        /// 状态
        /// </summary>
        public Boolean Status { get; set; }

        [Display(Name = "创建时间")]
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

        [Display(Name = "修改时间")]
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateOn { get; set; }

        [Display(Name = "创建者")]
        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateBy { get; set; }

        [Display(Name = "修改者")]
        /// <summary>
        /// 修改者
        /// </summary>
        public int UpdateBy { get; set; }

        [Display(Name = "最后一次登录IP")]
        /// <summary>
        /// 最后一次登录IP
        /// </summary>
        public string LoginIP { get; set; }

        [Display(Name = "最后一次登录时间")]
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LoginDate { get; set; }

    }
}