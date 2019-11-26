using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    public class ServiceAgendamento : IServiceAgendamento
    {
        private BarbeariaDoisEntities _db;

        public List<Agendamento> FindAll()
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var agendamento = _db.Agendamento.Include("Cliente").Include("Prestador").ToList();
                return agendamento;
            }
        }

        public Agendamento Find(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var agendamento = _db.Agendamento.Include("Cliente").Include("Prestador").Single(x => x.id.Equals(id));
                return agendamento;
            }
        }

        public Agendamento New(Agendamento agendamento)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Agendamento.Add(agendamento);
                _db.SaveChanges();
                return agendamento;
            }
        }

        public Agendamento Update(int id, Agendamento agendamento)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var dbAgendamento= _db.Agendamento.Single(x => x.id.Equals(id));
                dbAgendamento.idcliente= agendamento.idcliente;
                dbAgendamento.idprestador = agendamento.idprestador;
                dbAgendamento.horario = agendamento.horario;

                _db.SaveChanges();
                return dbAgendamento;
            }
        }

        public Agendamento Delete(int id)
        {
            using (_db = new BarbeariaDoisEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var agendamento = _db.Agendamento.Find(id);
                _db.Agendamento.Remove(agendamento);
                _db.SaveChanges();
                return agendamento;
            }
        }
    }
}
