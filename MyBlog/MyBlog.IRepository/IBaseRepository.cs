using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class,new()
    {   
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DelteAsync(int id);
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);

        Task<TEntity> FindAsync(Expression<Func<TEntity,bool>> func);
        // whole data search
        Task<List<TEntity>> QueryAsync();
        // specific condition search
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func);
        /// pagination search
        Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        // Specific condistion pagination search
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity,bool>> func, int page, int size, RefAsync<int> total);
    }
}
