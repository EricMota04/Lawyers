using Lawyers.BLL.Core;
using Lawyers.BLL.Dtos.DtosClientes;
using Lawyers.BLL.Responses.ClientesResponses;


namespace Lawyers.BLL.Contracts
{
    public interface IClienteService : IBaseService
    {
        ClientesSaveResponse Save(ClientesSaveDto clientesSaveDto);
        ClientesUpdateResponse Update(ClientesUpdateDto clientesUpdateDto);

    }
}
