using Inventory_management.bll.DTOs.UserDTO;
using Inventory_management.dal.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management.bll.Services.UserService
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDTO model);
        Task<AuthenticationDTO> GetTokenAsync(LoginDTO model);
        Task<string> AddRoleAsync(AddRoleDTO model);

        Task<AuthenticationDTO> RefreshTokenAsync(string jwtToken);

        bool RevokeToken(string token);
        ApplicationUser GetById(string id);
    }
}
