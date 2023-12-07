using AutoMapper;
using OnlineStore.BusinessLogic.Implement;
using OnlineStore.DataAccess.Infrastructure;
using OnlineStore.DataAccess.Repositories;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.DTO;

namespace OnlineStore.BusinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public  async Task AddUserAsync(UserDTO user)
        {
            var newUser = _mapper.Map<User>(user);
            await _userRepository.AddAsync(newUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser != null)
            {
                await _userRepository.DeleteAsync(id);
                await _userRepository.SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserAsync()
        {
            var user = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(user);
        }

        public async Task<(IEnumerable<UserDTO>, int)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var user = await _userRepository.GetPerPageAsync(pageNumber, pageSize);
            var totalUserCount = await _userRepository.GetTotalCountAsync();

            var UserDTOs = _mapper.Map<IEnumerable<UserDTO>>(user);

            return (UserDTOs, totalUserCount);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task SaveChangeAsync()
        {
            await _userRepository.SaveChangeAsync();
        }
        public async Task<List<UserDTO>> SearchUserByNameAsync(string name)
        {
            var user = await _userRepository.SearchByNameAsync(name);
            var userDTO = _mapper.Map<List<UserDTO>>(user);
            return userDTO;
        }

        public async Task UpdateUserAsync(int id, UserDTO user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return;
            }

            _mapper.Map(user, existingUser);
            await _userRepository.UpdateAsync(existingUser);
        }
    }
 }
