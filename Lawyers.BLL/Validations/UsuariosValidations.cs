using Lawyers.BLL.Core;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Validations
{
    public class UsuariosValidations
    {
        public static ServiceResult IsValidUsuario(DtoUsuariosBase dtoUsuariosBase, IUsuariosRepository usuariosRepository)
        {
            ServiceResult result = new ServiceResult();
            if(string.IsNullOrEmpty(dtoUsuariosBase.Usuario))
            {
                result.Success = false;
                result.Message = "El Nombre de usuario es requerido";
                return result;
            }
            if(string.IsNullOrEmpty(dtoUsuariosBase.Contrasena))
            {
                result.Success = false;
                result.Message = "La contraseña es requerida";
                return result;
            }
            if(dtoUsuariosBase.Contrasena.ToString().Length < 6)
            {
                result.Success = false;
                result.Message = "La contraseña debe tener al menos 6 caracteres";
                return result;
            }
            if(usuariosRepository.GetEntities().Any(x => x.Usuario == dtoUsuariosBase.Usuario))
            {
                result.Success = false;
                result.Message = "El usuario ya existe";
                return result;
            }
            return result;
        }
    }
}
