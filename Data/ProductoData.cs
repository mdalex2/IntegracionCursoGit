using Models.Entidades;

namespace Data;

public static class ProductoData
{
    public static List<Producto> listaProductos = new(){
        new Producto{ Id = 1, Nombre = "Producto 01",MarcaId = 1, CategoriaId = 1, Precio = 2000, Costo = 1800},
        new Producto{ Id = 1, Nombre = "Producto 02",MarcaId = 1, CategoriaId = 1, Precio = 2200, Costo = 2100},
        new Producto{ Id = 1, Nombre = "Producto 03",MarcaId = 1, CategoriaId = 1, Precio = 2350, Costo = 2250},
        new Producto{ Id = 1, Nombre = "Producto 04",MarcaId = 1, CategoriaId = 1, Precio = 2450, Costo = 2250}
    };
}
