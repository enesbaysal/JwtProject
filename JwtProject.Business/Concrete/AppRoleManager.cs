using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Concrete;
using JwtProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.Business.Concrete
{
    public class AppRoleManager :GenericManager<AppRole> ,IAppRoleService
    {
        private readonly IGeneric<AppRole> _generic;
        public AppRoleManager(IGeneric<AppRole> generic):base(generic)
        {
            _generic = generic;
        }

        public async Task<AppRole> FindByName(string roleName)
        {

            return await _generic.GetByFilter(I => I.Name == roleName);
           // throw new NotImplementedException();
        }
    }
}
