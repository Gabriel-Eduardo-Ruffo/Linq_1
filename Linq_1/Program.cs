//----------------TUTORIAL LINQ----------------------------------
int[] numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine("Numeros pares de una lista, forma clasica");

//recurrido de una lista (forma comun)
List<int> listaNumerosPares = new List<int>();
foreach (int numero in numeros)
{
    if (numero % 2 == 0)
    {
        listaNumerosPares.Add(numero);
    }
}
foreach (int numero in listaNumerosPares)
{
    Console.WriteLine(numero);
}

//Recorrido de una estructura usando LINQ
Console.WriteLine("Numeros pares de una estructura usando LINQ");
IEnumerable<int> estructuraNumerosPares = from numero in numeros where numero % 2 == 0 select numero;
foreach (int numero in estructuraNumerosPares)
{
    Console.WriteLine(numero);
}

Console.WriteLine("****************************");
Console.WriteLine("");
//------------------------------------------------------------------------------------


//---------------TUTORIAL busquedas de empleados y empresas con LINQ------------------

ControlEmpresaEmpleados ejecutarEjercicio = new ControlEmpresaEmpleados();
Console.WriteLine("Ejercicio --- LINQ con empreasas y empleados");
Console.WriteLine("listar CEOS");
ejecutarEjercicio.GetCEO();
Console.WriteLine("");
Console.WriteLine("listar empleados ordenados por nombre");
ejecutarEjercicio.GetEmpleadosOrdenados();
Console.WriteLine("");

Console.WriteLine("listar empleados de una empresa");
Console.WriteLine("ingresar el id de la empresa");
string entrada = Console.ReadLine();
try
{
    int idEntrada = Convert.ToInt32(entrada);
    int maxIdEmpresa = ejecutarEjercicio.GetMaxIdEmpresa();
    if (maxIdEmpresa < 1 || maxIdEmpresa > idEntrada)
    {
        Console.WriteLine("Ingresaste un numero fuera del rango permitido ");
    }
    else
    {
        ejecutarEjercicio.GetEmpleadosEmpresa(idEntrada);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Ingresaste un numero no valido", ex);
}
Console.WriteLine("");


class ControlEmpresaEmpleados
{
    public List<Empresa> listaEmpresas;
    public List<Empleado> listaEmpleados;
    public ControlEmpresaEmpleados()
    {
        listaEmpresas = new List<Empresa>();
        listaEmpleados = new List<Empleado>();

        listaEmpresas.Add(new Empresa { Id = 1, Nombre = "sarasa" });
        listaEmpresas.Add(new Empresa { Id = 2, Nombre = "que se yo" });

        listaEmpleados.Add(new Empleado { Id = 1, Nombre = "Carlitox", Cargo = "CEO", Salario = 666, EmpresaID_FK = 1 });
        listaEmpleados.Add(new Empleado { Id = 2, Nombre = "Susano", Cargo = "CEO", Salario = 333, EmpresaID_FK = 2 });
        listaEmpleados.Add(new Empleado { Id = 3, Nombre = "Pepito", Cargo = "trabajador", Salario = 1, EmpresaID_FK = 2 });
        listaEmpleados.Add(new Empleado { Id = 4, Nombre = "Pepita", Cargo = "trabajador", Salario = 2, EmpresaID_FK = 1 });
    }

    //devuelve el maximo numero de ID de empresas
    public int GetMaxIdEmpresa()
    {
        IEnumerable<Empresa> idEmpresa = from empresa in listaEmpresas orderby empresa.Id select empresa;
        if (idEmpresa != null)
            return Convert.ToInt32(idEmpresa.Last().Id);
        return 0;
    }

    //devuelve el listado de empleados que son CEO
    public void GetCEO()
    {
        IEnumerable<Empleado> ceos = from empleado in listaEmpleados where empleado.Cargo == "CEO" select empleado;
        foreach (Empleado empleado in ceos)
        {
            empleado.GetDatosEmpleado();
        }
    }

    //devuelve la lista de empleados ordenados por nombre
    public void GetEmpleadosOrdenados()
    {
        IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Nombre select empleado;
        foreach (Empleado empleado in empleados)
        {
            empleado.GetDatosEmpleado();
        }
    }

    //devuelve la lista de empleados que pertenecen a una empresa
    public void GetEmpleadosEmpresa(int id)
    {
        IEnumerable<Empleado> empleadosSarasa = from empleado in listaEmpleados
                                                join empresa in listaEmpresas
                                                on empleado.EmpresaID_FK equals empresa.Id
                                                where empresa.Id == id
                                                select empleado;
        foreach (Empleado empleado in empleadosSarasa)
        {
            empleado.GetDatosEmpleado();
        }
    }
}

class Empresa
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public void GetDatosEmpresa()
    {
        Console.WriteLine("Nombre = {0} con id = {1}", Nombre, Id);
    }
}

class Empleado
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Cargo { get; set; }
    public double Salario { get; set; }
    public int EmpresaID_FK { get; set; }

    public void GetDatosEmpleado()
    {
        Console.WriteLine("Nombre {0} con id {1}, con el cargo de {2}, con un salario de {3}, perteneciente a la empresa {4}", Nombre, Id, Cargo, Salario, EmpresaID_FK);
    }
}