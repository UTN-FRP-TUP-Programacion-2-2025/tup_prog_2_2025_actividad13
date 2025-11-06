using Ejercicio1_Models;
using Microsoft.AspNetCore.Mvc;


namespace Ejercicio3_ApiWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SistemasController : ControllerBase
{
    static Sistema MiEmpresa =new Sistema();

    [HttpPost("DescargarCamion")]
    public async Task<ActionResult> PostDescargarCamion(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No se ha proporcionado ningún archivo");
        
        try
        {
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;
                MiEmpresa.Descargar(stream);
                return Ok("Archivo procesado correctamente");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error al procesar el archivo: {ex.Message}");
        }
    }

    [HttpGet("EnviarCamion")]
    public async Task<IActionResult> GetEnviarCamion(int nroCamion)
    {
        try
        {
            using MemoryStream stream = new MemoryStream();
           
            MiEmpresa.RetirarCamion(stream,nroCamion);

            byte[] fileContents = stream.ToArray();

            return File(fileContents, "text/csv", $"camion_{nroCamion}.csv");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error al procesar el archivo: {ex.Message}");
        }
    }

    [HttpGet("CamionesCargados")]
    public ActionResult<string[]> GetCamionesCargados()
    {
        string[] camiones= MiEmpresa.CamionesCargados();

        if(camiones==null || camiones.Length==0) return NotFound("No hay camiones cargados");

        return Ok(camiones);
    }

    [HttpGet("VerCarga")]
    public ActionResult<string[]> GetCarga(int nroCamion)
    {
        string[] paquetes = MiEmpresa.VerCargaCamion(nroCamion);

        if (paquetes == null || paquetes.Length == 0) return NotFound("No hay paquetes");

        return Ok(paquetes);
    }

    [HttpGet("listaPaquetes")]
    public ActionResult<Paquete> GetListaPaquetes()
    {
        if (MiEmpresa.listaPaquetes == null || MiEmpresa.listaPaquetes.Count == 0) return NotFound("No hay paquetes");

        return Ok(MiEmpresa.listaPaquetes);
    }

    [HttpGet("AgregarPaqueteDelCamion")]
    public ActionResult<double> AgregarPaquete(int nroCamion)
    {
        Paquete paquete = null;

        for (int n=0; n<MiEmpresa.listaPaquetes.Count && paquete==null; n++)
        {
            if (MiEmpresa.listaPaquetes[n].ZonaDestino == "3")
            { 
                paquete = MiEmpresa.listaPaquetes[n];
            }
        }
        for (int n = 0; n < MiEmpresa.listaPaquetes.Count && paquete == null; n++)
        {
            if (MiEmpresa.listaPaquetes[n].ZonaDestino == "2")
            {
                paquete = MiEmpresa.listaPaquetes[n];
            }
        }
        for (int n = 0; n < MiEmpresa.listaPaquetes.Count && paquete == null; n++)
        {
            if (MiEmpresa.listaPaquetes[n].ZonaDestino == "1")
            {
                paquete = MiEmpresa.listaPaquetes[n];
            }
        }

        double pesoCamion=MiEmpresa.CargarPaquete(nroCamion, paquete);

        return Ok(pesoCamion);
    }

    [HttpGet("QuitarPaqueteDelCamion")]
    public ActionResult<double> QuitarPaquete(int nroCamion)
    {
        Paquete paquete = null;

        double pesoCamion = MiEmpresa.RetirarPaquete(nroCamion);

        return Ok(pesoCamion);
    }

}
