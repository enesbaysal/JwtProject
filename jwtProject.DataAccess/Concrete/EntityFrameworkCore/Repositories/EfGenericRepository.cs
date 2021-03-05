using jwtProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace jwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGeneric<TEntity> where TEntity : class, ITable, new()
    {
        public async Task Add(TEntity entity)
        {
            //throw new NotImplementedException();

            using var context = new JwtContext();
            context.Add(entity);
           await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            //throw new NotImplementedException();

            using var context = new JwtContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            //throw new NotImplementedException();
        }

        public async Task<TEntity> GetById(int id)
        {
            using var context = new JwtContext();
            return await context.Set<TEntity>().FindAsync(id);

           // throw new NotImplementedException();
        }

        public async Task Remove(TEntity entity)
        {
            using var context = new JwtContext();
            context.Remove(entity);
            await context.SaveChangesAsync();

           // throw new NotImplementedException();
        }

        public async Task Update(TEntity entity)
        {

            using var context = new JwtContext();
            context.Update(entity);
            await context.SaveChangesAsync();

           // throw new NotImplementedException();
        }
    }
}
