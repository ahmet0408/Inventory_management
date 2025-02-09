using AutoMapper;
using Inventory_management.bll.DTOs.ProductDTO;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public static string FilePath { get; } = "haryt";

        public ProductService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateProduct(CreateProductDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Product product = _mapper.Map<Product>(modelDTO);
                if (modelDTO.FormImage != null)
                {
                    product.Image = await _imageService.UploadImage(modelDTO.FormImage, FilePath);

                }
                await _dbContext.Product.AddAsync(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditProduct(EditProductDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Product product = _mapper.Map<Product>(modelDTO);
                if (modelDTO.FormImage != null)
                {
                    _imageService.DeleteImage(modelDTO.Image, FilePath);
                    await _imageService.UploadImage(modelDTO.FormImage, FilePath);
                }
                _dbContext.Product.Update(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveProduct(int id)
        {
            var product = await _dbContext.Product.FindAsync(id);
            if (!string.IsNullOrEmpty(product.Image))
            {
                _imageService.DeleteImage(product.Image, FilePath);
            }
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _dbContext.Product.Include(p => p.Department).ThenInclude(p => p.DepartmentTranslates).Include(p => p.Employee).Include(p => p.ProductTranslates).Include(p => p.Category).ThenInclude(p => p.CategoryTranslates).ToList();
            var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return result;
        }

        public async Task<ProductDTO> GetProductByBarcode(string barcode)
        {
            var product = await _dbContext.Product.Include(p => p.Department).ThenInclude(p => p.DepartmentTranslates).Include(p => p.Employee).Include(p => p.ProductTranslates).Include(p => p.Category).ThenInclude(p => p.CategoryTranslates).SingleOrDefaultAsync(p => p.Barcode == barcode);
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }
    }
}
