using Data.DAL.Context;
using Lawyers.BLL.Contracts;
using Lawyers.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lawyers.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IEstadoCivilService _estadoCivilService;
        public ClientesController(IClienteService clienteService, IEstadoCivilService estadoCivilService) { 
            _clienteService = clienteService;
            _estadoCivilService = estadoCivilService;
        }
        // GET: ClientesController
        public ActionResult Index()
        {
            var clientes = (List<Lawyers.BLL.Models.ClientesModel>)_clienteService.GetAll().Data;
           
            var clientesViewModel = clientes.Select(x => new Lawyers.BLL.Dtos.DtosClientes.ClienteIntermediarioDto
            {
                Id = x.Id,
                Cedula = x.Cedula,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                celular = x.celular,
                correo = x.correo,
                EstadoCivil = ObtenerEstadoCivil((int)x.IdEstadoCivil)
            });
            return View(clientesViewModel);
        }

     
        private string ObtenerEstadoCivil(int idEstadoCivil)
        {
           var EstadoCivil = _estadoCivilService.GetById(idEstadoCivil).Data;
            return EstadoCivil != null ? $"{EstadoCivil.Descripcion}" : "No encontrado";
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {

            var clienteResult = _clienteService.GetById(id);
            if (clienteResult.Success)
            {
                var cliente = (Lawyers.BLL.Models.ClientesModel)clienteResult.Data;
                var clienteViewModel = new Lawyers.BLL.Dtos.DtosClientes.ClienteIntermediarioDto
                {
                    Id = cliente.Id,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    celular = cliente.celular,
                    correo = cliente.correo,
                    IdEstadoCivil = cliente.IdEstadoCivil,
                    EstadoCivil = ObtenerEstadoCivil((int)cliente.IdEstadoCivil)
                };

                return View(clienteViewModel);
            }
            else
            {
                return View("Cliente no encontrado");
            }
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            ViewBag.EstadoCivil = _estadoCivilService.GetAll().Data;
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DAL.Entities.Clientes cliente)
        {
            try
            {
                BLL.Dtos.DtosClientes.ClientesSaveDto clienteSave = new BLL.Dtos.DtosClientes.ClientesSaveDto()
                {
                    Id  = cliente.Id,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    celular = cliente.celular,
                    correo = cliente.correo,
                    IdEstadoCivil = cliente.IdEstadoCivil,
                };
                _clienteService.Save(clienteSave);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var clienteResult = _clienteService.GetById(id);
            if (clienteResult.Success)
            {
                var cliente = (Lawyers.BLL.Models.ClientesModel)clienteResult.Data;
                var clienteViewModel = new Lawyers.DAL.Entities.Clientes
                {
                    Id = cliente.Id,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    celular = cliente.celular,
                    correo = cliente.correo,
                    IdEstadoCivil = cliente.IdEstadoCivil,
                    
                };

                return View(clienteViewModel);
            }
            else
            {
                return View("Cliente no encontrado");
            } 
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clientes cliente)
        {
            try
            {
                BLL.Dtos.DtosClientes.ClientesUpdateDto clienteUpdate = new BLL.Dtos.DtosClientes.ClientesUpdateDto()
                {
                    Id = cliente.Id,
                    Cedula = cliente.Cedula,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    celular = cliente.celular,
                    correo = cliente.correo,
                    IdEstadoCivil = cliente.IdEstadoCivil,
                };
                _clienteService.Update(clienteUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
