using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    public class ServiceVenda : IServiceVenda
    {
        private BarbeariaDoisEntities _db;

        public List<Venda> FindAll()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var vendas = _db.Venda.Include("Cliente").Include("Prestador").ToList();
                return vendas;
            }
        }

        public VendaDto Find(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var venda = _db.Venda.Where(x => x.id.Equals(id)).Select(x => new VendaDto
                {
                    Id = x.id,
                    Total = x.total,
                    NomeCliente = x.Cliente.nome,
                    NomePrestador = x.Prestador.nome,
                    ListaProduto = x.ProdutoVenda.Select(z => z.Produto).Select(y => new ProdutoDto
                    {
                        Id = y.id,
                        Nome = y.nome,
                        Preco = y.preco
                    }).ToList(),
                    ListaServico = x.ServicoVenda.Select(z => z.Servico).Select(y => new ServicoDto
                    {
                        Id = y.id,
                        Nome = y.nome,
                        Preco = y.preco
                    }).ToList()
                }).FirstOrDefault();

                return venda;
            }
        }

        public Venda New(Venda venda)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Venda.Add(venda);
                _db.SaveChanges();
                return venda;
            }
        }


        public IEnumerable<ComboboxDto> FindAllComboboxCliente()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var comboboxCliente = _db.Cliente.Select(x => new ComboboxDto
                {
                    Id = x.id,
                    Valor = x.nome
                }).ToList();

                return comboboxCliente;
            }
        }


        public IEnumerable<ComboboxDto> FindAllComboboxPrestador()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var comboboxPrestador= _db.Prestador.Select(x => new ComboboxDto
                {
                    Id = x.id,
                    Valor = x.nome
                }).ToList();

                return comboboxPrestador;
            }
        }

        public IEnumerable<Produto> FindAllProdutos()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var produtos = _db.Produto.ToList();

                return produtos;
            }
        }

        public IEnumerable<Servico> FindAllServicos()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var servicos = _db.Servico.ToList();

                return servicos;
            }
        }
    }
}
