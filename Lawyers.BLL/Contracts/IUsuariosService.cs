using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosUsuarios;
using Lawyers.BLL.Responses.UsuariosResponses;

namespace Lawyers.BLL.Contracts
{
    public interface IUsuariosService : IBaseService
    {
        UsuarioSaveResponse Save(UsuarioSaveDto usuarioSaveDto);
        UsuarioUpdateResponse Update(UsuarioUpdateDto usuarioUpdateDto);
    }
}
