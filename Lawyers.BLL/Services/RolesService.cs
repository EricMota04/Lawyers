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
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly ILoggerService<RolesService> _loggerService;
        public RolesService(IRolesRepository rolesRepository, ILoggerService<RolesService> loggerService)
        {
            _loggerService = loggerService;
            _rolesRepository = rolesRepository;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from roles in this._rolesRepository.GetEntities()
                             select new RolesModel
                             {
                                 Id = roles.Id,
                                 Rol = roles.Rol
                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los roles";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Roles roles = _rolesRepository.GetEntity(Id);
                RolesModel rolesModel = new RolesModel
                {
                    Id = roles.Id,
                    Rol = roles.Rol
                };
                result.Data = rolesModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el rol";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
