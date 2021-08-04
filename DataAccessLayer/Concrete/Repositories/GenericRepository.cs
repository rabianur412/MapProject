﻿using DataAccessLayer.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        MapContext context = new MapContext();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T t)
        {
            var deletedEntity = context.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T t)
        {
            var addedEntity = context.Entry(t);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = context.Entry(t);
            updatedEntity.State = EntityState.Modified;
            try
            {
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException)
            {
               
                context.SaveChanges();
            }
        }
    }
}
