using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models.enums;


namespace BlogApp.Models {
    public class Users {
        public int ID { get; set; }
        public string username { get; set; }
        public string email { get; set; }

        public UserRole role;

    }// end User class  .
}
