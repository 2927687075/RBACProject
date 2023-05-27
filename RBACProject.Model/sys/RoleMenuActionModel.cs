using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_role_menu")]
    /// <summary>
    /// 角色菜单权限
    /// </summary>
    public class RoleMenuActionModel
    {

        [Display(Name = "自增id")]
        /// <summary>
        /// 自增id
        /// </summary>
        public int id { get; set; }

        [Display(Name = "菜单ID")]
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }

        [Display(Name = "角色ID")]
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        [Display(Name = "操作ID")]
        /// <summary>
        /// 操作ID
        /// </summary>
        public int ActionId { get; set; }

    }
}