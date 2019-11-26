using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entity;

namespace ProjetoWCF
{
    public class ServiceCliente : IServiceCliente
    {
        private BarbeariaDoisEntities _db;

        public List<Cliente> FindAll()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<Cliente> clientes = _db.Cliente.Include("Sexo").ToList();
                return clientes;
            }
        }

        public Cliente Find(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                Cliente cliente = _db.Cliente.Include("Sexo").Single(x => x.id.Equals(id));
                return cliente;
            }
        }

        public Cliente New(Cliente cliente)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Cliente.Add(cliente);
                _db.SaveChanges();
                return cliente;
            }
        }

        public Cliente Update(int id, Cliente cliente)
        {
            using (_db = new BarbeariaDoisEntities())
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
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var cliente = _db.Cliente.Find(id);
                _db.Cliente.Remove(cliente);
                _db.SaveChanges();
                return cliente;
            }
        }

        public IEnumerable<ComboboxDto> FindAllCombobox()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var comboboxSexo = _db.Cliente.GroupBy(x=>x.Sexo.sexo1).Select(x=>x.FirstOrDefault()).Select(x => new ComboboxDto
                {
                    Id = x.Sexo.id,
                    Valor = x.Sexo.sexo1
                }).ToList();

                return comboboxSexo;
            }
        }
    }
}
