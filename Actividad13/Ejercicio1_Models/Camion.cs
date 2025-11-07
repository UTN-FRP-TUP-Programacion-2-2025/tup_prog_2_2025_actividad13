


namespace Ejercicio1_Models;

[Serializable]
public class Camion
{
    double pesoControl=0;
    public int Patente { get; set; }    
    public double PesoMax { get; set; }
    Stack<Paquete> manifiesto = new Stack<Paquete>();

    public Camion(int patente, double peso)
    {
        Patente = patente;
        PesoMax = peso;
    }

    public string[] VerCarga()
    {
        string[] carga=new string[manifiesto.Count];
        int n = 0;
        foreach (Paquete p in manifiesto)
        {
            carga[n++] = p.ToString();
        }
        return carga;
    }

   
    public bool AgregarPaquete(Paquete unPaquete)
    {
        if (unPaquete == null) throw new Exception("Paquete nulo");

        if (unPaquete.Peso + pesoControl > PesoMax) return false;

        manifiesto.Push(unPaquete);
        pesoControl += unPaquete.Peso;

        return true;
      
        /* alternativa
        if (unPaquete != null)
        {
            if (unPaquete.Peso + pesoControl <= PesoMax)
            {
                manifiesto.Push(unPaquete);
                pesoControl += unPaquete.Peso;
                return true;
            }
            else 
            {
                return false;
            }
        }
        else
        {
            throw new Exception("Paquete nulo");
        }
        */
    }

    public double CargaEnKg()
    {
        return pesoControl;
    }

    public Paquete QuitarPaquete()
    {
        if (manifiesto.Count > 0)
        {
            Paquete unPaquete = manifiesto.Pop();
            pesoControl -= unPaquete.Peso;
            return unPaquete;
        }
        return null;
    }
}
