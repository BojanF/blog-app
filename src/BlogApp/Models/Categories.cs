using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Categories {
        public Categories() {
            Users = new HashSet<Users>();
            Posts = new HashSet<Posts>();
        }
        [Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int LikesRule { get; set; }
        public int PostRule { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Users> Users { get; set; }


    }//end Categories class
}
