using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BlogApp.Models {
    public class Category {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public String CategoryName { get; set; }
        public int PostRule { get; set; }


        public ICollection<UserCategory> UsersCategories { get; set; }
        public ICollection<Post> Posts { get; set; }
    }//end Categories class
}
