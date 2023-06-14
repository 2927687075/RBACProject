using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Model
{
    public class TableResult<T>
    {
        public int code { get; set; }
        public int count { get; set; }

        public List<T> data { get; set; }




    }
}
