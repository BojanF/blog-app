using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Comments {
        [Key]
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public int CommentText { get; set; }
        public DateTime CommentedAt { get; set; }

        public int UserIdFK { get; set; } // Foregin key
        public int PostIdFK { get; set; } // Foregin key

        [ForeignKey("UserIdFK")]
        public virtual Users Users { get; set; } // Comments entity can hold one User
        [ForeignKey("PostIdFK")]
        public virtual Posts Posts { get; set; } // Comments entity can hold one Post

    }// end Comments class
}
