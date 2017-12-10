using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Comment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; } //EF handle as primary key (ID or classnameID)
        [Required]
        public String CommentText { get; set; }
        public DateTime CommentedAt { get; set; }

        [Required]
        public ApplicationUser Users { get; set; } // Comments entity can hold one User(EF handle fk itslef)
        // [ForeignKey("PostId")]
        [Required]
        public Post Post { get; set; } // Comments entity can hold one Post(EF handle fk itslef)
           
    }// end Comments class
}
