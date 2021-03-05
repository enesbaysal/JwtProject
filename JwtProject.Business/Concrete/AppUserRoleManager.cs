using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Concrete;
using JwtProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.Concrete
{
    public class AppUserRoleManager:GenericManager<AppUserRole> , IAppUserRoleService
    {
        public AppUserRoleManager(IGeneric<AppUserRole> generic) :base(generic)
        {

        }
    }
}
