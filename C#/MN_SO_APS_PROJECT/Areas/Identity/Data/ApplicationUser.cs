using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MN_SO_APS_PROJECT.Models;

namespace MN_SO_APS_PROJECT.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public List<CommentModel>? Comments { get; set; }
    public int CityId { get; set; }
    public int CountryId { get; set; }
}

