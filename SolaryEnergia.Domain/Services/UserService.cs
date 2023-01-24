using Microsoft.IdentityModel.Tokens;
using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Exceptions;
using SolaryEnergia.Domain.Interfaces.Repositories;
using SolaryEnergia.Domain.Interfaces.Services;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Delete(int id)
        {
            UserDto userDb = GetById(id);
            _userRepository.Delete(new User(userDb));
        }

        public IList<UserDto> Get()
        {
            return _userRepository.Get().Select(u => new UserDto(u)).ToList();
        }

        public UserDto GetById(int id)
        {
            User userDb = _userRepository.GetById(id);
            if (userDb == null)
                throw new UserNaoCadastradoException("Usuário não cadastrado!");

            return new UserDto(userDb);
        }



        public void Post(UserDto user)
        {
            if (user != null)
            {

                user.Password = Utils.MD5Utils.GerarHashMD5(user.Password);
                user.Email = user.Email.ToLower();

                if (VerificarEmail(user))
                {
                   
                    throw new UserJaCadastradoException("Usuário já cadastrado!");
                }
                _userRepository.Post(new User(user));
            }
        }

        private bool VerificarEmail(UserDto user)
        {

            bool existsUser = _userRepository.Get().Any(u => u.Email == user.Email);
            return existsUser;
        }


      

        public void Put(UserDto user)
        {
            User userDb = _userRepository.GetById(user.Id);
            if (userDb == null)
                throw new UserNaoCadastradoException("Usuário não encontrado");

            userDb.Update(user);

            _userRepository.Put(userDb);
        }



        public Tuple<string, string, string> GetUser(LoginDto login)
        {
            User userDb = _userRepository.Get().ToList().FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (userDb == null)
                throw new UserNaoCadastradoException("Usuário não cadastrado!");

            var token = TokenService.GenerateToken(userDb);
            var refreshToken = TokenService.GenerateRefreshToken();
            TokenService.SaveRefreshToken(userDb.Nome, refreshToken);

            return new Tuple<string, string, string>(token, refreshToken, userDb.Nome);
        }



        public Tuple<string, string> RefreshToken(string token, string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var userName = principal.Identity.Name;
            var SaveRefreshToken = TokenService.GetRefreshToken(userName);

            if (SaveRefreshToken != refreshToken)
                throw new SecurityTokenException("Token Inválido!");

            var newToken = TokenService.GenerateToken(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(userName, refreshToken);
            TokenService.SaveRefreshToken(userName, newRefreshToken);

            return new Tuple<string, string>(newToken, newRefreshToken);
        }

       
    }
}
