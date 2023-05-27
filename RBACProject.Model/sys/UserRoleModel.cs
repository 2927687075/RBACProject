using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_user_role")]
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRoleModel
    {

        [Display(Name = "自增id")]
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "用户id")]
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        [Display(Name = "角色id")]
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }

    }
}