using Dominio.DTOs;
using FluentValidation;

namespace GerenciadorTarefas.Validation
{
    public class TipoTarefaValidation: AbstractValidator<TipoTarefaDTO>
    {
        public TipoTarefaValidation()
        {
            RuleFor(p => p.nome)
                .MaximumLength(20)
                .WithMessage("O Nome Precisa Ter no Máximo 20 Caracteres!");
            RuleFor(p => p.nome)
                .NotEmpty()
                .WithMessage("O Nome Não Pode Ser Vazio!");
            RuleFor(p => p.nome)
                .NotNull()
                .WithMessage("O Nome Não Pode Ser Vazio!");
        }
    }
}
