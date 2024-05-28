using System.Dynamic;

namespace EspacioCalculadora;

public class calculadora
{
    private double dato;

    public double RESULTADO{ get => dato;}

    public double RESULTADO2{
        get{
            return dato;
        }
    }
    
    public void Suma(double termino){
        dato = dato+termino;
    }
    public void Resta(double termino){
        dato= dato-termino;
    }
    public void Multiplicacion(double termino){
        dato= dato * termino;
        
    }
    public void Division(double termino){
        dato= dato / termino;
    }
    public void Limpiar(){
        dato = 0;
    }

    public class Operacion{

        private double resultadoAnterior;

        private double nuevoValor;

        private TipoOperacion operacion;

        
    }

    public enum TipoOperacion{
        Suma,
        Resta,

        Multiplicacion,

        Division,

        Limpiar


    }

}


