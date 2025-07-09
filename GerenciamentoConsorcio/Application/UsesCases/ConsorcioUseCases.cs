using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Domain.Interfaces;

public class ConsorcioUseCases : IConsorcioUseCase
{
    private readonly IConsorcioEntidade _ConsorcioEntidade;

    public ConsorcioUseCases(IConsorcioEntidade adicionarConsorcioEntidade)
    {
        _ConsorcioEntidade = adicionarConsorcioEntidade;
    }

    public void AdicionarConsorcio(ConsorcioRequest consorcio)
    {
        var consorcioDomain = new ConsorcioDomain(
            consorcio.descricao,
            consorcio.dataCriacao,
            consorcio.valor,
            consorcio.categoria,
            consorcio.parcelas
        );

        _ConsorcioEntidade.Adicionar(consorcioDomain);
    }

    public void AtualizarConsorcio(int id, ConsorcioRequest consorcio)
    {
        var consorcioDomain = new ConsorcioDomain(
            id,
            consorcio.descricao,
            consorcio.dataCriacao,
            consorcio.valor,
            consorcio.categoria,
            consorcio.parcelas
        );

        _ConsorcioEntidade.Atualizar(id, consorcioDomain);
    }

    public ConsorcioRequest BuscarConsorcio(int id)
    {
        var domain = _ConsorcioEntidade.Buscar(id);

        return new ConsorcioRequest
        {
            id = domain.Id,
            descricao = domain.Descricao,
            dataCriacao = domain.dataCriacao,
            valor = domain.Valor,
            categoria = domain.Categoria, 
            parcelas = domain.Parcelas
        };
    }

    public List<ConsorcioRequest> BuscarTodosConsorcios()
    {
        var listaDomain = _ConsorcioEntidade.BuscarTodos();

        var listaRequest = listaDomain.Select(domain => new ConsorcioRequest
        {
            id = domain.Id,
            descricao = domain.Descricao,
            dataCriacao = domain.dataCriacao,
            valor = domain.Valor,
            categoria = domain.Categoria,
            parcelas = domain.Parcelas
        }).ToList();

        return listaRequest;
    }

    public void ExcluirConsorcio(int id)
    {
        _ConsorcioEntidade.Excluir(id);
    }
}
