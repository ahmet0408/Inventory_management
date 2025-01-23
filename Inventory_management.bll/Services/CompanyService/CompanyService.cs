using AutoMapper;
using Inventory_management.bll.DTOs.CompanyDTO;
using Inventory_management.bll.DTOs.CreateCompanyDTO;
using Inventory_management.bll.Services.ImageService;
using Inventory_management.dal.Data;
using Inventory_management.dal.Models.Company;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public static string FilePath { get; } = "company";

        public CompanyService(ApplicationDbContext dbContext, IMapper mapper, IImageService imageService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task CreateCompany(CreateCompanyDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Company company = _mapper.Map<Company>(modelDTO);
                if (modelDTO.FormLogo != null)
                {
                    company.Logo = await _imageService.UploadImage(modelDTO.FormLogo, FilePath);
                }
                await _dbContext.Company.AddAsync(company);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditCompany(EditCompanyDTO modelDTO)
        {
            if (modelDTO != null)
            {
                Company company = _mapper.Map<Company>(modelDTO);
                if (modelDTO.FormLogo != null)
                {
                    _imageService.DeleteImage(modelDTO.Logo, FilePath);
                    await _imageService.UploadImage(modelDTO.FormLogo, FilePath);
                }
                _dbContext.Company.Update(company);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<CompanyDTO> GetCompanies()
        {
            var companies = _dbContext.Company.ToList();
            var result = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
            return result;
        } 
    }
}
