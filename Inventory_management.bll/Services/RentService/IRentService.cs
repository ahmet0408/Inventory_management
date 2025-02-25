using Inventory_management.bll.DTOs.RentDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.RentService
{
    public interface IRentService
    {
        Task CreateRent(RentDTO modelDTO);
        IEnumerable<RentDTO> GetAllRent();
    }
}
