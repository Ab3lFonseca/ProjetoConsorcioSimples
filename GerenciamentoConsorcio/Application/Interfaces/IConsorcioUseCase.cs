using Application.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IConsorcioUseCase
    {
        public void AdicionarConsorcio(ConsorcioRequest ConsorcioRequest);

        public void AtualizarConsorcio(int id, ConsorcioRequest ConsorcioRequest);

        public void ExcluirConsorcio(int id);

        public ConsorcioRequest BuscarConsorcio(int id);
        public List<ConsorcioRequest> BuscarTodosConsorcios();
    }
}
