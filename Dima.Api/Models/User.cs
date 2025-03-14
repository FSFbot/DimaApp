using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models
{
    public class User : IdentityUser<long>
    {
        public List<IdentityUserRole<long>>? Roles { get; set; } = null!;
    }
}