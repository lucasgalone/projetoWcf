using BarbeariaWebApi.PrestadorServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class PrestadorController : Controller
    {

        readonly ServicePrestadorClient _wcf = new ServicePrestadorClient();

        public ActionResult Index()
        {
            var prestadores = _wcf.FindAll().ToList();
            var result = prestadores.Count > 0 ? prestadores : new List<Prestador>();

            return View(result);
        }

        public ActionResult Details(int id)
        {
            var prestador = _wcf.Find(id);

            return View(prestador);
        }

        public ActionResult Create(Prestador prestador)
        {
            if (prestador.nome != null)
            {
                _wcf.New(prestador);
                return RedirectToAction("", "Prestador");
            }
            return View(prestador);
        }

        public ActionResult Edit(int id, Prestador prestador)
        {
            if (prestador.nome != null)
            {
                _wcf.Update(id, prestador);
                return RedirectToAction("", "Prestador");
            }
            else
            {
                prestador = _wcf.Find(id);
            }
            return View(prestador);
        }

        public ActionResult Delete(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("", "Prestador");
        }
    }
}