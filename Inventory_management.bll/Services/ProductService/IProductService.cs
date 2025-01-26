using Inventory_management.bll.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.ProductService
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDTO modelDTO);
        Task EditProduct(EditProductDTO modelDTO);
        Task RemoveProduct(int id);
        IEnumerable<ProductDTO> GetProducts();
    }
}
