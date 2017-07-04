using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class PostCategory {
        public int PostsId { get; set; }

        [ForeignKey("PostsId")]
        public Posts Posts { get; set; }

        public int CategoriesId { get; set; }

        [ForeignKey("CategoriesId")]
        public Categories Categories { get; set; }
    }
}
