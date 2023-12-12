using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosCasos;
using Lawyers.BLL.Services;
using Lawyers.DAL.Entities;
using Lawyers.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace Lawyers.WEB.Controllers
{
    public class CasosController : Controller
    {
        private readonly ICasosService _casosService;
        private readonly IClienteService _clientesService;
        private readonly IAbogadoService _abogadosService;
        private readonly ITiposDeCasosService _tiposDeCasosService;
        private readonly IEstadosCasosService _estadosCasosService;
        private readonly ILoggerService<CasosService> _loggerService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CasosController(ICasosService casosService, IClienteService clienteService,
                                IAbogadoService abogadoService, ITiposDeCasosService tiposDeCasosService,
                                IEstadosCasosService estadosCasosService, ILoggerService<CasosService> loggerService, IHttpContextAccessor httpContextAccessor,
                                IWebHostEnvironment webHostEnvironment)
        {
            _casosService = casosService;
            _clientesService = clienteService;
            _abogadosService = abogadoService;
            _tiposDeCasosService = tiposDeCasosService;
            _estadosCasosService = estadosCasosService;
            _loggerService = loggerService;
            _httpContextAccessor = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: CasosController


        public ActionResult Index(int? tipoCasoId, int? abogadoId, int? estadoCasoId)
        {
            var tiposCasos = _tiposDeCasosService.GetAll()?.Data;
            var abogados = _abogadosService.GetAll()?.Data;
            var estadosCasos = _estadosCasosService.GetAll()?.Data;

            ViewBag.TiposCasos = new SelectList(tiposCasos, "Id", "TipoDeCaso", tipoCasoId);
            ViewBag.Abogados = new SelectList(abogados, "Id", "Nombre", abogadoId);
            ViewBag.EstadosCasos = new SelectList(estadosCasos, "Id", "Estado", estadoCasoId);

            var Casos = (List<Lawyers.BLL.Models.CasosModel>)_casosService.GetAll().Data;

            var CasosViewModel = Casos.Select(x => new Lawyers.BLL.Dtos.DtosCasos.CasoIntermediarioDto
            {
                Id = x.Id,
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

            if (tipoCasoId.HasValue)
            {
                CasosViewModel = CasosViewModel.Where(x => x.IdTipoCaso == tipoCasoId).ToList();
            }

            if (abogadoId.HasValue)
            {
                CasosViewModel = CasosViewModel.Where(x => x.IdAbogado == abogadoId).ToList();
            }

            if (estadoCasoId.HasValue)
            {
                CasosViewModel = CasosViewModel.Where(x => x.IdEstadoCaso == estadoCasoId).ToList();
            }

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
            var casoResult = _casosService.GetById(id);

            if (casoResult.Success)
            {
                var casoModel = (Lawyers.BLL.Models.CasosModel)casoResult.Data;

                CasoIntermediarioDto casoAMostrar = new CasoIntermediarioDto()
                {
                    Id = casoModel.Id,
                    IdCliente = casoModel.IdCliente,
                    IdAbogado = casoModel.IdAbogado,
                    Descripcion = casoModel.Descripcion,
                    IdEstadoCaso = casoModel.IdEstadoCaso,
                    FechaCaso = casoModel.FechaCaso,
                    IdTipoCaso = casoModel.IdTipoCaso,
                    Latitud = casoModel.Latitud,
                    Longitud = casoModel.Longitud,
                    NombreAbogado = ObtenerNombreAbogado((int)casoModel.IdAbogado),
                    NombreCliente = ObtenerNombreCliente((int)casoModel.IdCliente),
                    EstadoCaso = ObtenerEstadoCaso((int)casoModel.IdEstadoCaso),
                    TipoCaso = ObtenerTipoCaso((int)casoModel.IdTipoCaso)
                };

 
                return View(casoAMostrar);
            }
            else
            {
                // Handle the case when the requested caso is not found
                return View("CasoNotFound");
            }
        }

        // GET: CasosController/Create
        public ActionResult Create()
        {
           ViewBag.Clientes = _clientesService.GetAll()?.Data;
            ViewBag.Abogados = _abogadosService.GetAll()?.Data;
            ViewBag.TiposCasos = _tiposDeCasosService.GetAll()?.Data;
            ViewBag.EstadosCasos = _estadosCasosService.GetAll()?.Data;
            return View();
        }

        // POST: CasosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DAL.Entities.Casos casos)
        {
            try
            {
                CasosSaveDto casosSave = new CasosSaveDto()
                {
                    Id = casos.Id,
                    FechaCaso = casos.FechaCaso,
                    IdCliente = casos.IdCliente,
                    IdTipoCaso = casos.IdTipoCaso,
                    Latitud = casos.Latitud,
                    Longitud = casos.Longitud,
                    IdAbogado = casos.IdAbogado,
                    Descripcion = casos.Descripcion,
                    IdEstadoCaso = casos.IdEstadoCaso
                };
                _casosService.Save(casosSave);
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
            ViewBag.Clientes = _clientesService.GetAll()?.Data;
            ViewBag.Abogados = _abogadosService.GetAll()?.Data;
            ViewBag.TiposCasos = _tiposDeCasosService.GetAll()?.Data;
            ViewBag.EstadosCasos = _estadosCasosService.GetAll()?.Data;
            var casoResult = _casosService.GetById(id);

           
                var casoModel = (Lawyers.BLL.Models.CasosModel)casoResult.Data;

            DAL.Entities.Casos casoAMostrar = new DAL.Entities.Casos()
                {
                    Id = casoModel.Id,
                    IdCliente = casoModel.IdCliente,
                    IdAbogado = casoModel.IdAbogado,
                    Descripcion = casoModel.Descripcion,
                    IdEstadoCaso = casoModel.IdEstadoCaso,
                    FechaCaso = casoModel.FechaCaso,
                    IdTipoCaso = casoModel.IdTipoCaso,
                    Latitud = casoModel.Latitud,
                    Longitud = casoModel.Longitud,
                };
                

                return View(casoAMostrar);
            
        }

        // POST: CasosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DAL.Entities.Casos casoEditar)
        {
            try
            {
                
                BLL.Dtos.DtosCasos.CasosUpdateDto casosUpdate = new BLL.Dtos.DtosCasos.CasosUpdateDto()
                {
                    Id = casoEditar.Id,
                    IdCliente = casoEditar.IdCliente,
                    IdAbogado = casoEditar.IdAbogado,
                    Descripcion = casoEditar.Descripcion,
                    IdEstadoCaso = casoEditar.IdEstadoCaso,
                    FechaCaso = casoEditar.FechaCaso,
                    IdTipoCaso = casoEditar.IdTipoCaso,
                    Latitud = casoEditar.Latitud,
                    Longitud = casoEditar.Longitud,
                };
                _loggerService.LogInformation(casosUpdate.ToString());
                _casosService.Update(casosUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Print(int Id)
        {
            var casoAimprimir = _casosService.GetById(Id).Data;
            BLL.Dtos.DtosCasos.CasoIntermediarioDto casoIntermediarioDto = new CasoIntermediarioDto()
            {
                Id = casoAimprimir.Id,
                IdCliente = casoAimprimir.IdCliente,
                IdAbogado = casoAimprimir.IdAbogado,
                Descripcion = casoAimprimir.Descripcion,
                IdEstadoCaso = casoAimprimir.IdEstadoCaso,
                FechaCaso = casoAimprimir.FechaCaso,
                IdTipoCaso = casoAimprimir.IdTipoCaso,
                Latitud = casoAimprimir.Latitud,
                Longitud = casoAimprimir.Longitud,
                NombreAbogado = ObtenerNombreAbogado((int)casoAimprimir.IdAbogado),
                NombreCliente = ObtenerNombreCliente((int)casoAimprimir.IdCliente),
                EstadoCaso = ObtenerEstadoCaso((int)casoAimprimir.IdEstadoCaso),
                TipoCaso = ObtenerTipoCaso((int)casoAimprimir.IdTipoCaso)
            };
            QuestPDF.Settings.License = LicenseType.Community;
            var data = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(30);
                    page.Header().ShowOnce().Row(row =>
                    {

                    var rutaImagen = Path.Combine(_webHostEnvironment.WebRootPath, "img/Logo.jpg");
                    byte[] imageBytes = System.IO.File.ReadAllBytes(rutaImagen);
                    row.ConstantItem(150).Image(imageBytes);

                        row.RelativeItem().Column(columnita =>
                        {
                            columnita.Item().Background("#FFF");
    
                        });
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().AlignRight().Height(20).Border(1).BorderColor("#257272").Text($"Fecha: {casoIntermediarioDto.FechaCaso}");
                            column.Item().AlignRight().Height(20).Background("#257272").Border(1).BorderColor("#257272").Text($"Estado del caso: {casoIntermediarioDto.EstadoCaso}").FontColor("#FFFFFF");
                        });
                    });
                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        column.Item().Text("Datos del caso:").Underline().Bold();

                        column.Item().Text(txt =>
                        {
                            txt.Span("Nombre del cliente: ").SemiBold().FontSize(10);
                            txt.Span(casoIntermediarioDto.NombreCliente).FontSize(10);
                        });
                        column.Item().Text(txt =>
                        {
                            txt.Span("Nombre del abogado: ").SemiBold().FontSize(10);
                            txt.Span(casoIntermediarioDto.NombreAbogado).FontSize(10);
                        });

                        column.Item().LineHorizontal(0.5f);

                        column.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnsTable =>
                            {
                                columnsTable.RelativeColumn(3);
                                columnsTable.RelativeColumn();
                                columnsTable.RelativeColumn();
                                columnsTable.RelativeColumn();
                                columnsTable.RelativeColumn();
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Background("#257272").Padding(2).Text("Descripcion").FontColor("#FFFFFF");
                                header.Cell().Background("#257272").Padding(2).Text("Tipo de caso").FontColor("#FFFFFF");
                                header.Cell().Background("#257272").Padding(2).Text("Estado del caso").FontColor("#FFFFFF");
                                header.Cell().Background("#257272").Padding(2).Text("Latitud").FontColor("#FFFFFF");
                                header.Cell().Background("#257272").Padding(2).Text("Longitud").FontColor("#FFFFFF");
                            });

                            tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Text(casoIntermediarioDto.Descripcion);
                            tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Text(casoIntermediarioDto.TipoCaso);
                            tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Text(casoIntermediarioDto.EstadoCaso);
                            tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Text(casoIntermediarioDto.Latitud.ToString());
                            tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9").Text(casoIntermediarioDto.Longitud.ToString());

                        });
                    });

                });
            }).GeneratePdf();

            Stream stream = new MemoryStream(data);

            return File(stream, "application/pdf", $"{casoIntermediarioDto.Id}{casoIntermediarioDto.NombreCliente}detalle.pdf");
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
