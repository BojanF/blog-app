using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Posts {
        public Posts() {
            comments = new List<Comments>();
            //Categories = new HashSet<Categories>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; } //EF handle as primary key (ID or classnameID)
        [Required]
        public String PostedText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool Approved { get; set; }
        public DateTime PostedAt { get; set; }

     

        public ICollection<Comments> comments { get; set; } //one post has many comments (1 to m)
        public ICollection<PostCategory> PostsCategories { get; set; } // many categories contains many posts

        //[ForeignKey("UserId")]
        [Required]
        public Users Users { get; set;} // Posts entity can hold one User
       
    }//end Post class
}
