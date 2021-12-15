using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13122021.Objetcs
{
    public class ObjInventario
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string cliente { get; set; }
        public int reponedor { get; set; }
        public int cantidad { get; set; }

        public override bool Equals(object obj)
        {
            // CAST Object -> ObjInventario
            //ObjInventario o2 = obj as ObjInventario;
            ObjInventario o2 = (ObjInventario)obj;
            return id == o2.id;
        }
        public override string ToString()
        {
            return $"Id: {id}, PRODUCTO: {producto}, CLIENTE: {cliente}, REPONEDOR: {reponedor}, CANTIDAD: {cantidad}";
        }

    }
}
