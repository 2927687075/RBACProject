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
        T QuerySingle(Expression<Func<T, bool>> expression);
        List<T> queryAll();
        List<T> queryByWhere(Expression<Func<T, bool>> expression);
        #endregion query

        #region delete
        bool Delete(T model);
        bool Delete(List<T> models);
        bool DeleteByWhere(Expression<Func<T, bool>> where);
        #endregion

        #region Update
        bool Update(T model);
        bool Update(List<T> models);
        bool Update(Expression<Func<T, bool>> expression);
        bool Update(Expression<Func<List<T>, bool>> expression);




        #endregion

        #region 分页查询

        //待完善

        #endregion

    }
}
