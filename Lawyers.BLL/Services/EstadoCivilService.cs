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
    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly IEstadoCivilRepository _estadoCivilRepository;
        private readonly ILoggerService<EstadoCivilService> _loggerService;
        public EstadoCivilService(IEstadoCivilRepository estadoCivilRepository, ILoggerService<EstadoCivilService> loggerService)
        {
            _loggerService = loggerService;
            _estadoCivilRepository = estadoCivilRepository;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from estadoCivil in this._estadoCivilRepository.GetEntities()
                              select new EstadoCivilModel
                              {
                                 IdEstadoCivil = estadoCivil.IdEstadoCivil,
                                 Descripcion = estadoCivil.Descripcion
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los estados civiles";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.EstadoCivil estadoCivil = _estadoCivilRepository.GetEntity(Id);
                EstadoCivilModel estadoCivilModel = new EstadoCivilModel
                {
                    IdEstadoCivil = estadoCivil.IdEstadoCivil,
                    Descripcion = estadoCivil.Descripcion
                };
                result.Data = estadoCivilModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el estado civil";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
