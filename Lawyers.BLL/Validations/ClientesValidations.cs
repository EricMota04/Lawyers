using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosClientes;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Validations
{
    public class ClientesValidations
    {
        public static ServiceResult IsValidCliente(DtoClientesBase dtoClienteBase, IClientesRepository clientesRepository)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(dtoClienteBase.Nombre))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoClienteBase.Apellido))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoClienteBase.correo))
            {
                result.Success = false;
                result.Message = "El correo es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoClienteBase.Telefono))
            {
                result.Success = false;
                result.Message = "El telefono es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoClienteBase.celular))
            {
                result.Success = false;
                result.Message = "El celular es requerido";
                return result;
            }
            if(clientesRepository.GetEntities().Any(x => x.Cedula ==dtoClienteBase.Cedula)) {
                result.Success = false;
                result.Message = "El cliente ya existe";
                return result;
            }
            if (clientesRepository.GetEntities().Any(x => x.correo == dtoClienteBase.correo))
            {
                result.Success = false;
                result.Message = "El correo ya existe";
                return result;
            }
            return result;
        }

        internal static bool IsValidCliente(ClientesSaveDto clientesSaveDto)
        {
            throw new NotImplementedException();
        }
    }
}
