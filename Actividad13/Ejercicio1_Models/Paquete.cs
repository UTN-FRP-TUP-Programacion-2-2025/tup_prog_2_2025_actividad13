namespace Ejercicio1_Models;

public class Paquete
{
    public int NroRegistro { get; set; }
    public double Peso { get; set; }
    public string Marca { get; set; }
    public string ZonaDestino { get; set; }

    public Paquete(int id, double peso, string zona)
    {
        NroRegistro = id;
        Peso = peso;        
        ZonaDestino = zona;
    }

    public override string ToString()
    {
        return $"{NroRegistro};{Peso}";
    }
}
