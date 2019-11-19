using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    public class ServiceCliente : IServiceCliente
    {
        private BarbeariaEntities _db;

        public List<Cliente> FindAll()
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<Cliente> clientes = _db.Cliente.ToList();
                return clientes;
            }
        }

        public Cliente Find(int id)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Cliente cliente = _db.Cliente.Single(x => x.id.Equals(id));
                return cliente;
            }
        }

        public Cliente New(Cliente cliente)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                return cliente;
            }
        }

        public Cliente Update(int id, Cliente cliente)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var dbCliente = _db.Cliente.Single(x => x.id.Equals(id));
                dbCliente.idsexo = cliente.idsexo;
                dbCliente.nome = cliente.nome;
                dbCliente.telefone = cliente.telefone;
                dbCliente.cpf = cliente.cpf;

                _db.SaveChanges();
                return cliente;
            }
        }

        public Cliente Delete(int id)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var cliente = _db.Cliente.Find(id);
                _db.Cliente.Remove(cliente);
                _db.SaveChanges();
                return cliente;
            }
        }
    }
}
