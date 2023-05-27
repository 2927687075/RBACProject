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
   public class SqlSugarHelper<T> where T : class, new()
    {
        public static SqlSugarClient db = GetInstance();

        //public SqlSugarHelper()
        //{
        //    db = new SqlSugarClient(new ConnectionConfig()
        //    {
        //        ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString,
        //        DbType = DbType.SqlServer,
        //        IsAutoCloseConnection = true,
        //    });
        //}

        private static SqlSugarClient GetInstance()
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionStr,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute, // Attribute 表示从实体特性中读取主键信息
            });
            db.Aop.OnLogExecuted = (sql, pars) =>
            {
                Console.WriteLine("【SqlLog】" + sql + " " + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
            return db;
        }


        public static bool Insert(T entity)
        {
            return db.Insertable(entity).ExecuteCommand() > 0;
        }

        public static bool Insert(List<T> models)
        {
            return db.Insertable(models).ExecuteCommand() > 0;
        }

        public static bool Delete(int id)
        {
            return db.Deleteable<T>(id).ExecuteCommand() > 0;
        }

        public static bool Delete(T model)
        {
            return db.Deleteable<T>(model).ExecuteCommand() > 0;
        }

        public static bool Delete(List<T> models)
        {
            return db.Deleteable<T>(models).ExecuteCommand() > 0;
        }

        public static bool Delete(Expression<Func<T, bool>> where)
        {
            return db.Deleteable<T>(where).ExecuteCommand() > 0;
        }

        public static bool Update(T entity)
        {
            return db.Updateable(entity).ExecuteCommand() > 0;
        }

        public static T GetById(int id)
        {
            return db.Queryable<T>().InSingle(id);
        }

        public static List<T> GetList()
        {
            return db.Queryable<T>().ToList();
        }

        public static List<T> GetList(Expression<Func<T, bool>> where)
        {
            return db.Queryable<T>().Where(where).ToList();
        }

        public static T GetSingle(Expression<Func<T, bool>> where)
        {
            return db.Queryable<T>().Single(where);
        }

        public static int GetCount(Expression<Func<T, bool>> where)
        {
            return db.Queryable<T>().Count(where);
        }

    }
}
