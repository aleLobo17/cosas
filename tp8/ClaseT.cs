namespace ToDoModule;

public class Tarea
{
    private int id;
    private string? descripcion;
    private int duracion;
    public int Id { get => id; set => id = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}
