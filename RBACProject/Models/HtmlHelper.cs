
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RBACProject.Model;

namespace RBACProject
{
    public static class MyExtHtmlLabel
    {
        // 扩展方法相当于继承一个类

        /// <summary>
        /// 菜单管理权限复选框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="_list"></param>
        /// <returns></returns>
        public static HtmlString ActionCheckBox(this HtmlHelper helper, dynamic _list = null, dynamic _alist = null)
        {
            StringBuilder sb = new StringBuilder();
            var list = _list as List<ActionModel>;
            var alist = _alist as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    bool isSelect = false;
                    foreach (var item in alist)
                    {
                        if (v.ActionCode == item.ActionCode)
                        {
                            isSelect = true;
                        }
                    }
                    sb.AppendFormat(@"<input type='checkbox' lay-skin='primary' name='{0}' title='{1}' value='{2}' {3}>", v.ActionCode, v.ActionName, v.Id, isSelect ? "checked" : "");
                }
            }
            return new HtmlString(sb.ToString());
        }
        public static HtmlString DisplayStatusHtml(this HtmlHelper helper, int? value)
        {
            var msg = value.Value == 1 ? "启用" : "停用";
            return new HtmlString(string.Format("<span>{0}</span>", msg));
        }

        public static HtmlString DisplayGenderHtml(this HtmlHelper helper, int? value)
        {
            var msg = value.Value == 1 ? "男" : "女";
            return new HtmlString(string.Format("<span>{0}</span>", msg));
        }


        public static HtmlString StatusRadioHtml(this HtmlHelper helper, int? value = 1)
        {
            var msg = value.Value == 1 ? "启用" : "停用";
            string enabledStatus = value.Value == 1 ? "checked" : "";
            string disabledStatus = value.Value == 0 ? "checked" : "";

            string result = string.Format(@"
                <input name = ""Status"" value = ""1"" title = ""启用"" {0} type = ""radio"" >
                    <div class=""layui-unselect layui-form-radio layui-form-radioed"">
                        <i class=""layui-anim layui-icon""></i><div>启用</div>
                    </div>
                <input name = ""Status"" value=""0"" title=""停用"" type=""radio"" {1}>
                    <div class=""layui-unselect layui-form-radio""><i class=""layui-anim layui-icon""></i><div>停用</div>
                </div>",
                enabledStatus, disabledStatus);

            return new HtmlString(result);
        }
        /// <summary>
        /// Action位置下拉框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="defaultTxt">默认显示文本</param>
        /// <returns></returns>
        public static HtmlString PositionSelectHtml(this HtmlHelper helper, int defaultVal =1)
        {
            var positionOut = defaultVal == 1 ? "selected" : "";
            var positionIn = defaultVal == 0 ? "selected" : "";
            return new HtmlString(string.Format(@"<select name='position' id='position' >
                            <option value = ''>请选择</option >
                            <option value = '1' {0}> 表外 </option>
                            <option value = '0'{1}> 表内 </option>
                             </select>", positionOut, positionIn));
        }
        /// <summary>
        /// 状态下拉框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="defaultTxt">默认显示文本</param>
        /// <returns></returns>
        public static HtmlString StatusSelectHtml(this HtmlHelper helper, string defaultTxt = "")
        {
            return new HtmlString(string.Format(@"<select name='Status' id='Status' >
                            <option value = ''>{0}</option >
                            <option value = '1'> 启用 </option>
                            <option value = '0'> 停用 </option>
                             </select>", defaultTxt));
        }
        /// <summary>
        /// 性别下拉框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="defaultTxt">默认显示文本</param>
        /// <returns></returns>
        public static HtmlString GanderRadioHtml(this HtmlHelper helper, int defaultVal = 1)
        {
            var _male = defaultVal == 1 ? "checked" : "";
            var _female = defaultVal == 0 ? "checked" : "";
            return new HtmlString(string.Format(@"<input type='radio' name='Gender' value='1' title='男' {0}>
                     <input type='radio' name='Gender' value='0' title='女' {1}>", _male, _female));
        }
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString SearchBtnHtml(this HtmlHelper helper, string txt = "搜索", string _class = "")
        {
            return new HtmlString(string.Format("<a href='javascript:;' class='layui-btn{1}' id='btnSearch' data-type='submit'><i class='layui-icon'>&#xe615;</i>{0}</a>", txt, _class));
        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString ResetBtnHtml(this HtmlHelper helper, string txt = "重置", string _class = " layui-btn-primary")
        {
            return new HtmlString(string.Format("<button type='reset' class='layui-btn{1}'>{0}</button>", txt, _class));
        }
        /// <summary>
        /// 表单内工具栏
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString ToolBarHtml(this HtmlHelper helper, dynamic _list = null)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("<script type='text/html' id='bar'>");
            var list = _list as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    var _icon = string.IsNullOrEmpty(v.Icon) ? "" : string.Format("<i class='layui-icon iconfont {0}'></i>", v.Icon);
                    sb.AppendFormat("<a class='layui-btn layui-btn-xs {0}' lay-event='{1}'>{3}{2}</a>", v.ClassName, v.Method, v.ActionName, _icon);
                }
            }
            //sb.Append("</script>");
            return new HtmlString(sb.ToString());
        }
        /// <summary>
        /// 表单外工具栏
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static HtmlString TopToolBarHtml(this HtmlHelper helper, dynamic _list = null, string initTxt = null)
        {
            StringBuilder sb = new StringBuilder();
            //as 类型强制转换
            var list = _list as List<ActionModel>;
            if (list != null && list.Count > 0)
            {
                foreach (var v in list)
                {
                    sb.AppendFormat(@"
                        <a href='javascript:;' class='layui-btn {0}' id='btn{1}'>
                            <i class='layui-icon iconfont {2}'></i> {3}
                        </a>", v.ClassName, v.ActionCode, v.Icon, initTxt == null ? v.ActionName : initTxt);
                }
            }
            return new HtmlString(sb.ToString());
        }

        /// <summary>
        /// 角色复选框
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="_list"></param>
        /// <returns></returns>
        public static HtmlString RoleCheckBox(this HtmlHelper helper, dynamic _allRolelist = null, dynamic _userRolelist = null)
        {
            StringBuilder sb = new StringBuilder();

            //< input type = "checkbox" name = "role1" lay - skin = "primary" title = "发呆1" >


            //前端传过来的角色列表信息
            var rolelist = _allRolelist as List<RoleModel>;
            var userrolelist = _userRolelist as List<RoleModel>;

            if (rolelist != null && rolelist.Count > 0)
            {
                //遍历checkbox复选框
                foreach (var roleModel in rolelist)
                {

                    bool isSelect = false;
                    if (userrolelist != null)
                    {
                        foreach (var userRoleModel in userrolelist)
                        {
                            //如果是选中状态，则isSeclect为true
                            if (userRoleModel.Id == roleModel.Id)
                            {
                                isSelect = true;
                            }
                        }
                    }

                    sb.AppendFormat(@"<input type='checkbox' lay-skin='primary' name='{0}' title='{1}' value='{2}' {3}>", roleModel.RoleName, roleModel.RoleName, roleModel.Id, isSelect ? "checked" : "");
                }
            }
            return new HtmlString(sb.ToString());
        }

        public static HtmlString RemarkHtml(this HtmlHelper helper,dynamic Remark = null)
        {
            StringBuilder sb = new StringBuilder();


            if (!string.IsNullOrEmpty(Remark))
            {
                sb.AppendFormat(@"<textarea name='Remark' id='Remark' value={0} placeholder='请输入内容' class='layui-textarea' lay-verify='pass' ></textarea>", Remark);
            }
            else
            {
                sb.AppendFormat(@"<textarea name='Remark' id='Remark' placeholder='请输入内容' class='layui-textarea' lay-verify='pass' ></textarea>");
            }
            
            
            return new HtmlString(sb.ToString());
        }

    }
}