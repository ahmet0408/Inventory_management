using AutoMapper;
using Inventory_management.bll.DTOs.EmployeeDTO;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public static string FilePath { get; } = "employee";

        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateEmployee(CreateEmployeeDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Employee employee = _mapper.Map<Employee>(modelDTO);
                if (modelDTO.FormPicture != null)
                {
                    employee.Picture = await _imageService.UploadImage(modelDTO.FormPicture, FilePath);
                }
                await _dbContext.Employee.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
