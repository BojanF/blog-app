using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Notifications {
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool Recived { get; set; }

    }//end Notification class
}
