using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MovieStore.Application.Services.Logins.Dto
{
    public class RefreshLoginGetDto
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }
}
