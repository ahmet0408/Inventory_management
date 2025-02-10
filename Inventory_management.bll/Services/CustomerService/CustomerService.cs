using AutoMapper;
using Inventory_management.bll.DTOs.CustomeDTO;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Customer;
using Inventory_management.dal.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public static string FilePath { get; } = "customer";

        public CustomerService(IImageService imageService, IMapper mapper, ApplicationDbContext dbContext)
        {
            _imageService = imageService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task CreateCustomer(CreateCustomerDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Customer customer = _mapper.Map<Customer>(modelDTO);
                if (modelDTO.FormPicture != null)
                {
                    customer.Picture = await _imageService.UploadImage(modelDTO.FormPicture, FilePath);
                }
                await _dbContext.Customer.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var customers = _dbContext.Customer.ToList();
            var result = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return result;
        }
    }
}
