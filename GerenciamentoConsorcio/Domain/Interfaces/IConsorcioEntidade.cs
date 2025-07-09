using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConsorcioEntidade
    {
        void Adicionar(ConsorcioDomain consorcioDomain);

         void Atualizar(int id, ConsorcioDomain ConsorcioRequest);

         void Excluir(int id);

         ConsorcioDomain Buscar(int id);

         List<ConsorcioDomain> BuscarTodos();
    }
}
