using System.Dynamic;

namespace EspacioTarea;

public class Tarea
{
    private int id;

    private string? descripcion;

    private int duracion;

    public Tarea(int tareaId, string descripcion){
        this.id = Id;
        this.descripcion = descripcion;
    }

    public int Id { get => id; set => id = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }


}