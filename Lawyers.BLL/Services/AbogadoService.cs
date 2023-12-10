using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosAbogados;
using Lawyers.BLL.Models;
using Lawyers.BLL.Responses.AbogadosResponses;
using Lawyers.BLL.Validations;
using Lawyers.DAL.Interfaces;

namespace Lawyers.BLL.Services
{
    public class AbogadoService : IAbogadoService
    {
        private readonly IAbogadosRepository _abogadoRepository;
        private readonly ILoggerService<AbogadoService> _loggerService;
        public AbogadoService(IAbogadosRepository abogadoRepository, 
                              ILoggerService<AbogadoService> loggerService) 
        {
            _abogadoRepository = abogadoRepository;
            _loggerService = loggerService;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try { 
                var query = (from abogado in this._abogadoRepository.GetEntities()
                                select new AbogadosModel
                                {
                                    Id = abogado.Id,
                                    Nombre = abogado.Nombre,
                                    Apellido = abogado.Apellido,
                                    correo = abogado.correo,
                                    Telefono = abogado.Telefono,
                                    celular = abogado.celular

                                }).ToList();

                result.Data = query;          
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los abogados";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Abogados abogado = _abogadoRepository.GetEntity(Id);
                AbogadosModel abogadoModel = new AbogadosModel
                {
                    Id = abogado.Id,
                    Nombre = abogado.Nombre,
                    Apellido = abogado.Apellido,
                    correo = abogado.correo,
                    Telefono = abogado.Telefono,
                    celular = abogado.celular
                };
                result.Data = abogadoModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el abogado";
                _loggerService.LogError(ex.Message);
            }
            return result;

        }

        public AbogadosRemoveResponse Remove(AbogadoRemoveDto abogadoRemoveDto)
        {
            throw new NotImplementedException();
        }

        public AbogadosSaveResponse Save(AbogadoSaveDto abogadoSaveDto)
        {
            AbogadosSaveResponse result = new AbogadosSaveResponse();
            var resultValidation = AbogadosValidations.IsValidAbogado(abogadoSaveDto, _abogadoRepository);
            try
            {
                if (resultValidation.Success)
                {
                    DAL.Entities.Abogados abogado = new DAL.Entities.Abogados
                    {
                        Nombre = abogadoSaveDto.Nombre,
                        Apellido = abogadoSaveDto.Apellido,
                        correo = abogadoSaveDto.correo,
                        Telefono = abogadoSaveDto.Telefono,
                        celular = abogadoSaveDto.celular,
                        IdUsuario = abogadoSaveDto.IdUsuario
                    };
                    _abogadoRepository.Save(abogado);
                    result.Message = "Abogado guardado correctamente";
                }
                else
                {
                    result.Success = resultValidation.Success;
                    result.Message = resultValidation.Message;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el abogado"; 
                _loggerService.LogError(ex.Message);
                return result;
            }
            return result;
        }

        public AbogadosUpdateResponse Update(AbogadoUpdateDto abogadoUpdateDto)
        {
            AbogadosUpdateResponse result = new AbogadosUpdateResponse();
            try
            {
                var resultValidation = AbogadosValidations.IsValidAbogado(abogadoUpdateDto, _abogadoRepository);
                if (resultValidation.Success)
                {
                    DAL.Entities.Abogados abogadoToUpdate = _abogadoRepository.GetEntity(abogadoUpdateDto.Id);

                    abogadoToUpdate.Nombre = abogadoUpdateDto.Nombre;
                    abogadoToUpdate.Apellido = abogadoUpdateDto.Apellido;
                    abogadoToUpdate.correo = abogadoUpdateDto.correo;
                    abogadoToUpdate.Telefono = abogadoUpdateDto.Telefono;
                    abogadoToUpdate.celular = abogadoUpdateDto.celular;

                    _abogadoRepository.Update(abogadoToUpdate);
                    result.Message = "Abogado actualizado correctamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = resultValidation.Message;
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el abogado";
                _loggerService.LogError(ex.Message);
                return result;
            }
            return result;
                
            }
        }
    }

