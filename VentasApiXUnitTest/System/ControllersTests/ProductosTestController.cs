using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasAPI.Controllers;
using VentasAPI.Servicios;
using VentasApiXUnitTest.MockData.DTOs.DtosOutput;

namespace VentasApiXUnitTest.System.ControllersTests
{
    public class ProductosTestController
    {
        [Fact]
        public void GetAll_ProductosExistentes_ShouldReturn200OkStatus()
        {
            /// Arrange
            var productoStubService = new Mock<IProductosService>();
            productoStubService.Setup(o => o.GetProductos()).Returns(ProductosMockData.GetProductoDtoOutputs());
            var sut = new ProductosController(productoStubService.Object);

            /// Act
            var result = (StatusCodeResult)sut.GetAll();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetAll_ProductosNoExistentes_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            var productoStubService = new Mock<IProductosService>();
            productoStubService.Setup(o => o.GetProductos()).Returns(ProductosMockData.GetNingunProductoDtoOutputs());
            var sut = new ProductosController(productoStubService.Object);

            /// Act
            var result = (StatusCodeResult)sut.GetAll();

            // Assert
            result.StatusCode.Should().Be(204);
        }
    }
}
