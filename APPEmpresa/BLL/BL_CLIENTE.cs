using APPEmpresa.DAL;
using APPEmpresa.ENTITY;
using APPEmpresa.VALIDACIONES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEmpresa.BLL
{
    public class BL_CLIENTE
    {
        public static List<string> ValidaDatosCliente(CLIENTE Cliente) 
        {
            List<string> lstValidaciones = [];
            
            ValidacionCliente validationRules = new();

            var Resul = validationRules.Validate(Cliente);

            if (!Resul.IsValid)
            {
                lstValidaciones = Resul.Errors.Select(x=>x.ErrorMessage).ToList();
            }
            return lstValidaciones;
        }

        public static List<string> RegistroCliente(CLIENTE Cliente)
        {
            List<string> lstDatos = [];

            try
            {
                var dpParametros = new
                {
                    P_Nombre = Cliente.Nombre,
                    P_Apaterno = Cliente.APaterno,
                    P_Amaterno = Cliente.AMaterno,
                    P_RFC = Cliente.RFC
                };

                DapperContext.Procedimiento_StoreDB("spInsertCliente", dpParametros);
                lstDatos.Add("00");
                lstDatos.Add("CLIENTE GUARDADO CON EXITO.");

            }
            catch (Exception ex)
            {
                lstDatos.Add("14");
                lstDatos.Add(ex.Message);
            }
            return lstDatos;
        }

        public static List<DtoRepCliente> ConsultarCliente()
        {
            List<DtoRepCliente> lstCliente = [];

            var dpParemetros = new
            {
                P_Accion = 1
            };

            DataTable Dt = DapperContext.Funcion_StoreDB("spConsulCliente",dpParemetros);

            if (Dt.Rows.Count > 0)
            {
                lstCliente = [
                    .. (from item in Dt.AsEnumerable()
                        select new DtoRepCliente
                        {   
                            NoCliente = item.Field<Int32>("NoCliente"),
                            Nombre=item.Field<string>("Nombre"),
                            RFC=item.Field<string>("RFC"),
                            Estatus = item.Field<string>("Estatus"),
                            FecRegistro=item.Field<string>("FecRegistro"),
                        })
                    ];
            }

            return lstCliente;
        }
    }
}
