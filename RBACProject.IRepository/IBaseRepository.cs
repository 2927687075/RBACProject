using RBACProject.Model;
using System.Collections.Generic;
using SqlSugar;
using System.Linq.Expressions;
using System;

namespace RBACProject.IRepository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        #region insert
        // 单个插入
        bool Insert(T model);
        //批量插入
        bool Insert(List<T> models);
        #endregion

        #region query
        T querySingle(int id);
        List<T> queryAll();
        List<T> queryByWhere(Expression<Func<T, bool>> expression);
        #endregion query

        #region delete
        bool Delete(int Id);
        bool Delete(T model);
        bool Delete(List<T> models);
        bool DeleteByWhere(Expression<Func<T, bool>> where);
        #endregion

        #region Update
        bool Update(T model);


        #endregion

        #region 分页查询

        //待完善

        #endregion

    }
}
