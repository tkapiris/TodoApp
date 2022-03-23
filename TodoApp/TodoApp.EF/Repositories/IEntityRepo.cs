﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Model;

namespace TodoApp.EF.Repositories
{
    public interface IEntityRepo<TEntity>
        where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
    }
}
