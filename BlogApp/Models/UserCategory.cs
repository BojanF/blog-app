using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model {
    public class UserCategory {/*Many to many relationship references*/
        public string UserId { get; set; }        

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public long CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
