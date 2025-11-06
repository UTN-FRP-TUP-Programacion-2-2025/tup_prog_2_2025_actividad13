using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Models;

public class Camion
{
    double pesoControl = 0;
    public int Patente { get; set; }
    public double PesoMax { get; set; }

    Stack<Paquete> manifesto = new Stack<Paquete>();

    public Camion(int patente, double peso)
    {
        Patente = patente;
        PesoMax = peso;
    }

    public bool AgregarPaquete(Paquete unPaquete)
    {
        if (unPaquete == null) throw new Exception("paquete nulo");

        if (unPaquete.Peso + pesoControl > PesoMax) return false;

        manifesto.Push(unPaquete);

        pesoControl += unPaquete.Peso;
        return true;
    }

    public double CargaEnKg()
    {
        return pesoControl;
    }

    public Paquete QuitarPaquete()
    {
        if (manifesto.Count > 0)
        {
            Paquete paquete = manifesto.Pop();
            pesoControl -= paquete.Peso;
            return paquete;
        }
        return null;
    }

    public string[] VerCarga()
    {
        string[] carga = new string[manifesto.Count];
        int n = 0;
        foreach (Paquete paquete in manifesto)
        {
            carga[n++] = paquete.ToString();
        }
        return carga;
    }
}
