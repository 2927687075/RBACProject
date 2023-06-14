using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Model
{
    public class MenuTree
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 定义一个children，用于存放子数据
        /// </summary>
        public IEnumerable<MenuTree> children { get; set; }    
        /// <summary>
        /// 别名
        /// </summary>
        public string alias { get; set; }
        public string icon { get; set; }
        public string href { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool spread { get; set; }            

    }
}
