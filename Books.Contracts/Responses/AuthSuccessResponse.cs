using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Contracts.Responses
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }

        public AuthSuccessResponse(string token)
        {
            Token = token;
        }
    }
}
