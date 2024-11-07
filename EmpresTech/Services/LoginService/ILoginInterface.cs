using EmpresTech.Dto;
using EmpresTech.Models;

namespace EmpresTech.Services.LoginService;

public interface ILoginInterface
{
    Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
}