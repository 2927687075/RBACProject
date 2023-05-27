using System.ComponentModel.DataAnnotations;

namespace RBACProject.Common
{
    /// <summary>
    /// 枚举类型，用来定义表内和表外的
    /// [Display] 用来显示数据
    /// </summary>
    public enum PositionEnum
    {
        /// <summary>
        /// 表内，
        /// </summary>
        [Display(Name = "表内")]
        FormInside = 0,
        /// <summary>
        /// 表外
        /// </summary>
        [Display(Name = "表外")]
        FormRightTop = 1
    }
}
