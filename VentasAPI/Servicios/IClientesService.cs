using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;

namespace VentasAPI.Servicios
{
    public interface IClientesService
    {
        ClienteDtoOutput CrearCliente(ClienteDtoCrear clienteDtoCrear);
        void ModificarCliente(ClienteDtoModificar clienteDtoModificar);
        void EliminarCliente(int id);
        ClienteDtoOutput GetCliente(int id);
        List<ClienteDtoOutput> GetClientes(); 
    }
}
