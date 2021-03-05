using AutoMapper;
using jwtProject.Entities.Concrete;
using jwtProject.Entities.Dtos.AppUserDto;
using jwtProject.Entities.Token;
using JwtProject.Business.Interfaces;
using JwtProject.Business.StringInfo;
using JwtProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _appUserService = appUserService;
        }


        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {

            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByUserName(appUserLoginDto.UserName);
                    var token = _jwtService.GenerateJwt(appUser, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.Token = token;
                    return Created("", jwtAccessToken);
                }
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[Action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppRoleService appRoleService, 
            [FromServices] IAppUserRoleService appUserRoleService) 
        {
          var appUser= await _appUserService.FindByUserName(appUserAddDto.UserName);
            if (appUser != null)
              return  BadRequest($"{appUserAddDto.UserName} sistemde mevcut");

              await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByUserName(appUserAddDto.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId=user.Id
            });
            
            return Created("",appUserAddDto);
        }

        
        [HttpGet("[Action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUserName(User.Identity.Name);
            var roles = await _appUserService.GetRolesByUserName(User.Identity.Name);

            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };
            return Ok(appUserDto);
        }

    }
}
