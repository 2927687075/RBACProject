using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_role")]
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleModel
    {

        [Display(Name = "ID")]
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "角色编码")]
        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; }

        [Display(Name = "角色名称")]
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        [Display(Name = "角色描述")]
        /// <summary>
        /// 角色描述
        /// </summary>
        public string Remark { get; set; }

        [Display(Name = "状态")]
        /// <summary>
        /// 状态(1:有效，0：无效)
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

        [Display(Name = "修改者")]
        /// <summary>
        /// 修改者
        /// </summary>
        public int UpdateBy { get; set; }

    }
}