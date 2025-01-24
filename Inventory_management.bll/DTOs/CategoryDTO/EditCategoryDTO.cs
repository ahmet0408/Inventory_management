using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.DTOs.CategoryDTO
{
    public class EditCategoryDTO
    {
        public int Id { get; set; }
        public ICollection<CategoryTranslateDTO> CategoryTranslates { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public bool IsPublish { get; set; }
    }
}
