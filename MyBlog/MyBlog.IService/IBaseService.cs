﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IService
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DelteAsync(int id);
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        // whole data search
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
        Task<List<TEntity>> QueryAsync();
        // specific condition search
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);
        /// pagination search
        Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        // Specific condistion pagination search
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
    }
}

