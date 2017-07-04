using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Posts {
        public Posts() {
            Comments = new List<Comments>();
            Categories = new HashSet<Categories>();
        }
        [Key]
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public string PostedText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool Approved { get; set; }
        public DateTime PostedAt { get; set; }

        public int UserIdFK { get; set; } // Foregin key

        public virtual ICollection<Comments> Comments { get; set; } //One post has many comments (1 to m)
        public virtual ICollection<Categories> Categories { get; set; }

        [ForeignKey("UserIdFK")]
        public virtual Users Users { get; set;} // Posts entity can hold one User

    }//end Post class
}
