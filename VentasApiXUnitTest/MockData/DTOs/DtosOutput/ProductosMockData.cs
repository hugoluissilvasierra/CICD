using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasAPI.DTOs.DtosOutput;

namespace VentasApiXUnitTest.MockData.DTOs.DtosOutput
{
    public class ProductosMockData
    {
        public static List<ProductoDtoOutput> GetProductoDtoOutputs()
        {
            return new List<ProductoDtoOutput> {
                new ProductoDtoOutput{
                    Id = 1,
                    Descripcion = "Producto 1",
                    Precio = 100
                },
                new ProductoDtoOutput{
                    Id = 2,
                    Descripcion = "Producto 2",
                    Precio = 200
                },
                new ProductoDtoOutput{
                    Id = 3,
                    Descripcion = "Producto 3",
                    Precio = 300
                },
                new ProductoDtoOutput{
                    Id = 4,
                    Descripcion = "Producto 4",
                    Precio = 400
                }
            };
        }
        public static List<ProductoDtoOutput> GetNingunProductoDtoOutputs()
        {
            return new List<ProductoDtoOutput>();
        }
    }
}
