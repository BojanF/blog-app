using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Posts {
        public int ID { get; set; } //EF handle as primary key (ID or classnameID)
        public int UserID { get; set; } // Foregin key
        public string postedText { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public bool approved { get; set; }
        public DateTime postedAt { get; set; }

        public ICollection<Comments> comments { get; set; } //One post has many comments (1 to m)

        public Users user { get; set;} // Posts entity can hold one User

    }//end Post class
}
