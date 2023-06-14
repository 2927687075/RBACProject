using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.ComponentModel.DataAnnotations;

namespace RBACProject.Model
{

    [SugarTable("t_dept")]
    public class DeptModel
    {
        [Display(Name = "部门Id")]
        [SugarColumn(IsPrimaryKey = true)]
        public int DeptId { get; set; }

        [Display(Name = "部门名称")]
        public string DeptName { get; set; }


    }
}
