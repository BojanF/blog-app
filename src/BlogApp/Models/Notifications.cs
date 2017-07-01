using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Notifications {
        public int ID { get; set; }
        public string text { get; set; }
        public DateTime time { get; set; }
        public bool recived { get; set; }

    }//end Notification class
}
