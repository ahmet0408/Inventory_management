using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Category
{
    public class Category
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool IsPublish { get; set; }
        public int ParentId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<CategoryTranslate> CategoryTranslates { get; set; }
    }
}
