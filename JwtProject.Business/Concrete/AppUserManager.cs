using jwtProject.DataAccess.Interfaces;
using jwtProject.Entities.Concrete;
using jwtProject.Entities.Dtos.AppUserDto;
using JwtProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProject.Business.Concrete
{
    public class AppUserManager:GenericManager<AppUser> ,IAppUserService
    {
        private readonly IAppUser _appUser;
        public AppUserManager(IGeneric<AppUser> generic, IAppUser appUser) :base(generic)
        {
            _appUser = appUser;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUser.GetByFilter(I => I.UserName == appUserLoginDto.UserName);
            return appUser.Password == appUserLoginDto.Password ? true : false;
            //throw new NotImplementedException();
        }

        public async Task<AppUser> FindByUserName(string userName)
        {

            return await _appUser.GetByFilter(I => I.UserName == userName);
            //throw new NotImplementedException();
        }

        public async Task<List<AppRole>> GetRolesByUserName(string userName)
        {
            return await _appUser.GetRolesByUserName(userName);
        }

    }
}
