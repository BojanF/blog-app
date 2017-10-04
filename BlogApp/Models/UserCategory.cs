using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model {
    public class UserCategory {/*Many to many relationship references*/
        public long UsersId { get; set; }

        [ForeignKey("UsersId")]
        public Users Users { get; set; }

        public long CategoriesId { get; set; }

        [ForeignKey("CategoriesId")]
        public Categories Categories { get; set; }

    }
}
