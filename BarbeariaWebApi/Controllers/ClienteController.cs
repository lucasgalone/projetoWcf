using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BarbeariaWebApi.ClienteServiceReference;

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

        public ActionResult Create()
        {
            var cliente = new Cliente();
            return View(cliente);
        }

        public ActionResult Edit(int id)
        {
            var cliente = _wcf.Find(id);
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _wcf.Find(id);
            return View(cliente);
        }
    }
}