using BarbeariaWebApi.ProdutoServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class ProdutoController : Controller
    {
        readonly ServiceProdutoClient _wcf = new ServiceProdutoClient();

        public ActionResult Index()
        {
            IEnumerable<Produto> produtos = _wcf.FindAll().ToList();

            return View(produtos);
        }

        public ActionResult Details(int id)
        {
            var produto = _wcf.Find(id);

            return View(produto);
        }

        public ActionResult Create(Produto produto)
        {
            if (produto.nome != null)
            {
                _wcf.New(produto);
                return RedirectToAction("", "Produto");
            }
            return View(produto);
        }

        public ActionResult Edit(int id, Produto produto)
        {
            if (produto.nome != null)
            {
                _wcf.Update(id, produto);
                return RedirectToAction("", "Produto");
            }
            else
            {
                produto = _wcf.Find(id);
            }
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("", "Produto");
        }
    }
}