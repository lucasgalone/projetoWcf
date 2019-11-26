using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    public class ServiceProduto : IServiceProduto
    {
        private BarbeariaDoisEntities _db;

        public List<Produto> FindAll()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var produtos = _db.Produto.ToList();
                return produtos;
            }
        }

        public Produto Find(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var produto = _db.Produto.Single(x => x.id.Equals(id));
                return produto;
            }
        }

        public Produto New(Produto produto)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Produto.Add(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public Produto Update(int id, Produto produto)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var dbProduto = _db.Produto.Single(x => x.id.Equals(id));
                dbProduto.nome = produto.nome;
                dbProduto.preco = produto.preco;

                _db.SaveChanges();
                return dbProduto;
            }
        }

        public Produto Delete(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var produto = _db.Produto.Find(id);
                _db.Produto.Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }
    }
}
