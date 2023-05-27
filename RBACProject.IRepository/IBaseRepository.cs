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
        int insert(T model);
        //批量插入
        int insert(List<T> model);
        #endregion

        #region query
        T querySingle(int id);
        List<T> queryAll();
        List<T> queryByWhere(Expression<Func<T, bool>> expression);
        #endregion query

        #region delete
        int Delete(int Id);
        int Delete(T model);
        int Delete(List<T> models);
        int DeleteByWhere(Expression<Func<T, bool>> where);
        #endregion

        #region Update
        int Update(T model);


        #endregion

        #region 分页查询

        //待完善

        #endregion

    }
}
