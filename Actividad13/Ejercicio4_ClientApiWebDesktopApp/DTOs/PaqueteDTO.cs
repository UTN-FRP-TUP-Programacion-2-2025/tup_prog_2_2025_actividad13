
namespace Ejercicio4_ClientApiWebDesktopApp.DTOs;

public class PaqueteDTO
{
    public int NroRegistro { get; set; }
    public double Peso { get; set; }
    public string ZonaDestino { get; set; }


    override public string ToString()
    {
        return $"{NroRegistro};{Peso:f2}";
    }
}
