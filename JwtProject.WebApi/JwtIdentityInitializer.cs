using jwtProject.Entities.Concrete;
using JwtProject.Business.Interfaces;
using JwtProject.Business.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtProject.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppRoleService appRoleService, IAppUserRoleService appUserRoleService )
        {
            //have a role
           var adminRole= await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole==null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("enesb");
            if (adminUser==null)
            {
                await appUserService.Add(new AppUser
                {
                    
                    UserName = "enesb",
                    FullName = "enes baysal",
                    Password="123"

                });
                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var admin = await appUserService.FindByUserName("enesb");
                await appUserRoleService.Add(new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId=admin.Id
                });

            }
        }
    }
}
