using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.CategoryDTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public string? ParentCategory { get; set; }
        public bool IsPublish { get; set; }
    }
}
