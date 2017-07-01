using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Categories {
        public int ID { get; set; }
        public string categoryName { get; set; }
        public int likesRule { get; set; }
        public int postRule { get; set; }
   
    }//end Categories class
}
