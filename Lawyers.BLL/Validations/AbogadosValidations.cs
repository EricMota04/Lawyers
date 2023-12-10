using Lawyers.BLL.Core;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Validations
{
    public class AbogadosValidations
    {
        public static ServiceResult IsValidAbogado(DtoAbogadoBase dtoAbogadoBase, IAbogadosRepository abogadosRepository)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(dtoAbogadoBase.Nombre))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoAbogadoBase.Apellido))
            {
                result.Success = false;
                result.Message = "El apellido es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoAbogadoBase.correo))
            {
                result.Success = false;
                result.Message = "El correo es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoAbogadoBase.Telefono))
            {
                result.Success = false;
                result.Message = "El telefono es requerido";
                return result;
            }
            if (string.IsNullOrEmpty(dtoAbogadoBase.celular))
            {
                result.Success = false;
                result.Message = "El celular es requerido";
                return result;
            }
            if (abogadosRepository.GetEntities().Any(x => x.correo == dtoAbogadoBase.correo))
            {
                result.Success = false;
                result.Message = "El correo ya existe";
                return result;
            }
            return result;
        }
    }
}
