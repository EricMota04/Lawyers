using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosCasos;
using Lawyers.BLL.Responses.CasosResponses;


namespace Lawyers.BLL.Contracts
{
    public interface ICasosService : IBaseService
    {
        CasosSaveResponse Save(CasosSaveDto casosSaveDto);
        CasosUpdateResponse Update(CasosUpdateDto casosUpdateDto);
    }
}
