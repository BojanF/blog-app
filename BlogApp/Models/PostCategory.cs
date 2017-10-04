using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models {
    public class PostCategory {
        public long PostsId { get; set; }

        [ForeignKey("PostsId")]
        public Posts Posts { get; set; }

        public long CategoriesId { get; set; }

        [ForeignKey("CategoriesId")]
        public Categories Categories { get; set; }
    }
}
