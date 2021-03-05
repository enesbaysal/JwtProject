using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Interfaces;
using JwtProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGeneric<TEntity> _generic;
        public GenericManager(IGeneric<TEntity> generic)
        {
            _generic = generic;
        }

        public async Task Add(TEntity entity)
        {
            await _generic.Add(entity);
            //throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _generic.GetAll();
            //throw new NotImplementedException();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _generic.GetById(id);

           // throw new NotImplementedException();
        }

        public async Task Remove(TEntity entity)
        {
            await _generic.Remove(entity);
            //throw new NotImplementedException();
        }

        public async Task Update(TEntity entity)
        {

            await _generic.Update(entity);
            //throw new NotImplementedException();
        }
    }
}
