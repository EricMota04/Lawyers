using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Models;
using Lawyers.BLL.Dtos.DtosCasos;
using Lawyers.BLL.Responses.CasosResponses;
using Lawyers.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lawyers.BLL.Validations;
using Lawyers.DAL.Interfaces;

namespace Lawyers.BLL.Services
{
    public class CasosService : ICasosService
    {
        private readonly ICasosRepository _casosRepository;
        private readonly ILoggerService<CasosService> _loggerService;
        public CasosService(ICasosRepository casosRepository, ILoggerService<CasosService> loggerService)
        {
            _casosRepository = casosRepository;
            _loggerService = loggerService;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var query = (from casos in this._casosRepository.GetEntities()
                             select new CasosModel
                             {
                                 Id = casos.Id,
                                 FechaCaso = casos.FechaCaso,
                                 IdCliente = casos.IdCliente,
                                 IdTipoCaso = casos.IdTipoCaso,
                                 Latitud = casos.Latitud,
                                 Longitud = casos.Longitud,
                                 IdAbogado = casos.IdAbogado,
                                 Descripcion = casos.Descripcion,
                                 IdEstadoCaso = casos.IdEstadoCaso,
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los casos";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                DAL.Entities.Casos casos = _casosRepository.GetEntity(Id);
                CasosModel casosModel = new CasosModel
                {
                    Id = casos.Id,
                    FechaCaso = casos.FechaCaso,
                    IdCliente = casos.IdCliente,
                    IdTipoCaso = casos.IdTipoCaso,
                    Latitud = casos.Latitud,
                    Longitud = casos.Longitud,
                    IdAbogado = casos.IdAbogado,
                    Descripcion = casos.Descripcion,
                    IdEstadoCaso = casos.IdEstadoCaso,
                };
                result.Data = casosModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el caso";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public CasosSaveResponse Save(CasosSaveDto casosSaveDto)
        {
            CasosSaveResponse result = new CasosSaveResponse();
            var validCaso = CasosValidations.IsValidCaso(casosSaveDto, _casosRepository);
            try
            {
                if (validCaso.Success)
                {
                    DAL.Entities.Casos casos = new DAL.Entities.Casos
                    {
                        FechaCaso = casosSaveDto.FechaCaso,
                        IdCliente = casosSaveDto.IdCliente,
                        IdTipoCaso = casosSaveDto.IdTipoCaso,
                        Latitud = casosSaveDto.Latitud,
                        Longitud = casosSaveDto.Longitud,
                        IdAbogado = casosSaveDto.IdAbogado,
                        Descripcion = casosSaveDto.Descripcion,
                        IdEstadoCaso = casosSaveDto.IdEstadoCaso,
                    };
                    _casosRepository.Save(casos);
                }
                else{
                    result.Success = false;
                    result.Message = validCaso.Message;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error guardando el caso";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public CasosUpdateResponse Update(CasosUpdateDto casosUpdateDto)
        {
            CasosUpdateResponse result = new CasosUpdateResponse();
            var validCaso = CasosValidations.IsValidCaso(casosUpdateDto, _casosRepository);

            try
            {
                if (validCaso.Success)
                {
                    DAL.Entities.Casos casos = new DAL.Entities.Casos
                    {
                        Id = casosUpdateDto.Id,
                        FechaCaso = casosUpdateDto.FechaCaso,
                        IdCliente = casosUpdateDto.IdCliente,
                        IdTipoCaso = casosUpdateDto.IdTipoCaso,
                        Latitud = casosUpdateDto.Latitud,
                        Longitud = casosUpdateDto.Longitud,
                        IdAbogado = casosUpdateDto.IdAbogado,
                        Descripcion = casosUpdateDto.Descripcion,
                        IdEstadoCaso = casosUpdateDto.IdEstadoCaso,
                    };
                    _casosRepository.Update(casos);
                }
                else
                {
                    result.Success = false;
                    result.Message = validCaso.Message;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando el caso";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
