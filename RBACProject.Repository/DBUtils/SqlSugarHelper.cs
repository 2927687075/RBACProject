using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq.Expressions;

namespace SqlsugarHelper
{
   public class SqlSugarHelper
    {
        public static SqlSugarClient db;

        public SqlSugarHelper()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            });
        }

        

    }
}
