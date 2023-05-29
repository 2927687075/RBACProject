using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBACProject.Model
{
    public class ApiResult<T>
    {
        public int state { get; set; }
        public string msg { get; set; }
        public T data { get; set; }

    }
}
