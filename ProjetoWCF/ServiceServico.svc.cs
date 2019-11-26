using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    public class ServiceServico : IServiceServico
    {
        private BarbeariaDoisEntities _db;

        public List<Servico> FindAll()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var servicos = _db.Servico.ToList();
                return servicos;
            }
        }

        public Servico Find(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var servico = _db.Servico.Single(x => x.id.Equals(id));
                return servico;
            }
        }

        public Servico New(Servico servico)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Servico.Add(servico);
                _db.SaveChanges();
                return servico;
            }
        }

        public Servico Update(int id, Servico servico)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var dbServico = _db.Servico.Single(x => x.id.Equals(id));
                dbServico.nome = servico.nome;
                dbServico.preco = servico.preco;

                _db.SaveChanges();
                return dbServico;
            }
        }

        public Servico Delete(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var servico = _db.Servico.Find(id);
                _db.Servico.Remove(servico);
                _db.SaveChanges();
                return servico;
            }
        }
    }
}
