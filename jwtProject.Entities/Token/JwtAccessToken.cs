using jwtProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtProject.Entities.Token
{
    public class JwtAccessToken :IToken
    {
        public string Token { get; set; }
    }
}
