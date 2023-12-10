using Lawyers.BLL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lawyers.WEB.Controllers
{
    public class CasosController : Controller
    {
        private readonly ICasosService _casosService;
        public CasosController(ICasosService casosService) { 
            _casosService = casosService;
        }
        // GET: CasosController
        public ActionResult Index()
        {
            var Casos = (List<Lawyers.BLL.Models.CasosModel>)_casosService.GetAll().Data;

            var CasosViewModel = Casos.Select(x => new Lawyers.DAL.Entities.Casos
            {
                IdCliente = x.IdCliente,
                IdAbogado = x.IdAbogado,
                Descripcion = x.Descripcion,
                IdEstadoCaso = x.IdEstadoCaso,
                FechaCaso = x.FechaCaso,
                IdTipoCaso = x.IdTipoCaso,
                Latitud = x.Latitud,
                Longitud = x.Longitud
            }).ToList();
            return View(CasosViewModel);
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
