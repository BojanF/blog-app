using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Notifications {
        [Key]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool Recived { get; set; }

        public int UserIdFK;

        [ForeignKey("UserIdFK")]
        public virtual Users Users { get; set; }
    }//end Notification class
}
