using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models.enums;


namespace BlogApp.Models {
    public class Users {
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public string Username { get; set; }
        public string Email { get; set; }

        public UserRole Role;

        public ICollection<Comments> Comments { get; set; }//one user has many comments(1 to m)
        public ICollection<Posts> Posts { get; set;} //one user has many posts(1 to m)

    }// end User class  .
}
