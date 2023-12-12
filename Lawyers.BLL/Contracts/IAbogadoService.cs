using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosAbogados;
using Lawyers.BLL.Responses.AbogadosResponses;


namespace Lawyers.BLL.Contracts
{
    public interface IAbogadoService : IBaseService
    {
        AbogadosSaveResponse Save(AbogadoSaveDto abogadoSaveDto);
        AbogadosRemoveResponse Remove(AbogadoRemoveDto abogadoRemoveDto);
        AbogadosUpdateResponse Update(AbogadoUpdateDto abogadoUpdateDto);
    }
}
