using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class VendaDto
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public int IdCliente { get; set; }
        public int IdPrestador { get; set; }
        public string NomeCliente { get; set; }
        public string NomePrestador { get; set; }
        public List<ProdutoDto> ListaProduto{ get; set; }
        public List<ServicoDto> ListaServico{ get; set; }
    }
}
