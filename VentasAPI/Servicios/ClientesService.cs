using AutoMapper;
using VentasAPI.Entidades;
using VentasAPI.Repositorios;
using VentasAPI.Utils;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;

namespace VentasAPI.Servicios
{
    public class ClientesService : IClientesService
    {
        private readonly VentasDbContext _context;
        private readonly IMapper _mapper;
        public ClientesService(VentasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ClienteDtoOutput CrearCliente(ClienteDtoCrear clienteDtoCrear)
        {
            var cliente = _mapper.Map<Cliente>(clienteDtoCrear);

            _context.Clientes.Add(cliente);

            _context.SaveChanges();

            var clienteDtoOutput = _mapper.Map<ClienteDtoOutput>(cliente);

            return clienteDtoOutput;
        }

        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(p => p.Id == id);

            if (cliente == null)
                throw new NotFoundException($"No existe el cliente con id: {id}");

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public ClienteDtoOutput GetCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(p => p.Id == id);

            var clienteDtoOutput = _mapper.Map<ClienteDtoOutput>(cliente);

            return clienteDtoOutput;
        }

        public List<ClienteDtoOutput> GetClientes()
        {
            var clientes = _context.Clientes.ToList();

            var clientesDtoOutput = new List<ClienteDtoOutput>();

            foreach (var cliente in clientes)
            {
                var clienteDtoOutput = _mapper.Map<ClienteDtoOutput>(cliente);

                clientesDtoOutput.Add(clienteDtoOutput);
            }

            return clientesDtoOutput;
        }

        public void ModificarCliente(ClienteDtoModificar clienteDtoModificar)
        {
            if (clienteDtoModificar == null)
                throw new Exception("Objeto nulo.");

            var cliente = _mapper.Map<Cliente>(clienteDtoModificar);

            var clienteAlmacenado = _context.Clientes.SingleOrDefault(p => p.Id == cliente.Id);

            if (clienteAlmacenado == null)
                throw new NotFoundException($"No existe el cliente con id: {cliente.Id}");

            clienteAlmacenado.Nombre = cliente.Nombre;

            _context.Update(clienteAlmacenado);
            _context.SaveChanges();
        }
    }
}
