using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models {
    public class Users {
        public Users() {
            Posts = new List<Posts>();
            Notifications = new List<Notifications>();
            Comments = new List<Comments>();
            Categories = new HashSet<Categories>();
        }
        [Key]
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public string Username { get; set; }
        public string Email { get; set; }

        public UserRole Role;

        public virtual ICollection<Comments> Comments { get; set; }//one user has many comments(1 to many)
        public virtual ICollection<Posts> Posts { get; set;} //one user has many posts(1 to many)
        public virtual ICollection<Notifications> Notifications { get; set; } //(1 to many)

        public virtual ICollection<Categories> Categories { set; get; } //(many to many)
    }// end User class  .
}
