using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Enuns;


namespace SolaryEnergia.Domain.Services
{
    public static class ConvertRole
    {
        public static RoleDto ToDto(UserDto user)
        {
            return new RoleDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Role = user.Role.GetName()
            };
        }
        public static IList<RoleDto> ToDto(IList<UserDto> listDto)
        {
            return listDto.Select(r => ToDto(r)).ToList();

        }
    }
}
