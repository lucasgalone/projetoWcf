using BarbeariaWebApi.ClientesServiceReference;
using System.Linq;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class ClienteController : Controller
    {

        readonly ServiceClienteClient _wcf = new ServiceClienteClient();

        public ActionResult Index()
        {
            var clientes = _wcf.FindAll().ToList();

            return View(clientes);
        }

        public ActionResult Details(int id)
        {
            var cliente = _wcf.Find(id);

            return View(cliente);
        }

        public ActionResult Create(Cliente cliente)
        {
            if(cliente.nome != null)
            {
                _wcf.New(cliente);
                return RedirectToAction("", "Cliente");
            }
            var combobox = _wcf.FindAllCombobox();

            ViewBag.Accounts = new SelectList(combobox, "Id", "Valor");

            return View(cliente);
        }

        public ActionResult Edit(int id, Cliente cliente)
        {
            if(cliente.nome != null)
            {
                _wcf.Update(id,cliente);
                return RedirectToAction("", "Cliente");
            }
            else
            {
                cliente = _wcf.Find(id);
                var combobox = _wcf.FindAllCombobox();

                ViewBag.Accounts = new SelectList(combobox, "Id", "Valor");
            }

            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("", "Cliente");
        }
    }
}