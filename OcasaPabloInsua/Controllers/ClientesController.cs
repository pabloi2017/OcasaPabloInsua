using OcasaPabloInsua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OcasaPabloInsua.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {

            IEnumerable<Cliente> models;

            using(Test1Entities context = new Test1Entities())
            {
                models = context.Cliente.Select(x => x).ToList();
            }

            return View(models);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.error = null;
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            ViewBag.error = null;
            try
            {
                using(Test1Entities context = new Test1Entities())
                {
                    var result = context.sp_ConsultarCliente(cliente.IdCliente).First();
                    if (result <= 0 && ModelState.IsValid)
                    {
                        context.sp_InsertarCliente(cliente.IdCliente, cliente.RazonSocial, cliente.Direccion);
                    }
                    else
                    {
                        ViewBag.error = "Ya existe un cliente con el id ingresado";
                        return View(cliente);
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            //Cliente model;
            if (!(id == null))
            {
                using (Test1Entities context = new Test1Entities())
                {
                    var model = context.Cliente.FirstOrDefault(x => x.IdCliente == id);
                    if (!(model == null))
                    {
                        return View(model);
                    }
                }
            }
            
            return RedirectToAction("Index");
                        
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
                try
                {
                    if (!(cliente == null && ModelState.IsValid))
                    {
                        using (Test1Entities context = new Test1Entities())
                        {
                            context.sp_ActualizarCliente(id, cliente.RazonSocial, cliente.Direccion);
                        }
                    } 
                    
                } catch 
                {
                    return View();
                }

                return RedirectToAction("Index");
            
        }

    }
}
