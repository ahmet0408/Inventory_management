using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.dal.Models.Category
{
    public class CategoryTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
