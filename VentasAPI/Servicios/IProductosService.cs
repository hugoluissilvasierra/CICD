using VentasAPI.DTOs.DtosInput;
using VentasAPI.DTOs.DtosOutput;
using VentasAPI.Entidades;

namespace VentasAPI.Servicios
{
    public interface IProductosService
    {
        ProductoDtoOutput CrearProducto(ProductoDtoCrear productoDtoCrear);
        void ModificarProducto(ProductoDtoModificar productoDtoModificar);
        void EliminarProducto(int id);
        ProductoDtoOutput GetProducto(int id);
        List<ProductoDtoOutput> GetProductos();
    }
}