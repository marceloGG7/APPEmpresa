using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEmpresa.ENTITY
{
    public record DtoRepCliente
    {
        public int NoCliente { get; set; }
        public string Nombre { get; set; }
        public string RFC { get; set; }
        public string Estatus { get; set; }
        public string FecRegistro { get; set; }
    }
}
