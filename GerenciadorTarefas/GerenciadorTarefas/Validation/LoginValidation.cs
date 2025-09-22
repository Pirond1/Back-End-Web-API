using Dominio.DTOs;
using FluentValidation;

namespace GerenciadorTarefas.Validation
{
    public class LoginValidation: AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(p => p.usuario)
                .MaximumLength(20)
                .WithMessage("O Usuáriop Precisa Ter no Máximo 20 Caracteres!");
            RuleFor(p => p.usuario)
                .NotEmpty()
                .WithMessage("O Usuário Não Pode Ser Vazio!");
            RuleFor(p => p.usuario)
                .NotNull()
                .WithMessage("O Usuário Não Pode Ser Vazio!");

            RuleFor(p => p.senha)
                .MaximumLength(50)
                .WithMessage("A Senha Precisa Ter no Máximo 50 Caracteres!");
            RuleFor(p => p.senha)
                .MinimumLength(3)
                .WithMessage("A Senha Precisa Ter no Mínimo 3 Caracteres!");
            RuleFor(p => p.senha)
                .NotEmpty()
                .WithMessage("A Senha Não Pode Ser Vazia!");
            RuleFor(p => p.senha)
                .NotNull()
                .WithMessage("A Senha Não Pode Ser Vazia!");
        }
    }
}
