using AutoMapper;
using VentasAPI.Entidades;
using VentasAPI.Repositorios;
using VentasAPI.Utils;
using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;

namespace VentasAPI.Servicios
{
    public class ProductosService : IProductosService
    {
        private readonly VentasDbContext _context;
        private readonly IMapper _mapper;
        public ProductosService(VentasDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ProductoDtoOutput CrearProducto(ProductoDtoCrear productoDtoCrear)
        {
            var producto = _mapper.Map<Producto>(productoDtoCrear);

            _context.Productos.Add(producto);

            _context.SaveChanges();

            var productoDtoOutput = _mapper.Map<ProductoDtoOutput>(producto);

            return productoDtoOutput;
        }

        public void EliminarProducto(int id)
        {
            var producto = _context.Productos.SingleOrDefault(p => p.Id == id);

            if (producto == null)
                throw new NotFoundException($"No existe el producto con id: {id}");

            _context.Productos.Remove(producto);
            _context.SaveChanges();
        }

        public ProductoDtoOutput GetProducto(int id)
        {
            var producto = _context.Productos.SingleOrDefault(p => p.Id == id);

            var productoDtoOutput = _mapper.Map<ProductoDtoOutput>(producto);

            return productoDtoOutput;
        }

        public List<ProductoDtoOutput> GetProductos()
        {
            var productos = _context.Productos.ToList();

            var productosDtoOutput = new List<ProductoDtoOutput>();

            foreach (var producto in productos)
            {
                var productoDtoOutput = _mapper.Map<ProductoDtoOutput>(producto);

                productosDtoOutput.Add(productoDtoOutput);
            }

            return productosDtoOutput;
        }

        public void ModificarProducto(ProductoDtoModificar productoDtoModificar)
        {
            if (productoDtoModificar == null)
                throw new Exception("Objeto nulo.");

            var producto = _mapper.Map<Producto>(productoDtoModificar);

            var productoAlmacenado = _context.Productos.SingleOrDefault(p => p.Id == producto.Id);

            if (productoAlmacenado == null)
                throw new NotFoundException($"No existe el producto con id: {producto.Id}");

            productoAlmacenado.Descripcion = producto.Descripcion;
            productoAlmacenado.Precio = producto.Precio;

            _context.Update(productoAlmacenado);
            _context.SaveChanges();
        }
    }
}
