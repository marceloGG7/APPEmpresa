using APPEmpresa.BLL;
using APPEmpresa.ENTITY;
using APPEmpresa.VALIDACIONES;
using FluentValidation;
using System.Collections.Generic;
using System.Xml;

Console.WriteLine("=BIENVENIDO AL SISTEMA=");

int Opc = 0;

while (Opc != 3)
{
    Console.WriteLine();
    Console.WriteLine("1. GUARDAR CLIENTE.");
    Console.WriteLine("2. CONSULTAR CLIENTE.");
    Console.WriteLine("3. SALIR.");
    Console.Write("Ingrese una opcion: ");
    Opc = Convert.ToInt32(Console.ReadLine());

    if (Opc == 1)
    {
        Console.WriteLine();
        Console.WriteLine("GUARDAR");
        Insertar();
    }
    else if (Opc == 2)
    {
        Console.WriteLine();
        Console.WriteLine("CONSULTAR.");
        Consultar();
        Console.WriteLine();
    }
    else if (Opc == 3)
    {
        Console.WriteLine();
        Console.WriteLine("Saliendo del sistema");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Ingrese una opcion valida.");
    }
}

Console.ReadKey();

static void Consultar()
{
    List<DtoRepCliente> lstRepCliente = BL_CLIENTE.ConsultarCliente();

    if (lstRepCliente.Count > 0)
    {
        Console.WriteLine("Reporte de clientes");
        Console.WriteLine();

        Console.WriteLine("NoCliente | Nombre | RFC | Estatus | FecRegistro");
        foreach (var lst in lstRepCliente)
        {
            Console.WriteLine($"{lst.NoCliente} | {lst.Nombre} | {lst.RFC} | {lst.Estatus} | {lst.FecRegistro}");
        }
    }
    else
    {
        Console.WriteLine("No se encontro informacion");
    }
}

static void Insertar()
{
    //CLIENTE Cliente = new()
    //{
    //    Nombre = "Marcelo",
    //    APaterno = "Araiza",
    //    AMaterno = "Molina",
    //    RFC = "AJAJAJAJAJAW"
    //};
    string opc = "s";

    while (opc != "n")
    {
        CLIENTE Cliente = new();

        Console.Write("Ingrese el nombre: ");
        Cliente.Nombre = Console.ReadLine();

        Console.Write("Ingrese el apellido paterno: ");
        Cliente.APaterno = Console.ReadLine();

        Console.Write("Ingrese el apellido materno: ");
        Cliente.AMaterno = Console.ReadLine();

        Console.Write("Ingrese el RFC: ");
        Cliente.RFC = Console.ReadLine();

        List<string> lstValidaciones = BL_CLIENTE.ValidaDatosCliente(Cliente);

        if (lstValidaciones.Count == 0)
        {
            List<string> lstDatos = BL_CLIENTE.RegistroCliente(Cliente);

            if (lstDatos[0] == "00")
            {
                Console.WriteLine(lstDatos[1]);
            }
            else
            {
                Console.WriteLine(lstDatos[1]);
            }
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Listado de errores: ");

            foreach (var lst in lstValidaciones)
            {
                Console.WriteLine(lst);
            }
        }

        Console.Write("Desea agregar otro registro (s/n): ");
        opc = Console.ReadLine().ToLower();
    }
}