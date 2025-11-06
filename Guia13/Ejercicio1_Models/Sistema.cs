using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Models;

public class Sistema
{
    List<Camion>listaCamiones =new List<Camion>();
    public List<Paquete> listaPaquetes = new List<Paquete>();

    public Sistema()
    { 
        listaCamiones.Add(new Camion(1001, 2000));
        listaCamiones.Add(new Camion(1002, 5000));
    }

    public void Descargar(Stream fs)
    {
        StreamReader sr=new StreamReader(fs);

        while (!sr.EndOfStream)
        {
            string linea = sr.ReadLine();

            string[] datos = linea.Split(';');

            int id = Convert.ToInt32(datos[0]);
            double peso = Convert.ToDouble(datos[1]);
            string zona = datos[2];

            Paquete paquete = new Paquete(id, peso, zona);
            listaPaquetes.Add(paquete);
        }

        sr.Close();
    }

    public string[] CamionesCargados()
    {
        string[] cs=new string[listaCamiones.Count];
        int n = 0;
        foreach (Camion c in listaCamiones)
        {
            cs[n++] = c.Patente.ToString();
        }
        return cs;
    }

    public double CargarPaquete(int camionElegido, Paquete seleccionado)
    {
        Camion c= listaCamiones[camionElegido];

        if (c.AgregarPaquete(seleccionado))
        { 
            listaPaquetes.Remove(seleccionado);
        }

        return c.CargaEnKg();
    }

    public string[] VerCargaCamion(int camionElegido)
    {
        Camion camion= listaCamiones[camionElegido];
        return camion.VerCarga(); 
    }

    public double RetirarPaquete(int camionElegido)
    {
        Camion c = listaCamiones[camionElegido];

        Paquete p = c.QuitarPaquete();
        if(p!=null)
        {
            listaPaquetes.Add(p);
        }
        return c.CargaEnKg();
    }

    public void RetirarCamion(Stream fs, int posicion)
    {
        StreamWriter sr = new StreamWriter(fs);

        foreach (string p in VerCargaCamion(posicion))
        {
            sr.WriteLine(p.ToString());
        }
      

        sr.Close();
    }
}
