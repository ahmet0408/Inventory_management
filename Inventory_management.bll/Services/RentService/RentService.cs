using AutoMapper;
using Inventory_management.bll.DTOs.RentDTO;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Rent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.RentService
{
    public class RentService: IRentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public RentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateRent(RentDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Rent rent = _mapper.Map<Rent>(modelDTO);
                await _dbContext.Rent.AddAsync(rent);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<RentDTO> GetAllRent()
        {
            var rents = _dbContext.Rent.Include(p => p.RentDetails).ThenInclude(p => p.Product).ThenInclude(p => p.ProductTranslates).Include(p => p.User).Include(p => p.Customer).ToList();
            var result = _mapper.Map<IEnumerable<RentDTO>>(rents);
            return result;
        } 
    }
}
