using Lawyers.BLL.Contracts;
using Lawyers.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lawyers.WEB.Controllers
{
    public class CasosController : Controller
    {
        private readonly ICasosService _casosService;
        private readonly IClienteService _clientesService;
        private readonly IAbogadoService _abogadosService;
        private readonly ITiposDeCasosService _tiposDeCasosService;
        private readonly IEstadosCasosService _estadosCasosService;
        public CasosController(ICasosService casosService,IClienteService clienteService, 
                                IAbogadoService abogadoService, ITiposDeCasosService tiposDeCasosService, 
                                IEstadosCasosService estadosCasosService) 
        { 
            _casosService = casosService;
            _clientesService = clienteService;
            _abogadosService = abogadoService;
            _tiposDeCasosService = tiposDeCasosService;
            _estadosCasosService = estadosCasosService;
        }
        // GET: CasosController
        public ActionResult Index()
        {
            var Casos = (List<Lawyers.BLL.Models.CasosModel>)_casosService.GetAll().Data;

            var CasosViewModel = Casos.Select(x => new Lawyers.BLL.Core.DtoCasosBase
            {
                IdCliente = x.IdCliente,
                IdAbogado = x.IdAbogado,
                Descripcion = x.Descripcion,
                IdEstadoCaso = x.IdEstadoCaso,
                FechaCaso = x.FechaCaso,
                IdTipoCaso = x.IdTipoCaso,
                Latitud = x.Latitud,
                Longitud = x.Longitud,
                NombreAbogado = ObtenerNombreAbogado((int)x.IdAbogado),
                NombreCliente = ObtenerNombreCliente((int)x.IdCliente),
                EstadoCaso = ObtenerEstadoCaso((int)x.IdEstadoCaso),
                TipoCaso = ObtenerTipoCaso((int)x.IdTipoCaso)

            }).ToList();
            return View(CasosViewModel);
        }
        private string ObtenerNombreCliente(int idCliente)
        {
            var cliente = _clientesService.GetById(idCliente).Data;
            return cliente != null ? $"{cliente.Nombre} {cliente.Apellido}" : "No encontrado";
        }

        private string ObtenerNombreAbogado(int idAbogado)
        {
            var abogado = _abogadosService.GetById(idAbogado).Data;
            return abogado != null ? $"{abogado.Nombre} {abogado.Apellido}" : "No encontrado";
        }

        private string ObtenerEstadoCaso(int idEstadoCaso)
        {
            var estadoCaso = _estadosCasosService.GetById(idEstadoCaso).Data;
            return estadoCaso != null ? estadoCaso.Estado : "No encontrado";
        }

        private string ObtenerTipoCaso(int idTipoCaso)
        {
            var tipoCaso = _tiposDeCasosService.GetById(idTipoCaso).Data;
            return tipoCaso != null ? tipoCaso.TipoDeCaso : "No encontrado";
        }

        // GET: CasosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CasosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CasosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CasosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CasosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CasosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CasosController/Delete/5
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
