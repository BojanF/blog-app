using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Posts {
        public int ID { get; set; }
        public string postedText { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public bool approved { get; set; }
        public DateTime postedAt { get; set; }


    }//end Post class
}
