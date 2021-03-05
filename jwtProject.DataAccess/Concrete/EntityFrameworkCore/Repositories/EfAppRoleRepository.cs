using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppRoleRepository :EfGenericRepository<AppRole>, IAppRole
    {
    }
}
