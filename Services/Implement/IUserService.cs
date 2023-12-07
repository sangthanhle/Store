using OnlineStore.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.BusinessLogic.Implement
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUserAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task AddUserAsync(UserDTO user);
        Task UpdateUserAsync(int id, UserDTO user);
        Task DeleteUserAsync(int id);
        Task SaveChangeAsync();
        Task<(IEnumerable<UserDTO>, int)> GetPagedAsync(int pageNumber, int pageSize);
        Task<List<UserDTO>> SearchUserByNameAsync(string name);
    }
}
