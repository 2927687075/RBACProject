using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_action")]
    /// <summary>
    /// 权限
    /// </summary>
    public class ActionModel
    {

        [Display(Name = "ID")]
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "操作编码")]
        /// <summary>
        /// 操作编码
        /// </summary>
        public string ActionCode { get; set; }

        [Display(Name = "操作名称")]
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName { get; set; }

        [Display(Name = "显示位置")]
        /// <summary>
        /// 显示位置（1：表单内，2：表单右上）
        /// </summary>
        public int Position { get; set; }

        [Display(Name = "样式名称")]
        /// <summary>
        /// 样式名称
        /// </summary>
        public string ClassName { get; set; }

        [Display(Name = "图标")]
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        [Display(Name = "方法名称")]
        /// <summary>
        /// 方法名称
        /// </summary>
        public string Method { get; set; }

        [Display(Name = "说明")]
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }

        [Display(Name = "排序号")]
        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderBy { get; set; }

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

        [Display(Name = "更新时间")]
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateOn { get; set; }

        [Display(Name = "创建者")]
        /// <summary>
        /// 创建者
        /// </summary>
        public int CreateBy { get; set; }

        [Display(Name = "更新者")]
        /// <summary>
        /// 更新者
        /// </summary>
        public int UpdateBy { get; set; }

    }
}