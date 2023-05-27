using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_menu_action")]
    /// <summary>
    /// 菜单权限
    /// </summary>
    public class MenuActionModel
    {

        [Display(Name = "自增id")]
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "菜单ID")]
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }

        [Display(Name = "操作ID")]
        /// <summary>
        /// 操作ID
        /// </summary>
        public int ActionId { get; set; }

    }
}