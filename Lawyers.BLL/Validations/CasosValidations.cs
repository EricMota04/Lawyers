using Lawyers.BLL.Core;
using Lawyers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawyers.BLL.Validations
{
    public class CasosValidations
    {
        public static ServiceResult IsValidCaso(DtoCasosBase dtoCaso, ICasosRepository casosRepository)
        {
            ServiceResult result = new ServiceResult();
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite = new DateTime(2000, 1, 1);
            if(string.IsNullOrEmpty(dtoCaso.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion del caso es requerida";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.IdEstadoCaso.ToString()))
            {
                result.Success = false;
                result.Message = "El estado del caso es requerido";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.IdTipoCaso.ToString()))
            {
                result.Success = false;
                result.Message = "El tipo de caso es requerido";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.IdAbogado.ToString()))
            {
                result.Success = false;
                result.Message = "El abogado es requerido";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.IdCliente.ToString()))
            {
                result.Success = false;
                result.Message = "El cliente es requerido";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.Latitud))
            {
                result.Success = false;
                result.Message = "La latitud es requerida";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.Longitud))
            {
                result.Success = false;
                result.Message = "La longitud es requerida";
                return result;
            }
            if(string.IsNullOrEmpty(dtoCaso.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripción del caso es requerida";
                return result;
            }
            if(dtoCaso.FechaCaso < fechaLimite)
            {
                result.Success = false;
                result.Message = "La fecha de inicio del caso no puede ser menor al año 2000";
                return result;
            }
            if(dtoCaso.FechaCaso > fechaActual)
            {
                result.Success = false;
                result.Message = "La fecha del caso no puede ser mayor a la fecha de hoy";
                return result;
            }
            
            if(casosRepository.GetEntities().Any(x => x.IdCliente == dtoCaso.IdCliente && x.FechaCaso == dtoCaso.FechaCaso && x.Latitud == dtoCaso.Latitud && x.Longitud == dtoCaso.Longitud))
            {
                result.Success = false;
                result.Message = "El caso ya existe";
                return result;
            }
            return result;
        }
    }
}
