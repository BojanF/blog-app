using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;

namespace BlogApp.Persistence
{
    public interface IAdminRepo
    {
        List<ApplicationUser> GetAllUsers();
    }
}
