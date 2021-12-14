using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW13122021.Objetcs;

namespace HW13122021.Data
{
    public class GeneralData
    {
        public ObjInventario buscarInventarioPorReponedor(int repoId)
        {
            var tuplas = from repo in ObjInventario
                         join inven in ObjReponedor
                             on repo.IdOperacion equals inven.d
                         where oc.IdOrdenCarga == idOc
                         select new OrdenCargaDTO
                         {
                             IdOperacion = op.IdOperacion,
                             Operacion = op.Nombre,
                             Flete = op.FleteTotal,
                             Empresa = op.Empresa,
                             IdOrdenCarga = oc.IdOrdenCarga,
                             Honorarios = oc.Honorarios,
                             NombreChofer = oc.Chofer
                         };

            return tuplas.ToList().FirstOrDefault();

        }
    }
    
}
