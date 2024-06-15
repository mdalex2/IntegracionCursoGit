using Models.Entidades;

namespace Data;

public static class ProductoData
{
    public static List<Producto> listaProductos = new(){
        new Producto{ Id = 1, NombreProducto = "Producto 01",Marca = "HP", Categoria = "Computadoras", Precio = 2000, Costo = 1800},
        new Producto{ Id = 1, NombreProducto = "Producto 02",Marca = "HP", Categoria = "Computadoras", Precio = 2200, Costo = 2100},
        new Producto{ Id = 1, NombreProducto = "Producto 03",Marca = "HP", Categoria = "Computadoras", Precio = 2350, Costo = 2250},
        new Producto{ Id = 1, NombreProducto = "Producto 04",Marca = "HP", Categoria = "Computadoras", Precio = 2450, Costo = 2250}
    };
}
