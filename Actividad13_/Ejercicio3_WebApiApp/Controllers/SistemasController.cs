using Ejercicio1_Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3_WebApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemasController : ControllerBase
{
    static Sistema MiEmpresa=new Sistema();

    [HttpPost("DescargarCamion")]
    public ActionResult PostDescargarCamion(IFormFile manifiesto)
    {
        Stream s = manifiesto.OpenReadStream();
        MiEmpresa.Descargar(s);

        return Ok();
    }

    [HttpGet("CamionesCargados")]
    public ActionResult<string[]> GetCamionesCargados()
    {
        string[] camiones = MiEmpresa.CamionesCargados();

        if (camiones == null || camiones.Length == 0)
            return NotFound("No hay camiones cargados.");

        return Ok(camiones);
    }

    
    [HttpGet("listaPaquetes")]
    public ActionResult<List<Paquete>> GetListaPaquetes()
    {
        return Ok(MiEmpresa.listaPaquetes);
    }


    [HttpGet("AgregarPaqueteDelCamion/{posicion}")]
    public ActionResult<double> GetAgregarPaqueteDelCamion(int posicion)
    {
        try
        {
            Paquete paquete = null;

            paquete = BuscarPaquete("3");
            if (paquete == null) paquete=BuscarPaquete("2");
            if (paquete == null) paquete=BuscarPaquete("1");

            double pesoCamion=MiEmpresa.CargarPaquete(posicion, paquete);

            return Ok(pesoCamion);
        } 
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
           $"Error al procesar el paquete: {ex.Message}");
        }
    }

    protected Paquete BuscarPaquete(string zona)
    {
        Paquete p = null;
        for (int n = 0; n < MiEmpresa.listaPaquetes.Count && p == null; n++)
        {
            if (MiEmpresa.listaPaquetes[n].ZonaDestino == zona)
                p = MiEmpresa.listaPaquetes[n];
        }
        return p;
    }

    

    [HttpGet("VerCargaCamion")]
    public ActionResult<List<Paquete>> GetListaPaquetes(int posicion)
    {
        string[] paquetes = MiEmpresa.VerCargaCamion(posicion);

        if (paquetes == null || paquetes.Length == 0) return NotFound("No hay carga en el camión");

        return Ok(paquetes);
    }
}
