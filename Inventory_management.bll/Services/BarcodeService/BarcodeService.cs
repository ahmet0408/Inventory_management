using Inventory_management.bll.DTOs.ProductForBarcodeDTO;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Product;
using IronBarCode;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.BarcodeService
{
    public class BarcodeService : IBarcodeService
    {
        private readonly ApplicationDbContext _dbContext;

        public BarcodeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> GenerateBarcode(ProductForBarcodeDTO product)
        {
            string name = product.Name.ToString().PadLeft(5,'0');
            string date = product.ArrivalAt.ToString("ddMMyyyy");
            string price = ((int)(product.Price * 100)).ToString().PadLeft(3, '0');

            string barcodeNumber = $"{name}{date}{price}";

            // Generate barcode image
            GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(barcodeNumber, BarcodeEncoding.Code128);

            // Save barcode image to wwwroot/barcodes
            string fileName = $"barcode_{product.Name}.png";
            string path = Path.Combine("wwwroot", "barcodes", fileName);
            barcode.SaveAsPng(path);

            // Update product with barcode number
            product.Barcode = barcodeNumber;
            await _dbContext.SaveChangesAsync();

            return barcodeNumber;
        }

        public async Task<Product> DecodeBarcode(string barcodeNumber)
        {
            if (barcodeNumber.Length != 16) // PPPPPDDMMYYYYPPP = 16 digits
                throw new ArgumentException("Invalid barcode format");

            string productId = barcodeNumber.Substring(0, 5);
            string dateStr = barcodeNumber.Substring(5, 8);
            string priceStr = barcodeNumber.Substring(13, 3);

            int id = int.Parse(productId);
            DateTime date = DateTime.ParseExact(dateStr, "ddMMyyyy", null);
            decimal price = decimal.Parse(priceStr) / 100;

            return await _dbContext.Product.FindAsync(id);
        }

    }
}
