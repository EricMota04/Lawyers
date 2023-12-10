using Lawyers.BLL.Contracts;
using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosClientes;
using Lawyers.BLL.Models;
using Lawyers.BLL.Responses.ClientesResponses;
using Lawyers.BLL.Validations;
using Lawyers.DAL.Entities;
using Lawyers.DAL.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Services
{
    public class ClientesService : IClienteService
    {
        private readonly IClientesRepository _clientesRepository;
        private readonly ILoggerService<ClientesService> _loggerService;
        public ClientesService(IClientesRepository clientesRepository, ILoggerService<ClientesService> loggerService)
        {
            _clientesRepository = clientesRepository;
            _loggerService = loggerService;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from clientes in this._clientesRepository.GetEntities()
                             select new 
                             {
                                 Id = clientes.Id,
                                 Nombre = clientes.Nombre,
                                 Apellido = clientes.Apellido,
                                 correo = clientes.correo,
                                 Telefono = clientes.Telefono,
                                 celular = clientes.celular

                             }).ToList();
                result.Data = query;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo los clientes";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                DAL.Entities.Clientes clientes = _clientesRepository.GetEntity(Id);
                ClientesModel clientesModel = new ClientesModel
                {
                    Id = clientes.Id,
                    Nombre = clientes.Nombre,
                    Apellido = clientes.Apellido,
                    correo = clientes.correo,
                    Telefono = clientes.Telefono,
                    celular = clientes.celular
                };
                result.Data = clientesModel;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error obteniendo el cliente";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }

        public ClientesSaveResponse Save(ClientesSaveDto clientesSaveDto)
        {
            ClientesSaveResponse result = new ClientesSaveResponse();
            var validClient = ClientesValidations.IsValidCliente(clientesSaveDto, _clientesRepository);

            try
            {
                if (validClient.Success)
                {
                    DAL.Entities.Clientes clienteAdd = new DAL.Entities.Clientes
                    {
                        Nombre = clientesSaveDto.Nombre,
                        Apellido = clientesSaveDto.Apellido,
                        correo = clientesSaveDto.correo,
                        Telefono = clientesSaveDto.Telefono,
                        celular = clientesSaveDto.celular
                    };
                    _clientesRepository.Save(clienteAdd);
                }
                else
                {
                    result.Success = false;
                    result.Message = validClient.Message;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error guardando el cliente";
                _loggerService.LogError(ex.Message);
            }
            return result;

        }

        public ClientesUpdateResponse Update(ClientesUpdateDto clientesUpdateDto)
        {
            ClientesUpdateResponse result = new ClientesUpdateResponse();
            var ValidClient = ClientesValidations.IsValidCliente(clientesUpdateDto, _clientesRepository);

            try
            {
                if (ValidClient.Success)
                {
                    DAL.Entities.Clientes clienteUpdate = _clientesRepository.GetEntity(clientesUpdateDto.Id);
                    clienteUpdate.Nombre = clientesUpdateDto.Nombre;
                    clienteUpdate.Apellido = clientesUpdateDto.Apellido;
                    clienteUpdate.correo = clientesUpdateDto.correo;
                    clienteUpdate.Telefono = clientesUpdateDto.Telefono;
                    clienteUpdate.celular = clientesUpdateDto.celular;
                    _clientesRepository.Update(clienteUpdate);
                }
                else
                {
                    result.Success = false;
                    result.Message = ValidClient.Message;
                }
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error actualizando el cliente";
                _loggerService.LogError(ex.Message);
            }
            return result;
        }
    }
}
