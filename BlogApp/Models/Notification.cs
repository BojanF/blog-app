using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public String Text { get; set; }
        public DateTime Time { get; set; }
        public bool Recived { get; set; }
             
        //[ForeignKey("UserId")]
        [Required]
        public User User { get; set; }//(EF handle fk itslef)
    }//end Notification class
}