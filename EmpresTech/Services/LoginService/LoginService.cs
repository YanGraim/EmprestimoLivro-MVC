using EmpresTech.Data;
using EmpresTech.Dto;
using EmpresTech.Models;
using EmpresTech.Services.SenhaService;
using Exception = System.Exception;

namespace EmpresTech.Services.LoginService;

public class LoginService : ILoginInterface
{
    private readonly ApplicationDbContext _context;
    private readonly ISenhaInterface _senhaInterface;

    public LoginService(ApplicationDbContext context, ISenhaInterface senhaInterface)
    {
        _context = context;
        _senhaInterface = senhaInterface;
    }


    public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
    {
        ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

        try
        {
            if (verificarEmail(usuarioRegisterDto))
            {
                response.Mensagem = "Email já cadastrado";
                response.Status = false;
                return response;
            }

            _senhaInterface.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            var usuario = new UsuarioModel()
            {
                Nome = usuarioRegisterDto.Nome,
                Sobrenome = usuarioRegisterDto.Sobrenome,
                Email = usuarioRegisterDto.Email,
                SenhaHash = senhaHash,
                SenhaSalt = senhaSalt
            };

            _context.Add(usuario);
            await _context.SaveChangesAsync();

            response.Mensagem = "Usuário cadastrado com sucesso!";

            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            response.Status = false;
            return response;
        }
    }


    private bool verificarEmail(UsuarioRegisterDto usuarioRegisterDto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDto.Email);

        if (usuario == null)
            return false;
        return true;
    }
}