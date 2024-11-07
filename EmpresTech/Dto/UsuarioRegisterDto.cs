using System.ComponentModel.DataAnnotations;

namespace EmpresTech.Dto;

public class UsuarioRegisterDto
{
    [Required(ErrorMessage = "Digite o nome!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o sobrenome!")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "Digite o email!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Digite a senha!")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Confirme a senha!"), Compare("Senha", ErrorMessage = "As senhas são diferentes")]
    public string ConfirmaSenha { get; set; }
}