using System.Collections.Generic;
using System.Linq;


namespace ProjetoWCF
{
    public class ServicePrestador : IServicePrestador
    {
        private BarbeariaEntities _db;

        public List<Prestador> FindAll()
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var prestadores = _db.Prestador.ToList();
                return prestadores;
            }
        }

        public Prestador Find(int id)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var prestador = _db.Prestador.Single(x => x.id.Equals(id));
                return prestador;
            }
        }

        public Prestador New(Prestador prestador)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Prestador.Add(prestador);
                _db.SaveChanges();
                return prestador;
            }
        }

        public Prestador Update(int id, Prestador prestador)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var dbPrestador = _db.Prestador.Single(x => x.id.Equals(id));
                dbPrestador.idespecialidade= prestador.idespecialidade;
                dbPrestador.nome = prestador.nome;
                dbPrestador.Venda = prestador.Venda;

                _db.SaveChanges();
                return prestador;
            }
        }

        public Prestador Delete(int id)
        {
            using (_db = new BarbeariaEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                var prestador = _db.Prestador.Find(id);
                _db.Prestador.Remove(prestador);
                _db.SaveChanges();
                return prestador;
            }
        }
    }
}
