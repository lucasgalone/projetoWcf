using BarbeariaWebApi.ServicoServiceReference;
using System.Linq;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class ServicoController : Controller
    {
        readonly ServiceServicoClient _wcf = new ServiceServicoClient();

        public ActionResult Index()
        {
            var servicos = _wcf.FindAll().ToList();

            return View(servicos);
        }

        public ActionResult Details(int id)
        {
            var servico = _wcf.Find(id);

            return View(servico);
        }

        public ActionResult Create(Servico servico)
        {
            if (servico.nome != null)
            {
                _wcf.New(servico);
                return RedirectToAction("", "Servico");
            }
            return View(servico);
        }

        public ActionResult Edit(int id, Servico servico)
        {
            if (servico.nome != null)
            {
                _wcf.Update(id, servico);
                return RedirectToAction("", "Servico");
            }
            else
            {
                servico = _wcf.Find(id);
            }
            return View(servico);
        }

        public ActionResult Delete(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("", "Servico");
        }
    }
}