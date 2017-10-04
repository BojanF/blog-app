using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlogApp.Models {
   
    public class Users {
        public Users() {
            Posts = new List<Posts>();
            Notifications = new List<Notifications>();
            Comments = new List<Comments>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; } //EF handle as primary key (ID or classnameID)
        [Required]
        public String Username { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }

        [Column("role")]
        [Required]
        public String RoleType {
            get { return Role.ToString(); }
            set { Role = EnumExtensions.ParseEnum<UserRole>(value); }
        }

        [NotMapped]
        [JsonIgnore]
        public UserRole Role { get; set; }
        
        public ICollection<Comments> Comments { get; set; }//one user has many comments(1 to many)
        public ICollection<Posts> Posts { get; set;} //one user has many posts(1 to many)
        public ICollection<Notifications> Notifications { get; set; } //(1 to many)

        public ICollection<UserCategory> UsersCategories { set; get; } //(many to many)
    }// end User class 

    public class EnumExtensions
    {
        /// <summary>
        /// Gets the String representation for this enums choosen 
        /// </summary>
        /// <param name="e">Instance of the enum chosen</param>
        /// <returns>Name of the chosen enum in String representation</returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }//End EnumExtensions class
}
