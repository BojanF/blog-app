using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Categories {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int LikesRule { get; set; }
        public int PostRule { get; set; }
   
    }//end Categories class
}
