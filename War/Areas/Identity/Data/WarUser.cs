using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace War.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WarUser class
public class WarUser : IdentityUser
{
    public string IGN { get; set; }

}

