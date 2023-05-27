using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DapperExtensions;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_menu")]
    /// <summary>
    /// 菜单
    /// </summary>
    public class MenuModel
    {

        [Display(Name = "ID")]
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "菜单名称")]
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        [Display(Name = "菜单地址")]
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string MenuUrl { get; set; }

        [Display(Name = "菜单图标")]
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; }

        [Display(Name = "排序号")]
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderNo { get; set; }

        [Display(Name = "父菜单")]
        /// <summary>
        /// 父菜单
        /// </summary>
        public int ParentId { get; set; }

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

        [Display(Name = "编辑者")]
        /// <summary>
        /// 编辑者
        /// </summary>
        public int UpdateBy { get; set; }

    }
}