using System;
using HW13122021.Objetcs;
using System.Collections.Generic;
using System.Linq;
namespace HW13122021
{
    class Program
    {

        static List<ObjInventario> _listaInventarios = new List<ObjInventario>();
        static List<ObjReponedor> _reponedores = new List<ObjReponedor>();
        static int idReponedor = 1;
        static int idProducto = 1;
        private class inventarioDTO
        {
            public int idInventario { get; set; }
            public string producto { get; set; }
            public string cliente { get; set; }
            public int cantidad { get; set; }
            public int idReponedor { get; set; }
            public string ReponedorNombre { get; set; }

            public override string ToString()
            {
                return $"idInventario: {idInventario}, producto: {producto}, Cliente: {cliente}, Cantidad: {idReponedor}, IdOrdenCarga: {ReponedorNombre}";
            }
        }
        static void Main(string[] args)
        {
            CargarBaseDeDatosInicial();
            int opciones;
            do
            {
                
                Console.WriteLine("Seleccione una de las siguiente opciones:\n\n1 => Seleccionar Inventario por Reponedor\n2 => Eliminar Inventario por ID \n0 => Salir de la aplicacion");
                opciones = Convert.ToInt32(Console.ReadLine());
                switch (opciones)
                {
                    case 1: // Registro operacion
                        Console.WriteLine("===========LISTADO DE REPONEDORES ==========================");
                        foreach (var _reponedor in _reponedores)
                        {
                            Console.WriteLine(_reponedor);
                        }
                        Console.WriteLine("==================================================================");
                        Console.WriteLine("Instroduzca el id de un reponedor");
                        int idReponedor =Convert.ToInt32(Console.ReadLine());
                        var obj = buscarInventarioPorReponedor(idReponedor);
                        Console.WriteLine(obj);
                        Console.WriteLine("==================================================================");
                        break;
                    case 2://Eliminar Inventario
                        Console.WriteLine("===========LISTADO DE INVENTARIO ==========================");
                        foreach (var _inventario in _listaInventarios)
                        {
                            Console.WriteLine(_inventario);
                        }
                        Console.WriteLine("==================================================================");
                        Console.WriteLine("Instroduzca el id de inventario");
                        int idInventario = Convert.ToInt32(Console.ReadLine());
                        eliminarInventarioPorId(idInventario);
                        Console.WriteLine("===========LISTADO DE INVENTARIO ==========================");
                        foreach (var _inventario in _listaInventarios)
                        {
                            Console.WriteLine(_inventario);
                        }
                        Console.WriteLine("==================================================================");
                        break;                   
                } 
            } while (opciones != 0);
        }


        //1. First or Default
        //2. Where
        //3. Select 
        //4. OrderBy
            private static inventarioDTO buscarInventarioPorReponedor(int repoId)
            {
                var tuplas = from inven in _listaInventarios
                             join repo in _reponedores
                                 on inven.reponedor equals repo.id
                             where inven.reponedor == repoId orderby inven.id
                             select new inventarioDTO
                             {
                                 idInventario = inven.id,
                                 producto = inven.producto,
                                 cliente = inven.cliente,
                                 cantidad = inven.cantidad,
                                 idReponedor = repo.id,
                                 ReponedorNombre = repo.user,
                             };
                return tuplas.ToList().FirstOrDefault();
            }
            //5. Remove
            //6. Find        
            static void eliminarInventarioPorId(int ID) {

                if (_listaInventarios.Find(op => op.id == ID) != null)
                {
                    _listaInventarios.RemoveAll(op => op.id == ID);
                    Console.WriteLine("Eliminacion exitosa");
                }
                else
                {
                    Console.WriteLine("La Inventario con ID =" + ID + " no existe en la base de datos");
                }

            }
            //7. Index Of
            static int obtenerIndex(ObjInventario _inventario)
            {
                int index = _listaInventarios.IndexOf(_inventario);
                if (index >= 0) // elemento existe en la lista
                {
                    _listaInventarios.RemoveAt(index);
                    Console.WriteLine($"Elemento con id = {_inventario.id}, ha sido eliminado");
                }
                else
                {
                    Console.WriteLine("Elemento no encontrado");
                }

                return _listaInventarios.IndexOf(_inventario);


            }
            static void CargarBaseDeDatosInicial()
            {
                
                _reponedores.Add(new ObjReponedor
                {
                    id = idReponedor++,
                    user = "REPO01",
                    nombre = "JUAN",
                    ap_paterno = "PEREZ",                    
                });

                _reponedores.Add(new ObjReponedor
                {
                    id = idReponedor++,
                    user = "REPO02",
                    nombre = "ROBERTO",
                    ap_paterno = "MAMANI",
                });
                                
                _listaInventarios.Add(new ObjInventario
                {
                    id = idProducto++,
                    producto = "cafe",
                    cliente = "hipermaxi",
                    reponedor = 1,
                    cantidad = 2                    
                });

                _listaInventarios.Add(new ObjInventario
                {
                    id = idProducto++,
                    producto = "clocolates",
                    cliente = "ketal",
                    reponedor = 1,
                    cantidad = 4
                }); ;
                _listaInventarios.Add(new ObjInventario
                {
                    id = idProducto++,
                    producto = "cereales",
                    cliente = "hipermaxi",
                    reponedor = 2,
                    cantidad = 6
                });

                _listaInventarios.Add(new ObjInventario
                {
                    id = idProducto++,
                    producto = "galletas",
                    cliente = "ketal",
                    reponedor = 2,
                    cantidad = 8
                }); ;
            }
        }
    }

