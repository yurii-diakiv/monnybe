using DataAccess.Repositories;
using DataAccess.Entities;
using MonnyBE.Models;
using AutoMapper;
using MonnyBE.DTOs;

namespace MonnyBE.Services
{
    public class UsersService
    {
        private readonly UserRepository repository;
        private readonly IMapper _mapper;

        public UsersService(UserRepository userRepository, IMapper mapper)
        {
            repository = userRepository;
            _mapper = mapper;
        }
        public UserDTO GetUser(int id)
        {
            User user = repository.GetItem(id);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
        public void Register(UserDTO item)
        {
            User user = _mapper.Map<User>(item);
            repository.Create(user);
        }
        public User Login(LoginModel loginModel)
        {
           return repository.Login(loginModel.Email, loginModel.Password);
        }
    }
}
