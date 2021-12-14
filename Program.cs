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
            int opciones;
            do
            {
                Console.WriteLine("Hello World!");
                opciones =Convert.ToInt32(Console.ReadLine());
            } while (opciones!=0);
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
                             producto = inven.producti,
                             cliente = inven.cliente,
                             cantidad = inven.cantidad,
                             idReponedor = repo.id,
                             ReponedorNombre = repo.user,                             
                         };
            return tuplas.ToList().FirstOrDefault();
        }
        //5. Remove
        //6. Find        
        static void eliminarInventarioPorId(int ID)        {
            
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
            int index =  _listaInventarios.IndexOf(_inventario);
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
    }
}
