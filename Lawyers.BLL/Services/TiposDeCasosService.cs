using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Models;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Services
{
    public class TiposDeCasosService : ITiposDeCasosService
    {
        private readonly ITiposDeCasosRepository _tiposDeCasosRepository;
        private readonly ILoggerService<TiposDeCasosService> _loggerService;
        public TiposDeCasosService(ITiposDeCasosRepository tiposDeCasosRepository, ILoggerService<TiposDeCasosService> loggerService)
        {
            _loggerService = loggerService;
            _tiposDeCasosRepository = tiposDeCasosRepository;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from tiposDeCasos in this._tiposDeCasosRepository.GetEntities()
                             select new TiposDeCasosModel
                             {
                                 Id = tiposDeCasos.Id,
                                 TipoDeCaso = tiposDeCasos.TipoDeCaso
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los tipos de casos";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.TiposDeCasos tiposDeCasos = _tiposDeCasosRepository.GetEntity(Id);
                TiposDeCasosModel tiposDeCasosModel = new TiposDeCasosModel
                {
                    Id = tiposDeCasos.Id,
                    TipoDeCaso = tiposDeCasos.TipoDeCaso
                };
                result.Data = tiposDeCasosModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el tipo de caso";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
