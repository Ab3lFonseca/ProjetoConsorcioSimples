using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class ConsorcioRequest
    {
        public long id { get; set; }
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; }
        public double valor { get; set; }
        public string categoria { get; set; }
        public int parcelas { get; set; }


        public ConsorcioRequest() { }

        // Adicionando um construtor para resolver o erro CS7036  
        public ConsorcioRequest(string descricao, DateTime data, double valor, string categoria, int parcelas)
        {
            this.descricao = descricao;
            this.dataCriacao = data;
            this.valor = valor;
            this.categoria = categoria;
            this.parcelas = parcelas;
        }
    }
}
