using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW13122021.Objetcs
{
    public class ObjReponedor
    {
        public int id { get; set; }
        public string user { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public override string ToString()
        {
            return $"Id: {id}, USUARIO: {user}, NOMBRE: {nombre}, APELLIDO: {ap_paterno}";
        }
    }

}
