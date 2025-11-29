

namespace Ejercicio1_Models;

[Serializable]
public class Paquete
{
    public int NroRegistro { get; set; }
    public double Peso { get; set; }
    public string ZonaDestino { get; set; }

    public Paquete(int id, double peso, string zona)
    {
        NroRegistro = id;
        Peso = peso;
        ZonaDestino = zona;
    }

    override public string ToString()
    {
        return $"{NroRegistro};{Peso:f2}";
    }
}
