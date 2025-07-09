namespace Domain.Entities
{
    public class ConsorcioDomain
    {
        public long Id { get; private set; }  // Ou Guid se você usar GUID no banco
        public string Descricao { get; private set; }
        public DateTime dataCriacao { get; private set; }
        public double Valor { get; private set; }
        public string Categoria { get; private set; }

        public int Parcelas { get; private set; }

        // Construtor para criação de novo consórcio (sem ID ainda)
        public ConsorcioDomain(string descricao, DateTime data, double valor, string categoria, int parcelas)
        {
            Descricao = descricao;
            dataCriacao = data;
            Valor = valor;
            Categoria = categoria;
            Parcelas = parcelas;
        }

        // Construtor completo (usado para buscas, updates, etc.)
        public ConsorcioDomain(int id, string descricao, DateTime data, double valor, string categoria, int parcelas)
        {
            Id = id;
            Descricao = descricao;
            dataCriacao = data;
            Valor = valor;
            Categoria = categoria;
            Parcelas = parcelas;
        }

        public ConsorcioDomain() { }


        // Métodos para atualizar (opcional, mas útil)
        public void Atualizar(string descricao, DateTime data, double valor, string categoria, int parcelas)
        {
            Descricao = descricao;
            dataCriacao = data;
            Valor = valor;
            Categoria = categoria;
            Parcelas = parcelas;
        }
    }
}
