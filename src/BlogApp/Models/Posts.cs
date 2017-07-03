using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Posts {
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public int UserID { get; set; } // Foregin key
        public string PostedText { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool Approved { get; set; }
        public DateTime PostedAt { get; set; }

        public ICollection<Comments> Comments { get; set; } //One post has many comments (1 to m)

        public Users User { get; set;} // Posts entity can hold one User

    }//end Post class
}
