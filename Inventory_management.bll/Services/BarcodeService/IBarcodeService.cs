using Inventory_management.bll.DTOs.ProductForBarcodeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.BarcodeService
{
    public interface IBarcodeService
    {
        Task<string> GenerateBarcode(ProductForBarcodeDTO product);
    }
}
