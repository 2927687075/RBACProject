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
    /// �û���ɫ
    /// </summary>
    public class UserRoleModel
    {

        [Display(Name = "����id")]
        /// <summary>
        /// ����id
        /// </summary>
        public int Id { get; set; }

        [Display(Name = "�û�id")]
        /// <summary>
        /// �û�id
        /// </summary>
        public int UserId { get; set; }

        [Display(Name = "��ɫid")]
        /// <summary>
        /// ��ɫid
        /// </summary>
        public int RoleId { get; set; }

    }
}