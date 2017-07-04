using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Categories {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int LikesRule { get; set; }
        public int PostRule { get; set; }


        public ICollection<UserCategory> UsersCategories { get; set; }
        public ICollection<PostCategory> PostsCategories { get; set; }

    }//end Categories class
}
