using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Models;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Services
{
    public class EstadosCasosService : IEstadosCasosService
    {
        private readonly IEstadosCasosRepository _estadosCasosRepository;
        private readonly ILoggerService<EstadosCasosService> _loggerService;
        public EstadosCasosService(IEstadosCasosRepository estadosCasosRepository, ILoggerService<EstadosCasosService> loggerService)
        {
            _loggerService = loggerService;
            _estadosCasosRepository = estadosCasosRepository;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from estadosCasos in this._estadosCasosRepository.GetEntities()
                             select new EstadosCasosModel
                             {
                                 Id = estadosCasos.Id,
                                 Estado = estadosCasos.Estado
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los estados de los casos";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.EstadosCasos estadosCasos = _estadosCasosRepository.GetEntity(Id);
                EstadosCasosModel estadosCasosModel = new EstadosCasosModel
                {
                    Id = estadosCasos.Id,
                    Estado = estadosCasos.Estado
                };
                result.Data = estadosCasosModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el estado del caso";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
