using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class Post {
        public Post() {
            Comments = new List<Comment>();
            //Categories = new HashSet<Categories>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; } //EF handle as primary key (ID or classnameID)
        [Required]
        public String Headline { get; set; }
        [Required]
        public String Caption { get; set; }
        [Required]
        public String PostedText { get; set; }
        public int Likes { get; set; }
        public bool Approved { get; set; }
        public DateTime PostedAt { get; set; }
        [Required]
        public bool Edited { get; set; }



        public ICollection<Comment> Comments { get; set; } //one post has many comments (1 to m)

        //[ForeignKey("UserId")]
        [Required]
        public string UserName { get; set;} // Posts entity can hold one User
        [Required]
        public ApplicationUser UserId { get; set; }

        [Required, ForeignKey("CategoryId")]
        public long CategoryId { get; set; }
        public Category Category{ get; set; }
        
        public string approvedByUserId { get; set; }
        public ApplicationUser approvedByUser { get; set; }

        public String PostedAtToString()
        {
            String Month = null;
            if(PostedAt.Month == 1)
            {
                Month = "January";
            }
            else if(PostedAt.Month == 2)
            {
                Month = "February";
            }
            else if (PostedAt.Month == 3)
            {
                Month = "March";
            }
            else if (PostedAt.Month == 4)
            {
                Month = "April";
            }
            else if (PostedAt.Month == 5)
            {
                Month = "May";
            }
            else if (PostedAt.Month == 6)
            {
                Month = "June";
            }
            else if (PostedAt.Month == 7)
            {
                Month = "July";
            }
            else if (PostedAt.Month == 8)
            {
                Month = "August";
            }
            else if (PostedAt.Month == 9)
            {
                Month = "September";
            }
            else if (PostedAt.Month == 10)
            {
                Month = "October";
            }
            else if (PostedAt.Month == 10)
            {
                Month = "November";
            }
            else
            {
                Month = "December";
            }
            return PostedAt.Day.ToString() + "." + Month + "." + PostedAt.Year.ToString();
        }
    }//end Post class
}
