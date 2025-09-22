using Dominio.DTOs;
using FluentValidation;

namespace GerenciadorTarefas.Validation
{
    public class TarefaValidation: AbstractValidator<TarefaDTO>
    {
        public TarefaValidation()
        {
            RuleFor(p => p.titulo)
                .MaximumLength(100)
                .WithMessage("O Título Precisa Ter no Máximo 100 Caracteres!");
            RuleFor(p => p.titulo)
                .NotEmpty()
                .WithMessage("O Título Não Pode Ser Vazio!");
            RuleFor(p => p.titulo)
                .NotNull()
                .WithMessage("O Título Não Pode Ser Vazio!");

            RuleFor(p => p.descricao)
                .NotEmpty()
                .WithMessage("A Descrição Não Pode Ser Vazia!");
            RuleFor(p => p.descricao)
                .NotNull()
                .WithMessage("A Descrição Não Pode Ser Vazia!");

            RuleFor(p => p.status)
                .NotEmpty()
                .WithMessage("O Status Não Pode Ser Vazio!");
            RuleFor(p => p.status)
                .NotNull()
                .WithMessage("O Status Não Pode Ser Vazio!");
        }
    }
}
