
using (var contextoDB = new contextoDB())
{
    foreach (var item in contextoDB.estudiantes)
    {
        Console.WriteLine($"Datos: Id: {item.Id}, Nombres: {item.Nombres}, Apellidos: {item.Apellidos}, Sexo: {item.Sexo}, Edad: {item.Edad}");

    }
}

bool agregarMasRegistros = true;

while (agregarMasRegistros)
{
    Console.WriteLine("Ingrese los datos del estudiante:");

    Console.Write("Nombres: ");
    string nombres = Console.ReadLine();

    Console.Write("Apellidos: ");
    string apellidos = Console.ReadLine();

    Console.Write("Sexo: ");
    string sexo = Console.ReadLine();

    Console.Write("Edad: ");
    int edad = Convert.ToInt32(Console.ReadLine());

    using (var contextoDB = new contextoDB())
    {
        contextoDB.Database.EnsureCreated();

        var nuevoEstudiante = new estudianteUNAB()
        {
            Nombres = nombres,
            Apellidos = apellidos,
            Sexo = sexo,
            Edad = edad
        };

        contextoDB.Add(nuevoEstudiante);
        contextoDB.SaveChanges();
    }

    Console.WriteLine("¿Desea agregar más registros? (Sí/No)");
    string respuesta = Console.ReadLine();
    agregarMasRegistros = respuesta.StartsWith("S", StringComparison.OrdinalIgnoreCase);
}

using (var contextoDB = new contextoDB())
{
    foreach (var estudiante in contextoDB.estudiantes)
    {
        Console.WriteLine($"Estudiante: {estudiante.Nombres} {estudiante.Apellidos}, Sexo: {estudiante.Sexo}, Edad: {estudiante.Edad}");
    }
}