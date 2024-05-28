// See https://aka.ms/new-console-template for more information
// 1. Cree aleatoriamente N tareas pendientes.
// 2. Desarrolle una interfaz para mover las tareas pendientes a realizadas.
// 3. Desarrolle una interfaz para buscar tareas pendientes por descripcion.
// 4. Guarde en un archivo de texto un sumario de las horas trabajadas por el empleado (sumatoria de la duracion de las tareas).

using System.Collections.Generic;
using ToDoModule;

List<Tarea> pendientes = new List<Tarea>();
List<Tarea> realizadas = new List<Tarea>();

int N = 6; // Número de tareas pendientes
// creo tareas pendientes
pendientes = CrearTareasPendientes(N);

// muestro tareas pendientes
Console.WriteLine("Tareas pendientes:");

MostrarTareas(pendientes);

Console.WriteLine(" Mover tareas pendientes a realizadas:");
// Mover tareas pendientes a realizadas
MoverTareasPendientesARealizadas(pendientes, realizadas);

// Calcula la suma de las duraciones de las tareas realizadas
int horasTrabajadas = CalcularHorasTrabajadas(realizadas);

// Guarda el sumario de horas trabajadas en un archivo de texto
GuardarSumarioHorasTrabajadas(horasTrabajadas);

// muestro tareas realizadas
Console.WriteLine("Tareas realizadas:");
MostrarTareas(realizadas);

// muestro tareas realizadas
Console.WriteLine("Tareas pendientes final:");
MostrarTareas(pendientes);


Console.WriteLine("\nBuscar tareas pendientes por descripcion:");
// El código #pragma warning disable desactiva la advertencia CS8600 que indica una posible conversión de un valor nulo o posible valor nulo 
// a un tipo no anulable. Luego, #pragma warning restore restaura las advertencias después de la línea en cuestión.
#pragma warning disable // Convertir literal nulo o posible valor nulo a tipo no anulable.
string? buscar = Console.ReadLine();
List<Tarea> BusquedaResultado = BuscarTareasPendientesPorDescripcion(pendientes, buscar);
#pragma warning restore

MostrarResultadoBusqueda(BusquedaResultado);


static List<Tarea> CrearTareasPendientes(int N)
{
    List<Tarea> pendientes = new List<Tarea>();
    Random random = new Random();
    for (int i = 0; i < N; i++)
    {
        Tarea tarea = new Tarea();
        tarea.Id = i + 1;
        tarea.Descripcion = GenerarDescripcion();
        tarea.Duracion = random.Next(10, 101);
        pendientes.Add(tarea);
    }
    return pendientes;
}

static string GenerarDescripcion()
{
    string[] descripciones = { "Tarea 1", "Tarea 2", "Tarea 3", "Tarea 4", "Tarea 5" };
    Random random = new Random();
    int index = random.Next(0, descripciones.Length);
    return descripciones[index];
}

static void MoverTareasPendientesARealizadas(List<Tarea> pendientes, List<Tarea> realizadas)
{
    foreach (Tarea tarea in pendientes)
    {
        Console.WriteLine($"ID: {tarea.Id}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
        Console.WriteLine("esta tarea fue realizada? 1- SI 2- NO");
        // El código #pragma warning disable desactiva la advertencia CS8600 que indica una posible conversión de un valor nulo o posible valor nulo 
        // a un tipo no anulable. Luego, #pragma warning restore restaura las advertencias después de la línea en cuestión.
#pragma warning disable // Convertir literal nulo o posible valor nulo a tipo no anulable.
        int respuesta = int.Parse(Console.ReadLine());
#pragma warning restore
        if (respuesta == 1)
        {
            realizadas.Add(tarea);
        }
    }
    foreach (Tarea tarea in realizadas)
    {
        pendientes.Remove(tarea);
    }
}

static void MostrarTareas(List<Tarea> Lista)
{
    foreach (Tarea tarea in Lista)
    {
        Console.WriteLine($"ID: {tarea.Id}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
    }
}

static List<Tarea> BuscarTareasPendientesPorDescripcion(List<Tarea> pendientes, string buscar)
{
    List<Tarea> BusquedaResultado = new List<Tarea>();
    // forma 1 de buscar
    // foreach (Tarea tarea in pendientes)
    // {
    //     if (tarea.Descripcion.ToLower().Contains(buscar.ToLower()))
    //     {
    //         BusquedaResultado.Add(tarea);
    //     }
    // }
    // forma 2 de buscar
    // El código #pragma warning disable desactiva la advertencia CS8600 que indica una posible conversión de un valor nulo o posible valor nulo 
    // a un tipo no anulable. Luego, #pragma warning restore restaura las advertencias después de la línea en cuestión.
#pragma warning disable // Convertir literal nulo o posible valor nulo a tipo no anulable.
    BusquedaResultado = pendientes.FindAll(tarea => tarea.Descripcion.ToLower().Contains(buscar.ToLower()));
#pragma warning restore
    return BusquedaResultado;
}

static void MostrarResultadoBusqueda(List<Tarea> BusquedaResultado)
{
    Console.WriteLine("\nResultados de búsqueda:");
    if (BusquedaResultado.Count > 0)
    {
        foreach (Tarea tarea in BusquedaResultado)
        {
            Console.WriteLine($"ID: {tarea.Id}, Description: {tarea.Descripcion}, Duration: {tarea.Duracion}");
        }
    }
    else
    {
        Console.WriteLine("No se encontraron tareas con la descripcion dada.");
    }
}

static int CalcularHorasTrabajadas(List<Tarea> tareas)
{
    int totalHoras = 0;
    foreach (Tarea tarea in tareas)
    {
        totalHoras += tarea.Duracion;
    }
    return totalHoras;
}

static void GuardarSumarioHorasTrabajadas(int horasTrabajadas)
{
    string nombreArchivo = "sumario_horas_trabajadas.txt";
    using (StreamWriter sw = new StreamWriter(nombreArchivo, true))
    {
        sw.WriteLine("Sumario de horas trabajadas");
        sw.WriteLine($"Horas trabajadas: {horasTrabajadas} horas");
    }
    Console.WriteLine($"Se ha guardado el sumario de horas trabajadas en el archivo '{nombreArchivo}'.");
}

