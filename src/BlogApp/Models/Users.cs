using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models.enums;


namespace BlogApp.Models {
    public class Users {
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public string username { get; set; }
        public string email { get; set; }

        public UserRole role;

        public ICollection<Comments> comments { get; set; }//one user has many comments(1 to m)
        public ICollection<Posts> posts { get; set;} //one user has many posts(1 to m)

    }// end User class  .
}
