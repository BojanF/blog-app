using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Comments {
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public int UserID { get; set; } // Foregin key
        public int CommentText { get; set; }
        public DateTime CommentedAt { get; set; }

        public Users User { get; set; } // Comments entity can hold one User
        public Posts Post { get; set; } // Comments entity can hold one Post

    }// end Comments class
}
