using Application.Request;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace WebApi.Validation
{
    public class ValidarRequisicaoConsorcio : AbstractValidator<ConsorcioRequest>
    {
        public ValidarRequisicaoConsorcio()
        {
            RuleFor(c => c.descricao).NotEmpty().WithMessage("Descrição é obrigatória."); ;
            RuleFor(c => c.dataCriacao).NotEmpty().WithMessage("Data é inválida."); ;
            RuleFor(c => c.valor).NotEmpty().WithMessage("Valor é obrigatória."); ;
            RuleFor(c => c.categoria).NotEmpty().WithMessage("Categoria é obrigatória."); ;
            RuleFor(c => c.parcelas).NotEmpty().WithMessage("Parcelas é obrigatório."); ;
        }
    }
}
