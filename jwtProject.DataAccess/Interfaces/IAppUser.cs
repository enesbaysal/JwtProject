using jwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jwtProject.DataAccess.Interfaces
{
     public interface IAppUser:IGeneric<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserName(string userName);
    }
}
