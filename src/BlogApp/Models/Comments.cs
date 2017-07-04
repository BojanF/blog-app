using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Comments {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public int CommentText { get; set; }
        public DateTime CommentedAt { get; set; }

        public  Users Users { get; set; } // Comments entity can hold one User(EF handle fk itslef)
       // [ForeignKey("PostId")]
        public  Posts Posts { get; set; } // Comments entity can hold one Post(EF handle fk itslef)

    }// end Comments class
}
