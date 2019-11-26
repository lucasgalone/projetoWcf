using BarbeariaWebApi.AgendamentoServiceReference;
using BarbeariaWebApi.VendaReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarbeariaWebApi.Controllers
{
    public class AgendamentoController : Controller
    {
        readonly ServiceAgendamentoClient _wcf = new ServiceAgendamentoClient();
        readonly ServiceVendaClient _wcfVenda = new ServiceVendaClient();

        public ActionResult Index()
        {
            var agendamentos = _wcf.FindAll().ToList();

            return View(agendamentos);
        }

        public ActionResult Details(int id)
        {
            var agendamento = _wcf.Find(id);

            return View(agendamento);
        }

        public ActionResult Create(AgendamentoServiceReference.Agendamento agendamento)
        {
            if (agendamento.idcliente != 0)
            {
                _wcf.New(agendamento);
                return RedirectToAction("", "Agendamento");
            }

            var comboboxCliente = _wcfVenda.FindAllComboboxCliente();
            var comboboxPrestador = _wcfVenda.FindAllComboboxPrestador();
            ViewBag.ComboboxClientes = new SelectList(comboboxCliente, "Id", "Valor");
            ViewBag.ComboboxPrestadores = new SelectList(comboboxPrestador, "Id", "Valor");

            return View(agendamento);
        }

        public ActionResult Edit(int id, AgendamentoServiceReference.Agendamento agendamento)
        {
            if (agendamento.idcliente != 0)
            {
                _wcf.Update(id, agendamento);
                return RedirectToAction("", "Agendamento");
            }
            else
            {
                agendamento = _wcf.Find(id);
                var comboboxCliente = _wcfVenda.FindAllComboboxCliente();
                var comboboxPrestador = _wcfVenda.FindAllComboboxPrestador();
                ViewBag.ComboboxClientes = new SelectList(comboboxCliente, "Id", "Valor");
                ViewBag.ComboboxPrestadores = new SelectList(comboboxPrestador, "Id", "Valor");
            }
            return View(agendamento);
        }

        public ActionResult Delete(int id)
        {
            _wcf.Delete(id);
            return RedirectToAction("", "Agendamento");
        }
    }
}