﻿using AutoMapper;
using Inventory_management.bll.DTOs.ProductDTO;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Product;
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

    }
}
