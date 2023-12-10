using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosUsuarios;
using Lawyers.BLL.Models;
using Lawyers.BLL.Responses.UsuariosResponses;
using Lawyers.BLL.Validations;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly ILoggerService<UsuariosService> _loggerService;
        public UsuariosService(IUsuariosRepository usuariosRepository, ILoggerService<UsuariosService> loggerService)
        {
            _loggerService = loggerService;
            _usuariosRepository = usuariosRepository;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from usuarios in this._usuariosRepository.GetEntities()
                              select new UsuariosModel
                              {
                                  Id = usuarios.Id,
                                  Usuario = usuarios.Usuario,
                                  Contrasena = usuarios.Contrasena,
                                  RolId = usuarios.RolId
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los usuarios";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Usuarios usuarios = _usuariosRepository.GetEntity(Id);
                UsuariosModel usuariosModel = new UsuariosModel
                {
                    Id = usuarios.Id,
                    Usuario = usuarios.Usuario,
                    Contrasena = usuarios.Contrasena,
                    RolId = usuarios.RolId
                };
                result.Data = usuariosModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el usuario";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public UsuarioSaveResponse Save(UsuarioSaveDto usuarioSaveDto)
        {
            UsuarioSaveResponse result = new UsuarioSaveResponse();
            var validUsuario = UsuariosValidations.IsValidUsuario(usuarioSaveDto, _usuariosRepository);
            try
            {
                if(validUsuario.Success)
                {
                    DAL.Entities.Usuarios usuarios = new DAL.Entities.Usuarios
                    {
                        Id = usuarioSaveDto.Id,
                        Usuario = usuarioSaveDto.Usuario,
                        Contrasena = usuarioSaveDto.Contrasena,
                        RolId = usuarioSaveDto.RolId
                    };
                    _usuariosRepository.Save(usuarios);
                    result.Success = true;
                    result.Message = "Usuario guardado correctamente";
                }
                else
                {
                    result.Success = false;
                    result.Message = validUsuario.Message;
                }
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error guardando el usuario";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public UsuarioUpdateResponse Update(UsuarioUpdateDto usuarioUpdateDto)
        {
            UsuarioUpdateResponse result = new UsuarioUpdateResponse();
            var validUsuario = UsuariosValidations.IsValidUsuario(usuarioUpdateDto, _usuariosRepository);
            try
            {
                if (validUsuario.Success)
                {
                    DAL.Entities.Usuarios usuarios = new DAL.Entities.Usuarios
                    {
                        Id = usuarioUpdateDto.Id,
                        Usuario = usuarioUpdateDto.Usuario,
                        Contrasena = usuarioUpdateDto.Contrasena,
                        RolId = usuarioUpdateDto.RolId
                    };
                    _usuariosRepository.Update(usuarios);
                }
                else
                {
                    result.Success = false;
                    result.Message = validUsuario.Message;
                }
            }
            catch(System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando el usuario";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
