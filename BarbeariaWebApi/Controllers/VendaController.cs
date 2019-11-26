using BarbeariaWebApi.VendaReference;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class VendaController : Controller
    {
        readonly ServiceVendaClient _wcf = new ServiceVendaClient();

        public ActionResult Index()
        {
            var vendas = _wcf.FindAll().ToList();

            return View(vendas);
        }

        public ActionResult Details(int id)
        {
            var venda = _wcf.Find(id);

            return View(venda);
        }

        public ActionResult Create(VendaDto dto)
        {
            if (dto.IdCliente != 0)
            {
                //_wcf.New(servico);
                return RedirectToAction("", "Servico");
            }

            var comboboxCliente = _wcf.FindAllComboboxCliente();
            var comboboxPrestador = _wcf.FindAllComboboxPrestador();
            var produtos = _wcf.FindAllProdutos();
            var servicos = _wcf.FindAllServicos();

            ViewBag.Produtos = new List<Produto>(produtos);
            ViewBag.Servicos = new List<Servico>(servicos);
            ViewBag.ComboboxClientes = new SelectList(comboboxCliente, "Id", "Valor");
            ViewBag.ComboboxPrestadores = new SelectList(comboboxPrestador, "Id", "Valor");

            return View(dto);
        }
    }
}