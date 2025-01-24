using AutoMapper;
using Inventory_management.bll.DTOs.DepartmentDTO;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DepartmentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateDepartment(CreateDepartmentDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Department department = _mapper.Map<Department>(modelDTO);
                await _dbContext.Department.AddAsync(department);
                await _dbContext.SaveChangesAsync();
            }
        } 

        public async Task EditDepartment(EditDepartmentDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Department department = _mapper.Map<Department>(modelDTO);
                _dbContext.Department.Update(department);
                await _dbContext.SaveChangesAsync();
            }
        }
        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            var deparments = _dbContext.Department.Include(p => p.DepartmentTranslates).ToList();
            var result = _mapper.Map<IEnumerable<DepartmentDTO>>(deparments);
            return result;
        }
    }
}
