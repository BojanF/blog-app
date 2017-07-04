using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model {
    public class UserCategory {/*Many to many relationship references*/
        public int UsersId { get; set; }

        [ForeignKey("UsersId")]
        public Users Users { get; set; }

        public int CategoriesId { get; set; }

        [ForeignKey("CategoriesId")]
        public Categories Categories { get; set; }

    }
}
