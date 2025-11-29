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
        if (manifiesto == null || manifiesto.Length == 0)
            return BadRequest("No se ha proporcionado ningún archivo");

        try
        {
            //using Stream stream = new MemoryStream();
            //await file.CopyToAsync(stream);
            //stream.Position = 0;
            // MiEmpresa.Descargar(stream);

            MiEmpresa.Descargar(manifiesto.OpenReadStream());
            return Ok("Archivo procesado correctamente");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error al procesar el archivo: {ex.Message}");
        }
    }
       
    [HttpGet("listaPaquetes")]
    public ActionResult<List<Paquete>> GetListaPaquetes()
    {
        if (MiEmpresa.listaPaquetes == null || MiEmpresa.listaPaquetes.Count == 0)
            return NotFound("No hay paquetes");

        return Ok(MiEmpresa.listaPaquetes);
    }

    [HttpGet("CamionesCargados")]
    public ActionResult<string[]> GetCamionesCargados()
    {
        string[] camiones = MiEmpresa.CamionesCargados();

        if (camiones == null || camiones.Length == 0)
            return NotFound("No hay camiones cargados.");

        return Ok(camiones);
    }

    [HttpGet("VerCargaCamion")]
    public ActionResult<List<Paquete>> GetVerCarga(int posicion)
    {
        if (posicion <= 0)
            return BadRequest("posicion de camión es requerido");

        string[] paquetes = MiEmpresa.VerCargaCamion(posicion);

        if (paquetes == null || paquetes.Length == 0) return NotFound("No hay paquetes");

        return Ok(paquetes);
    }

    [HttpGet("AgregarPaqueteDelCamion/{posicion}")]
    public ActionResult<double> GetAgregarPaqueteDelCamion(int posicion)
    {
        try
        {
            if (posicion <= 0)
                return BadRequest("Número de camión es requerido");

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

    [HttpGet("QuitarPaqueteDelCamion")]
    public ActionResult<double> QuitarPaquete(int posicion)
    {
        if (posicion <= 0)
            return BadRequest("posicion de camión es requerido");

        double pesoCamion = MiEmpresa.RetirarPaquete(posicion);

        return Ok(pesoCamion);
    }

    [HttpGet("EnviarCamion")]
    public async Task<IActionResult> GetEnviarCamion(int posicion)
    {
        try
        {
            if (posicion <= 0)
                return BadRequest("posicion de camión es requerido");

            using MemoryStream stream = new MemoryStream();

            MiEmpresa.RetirarCamion(stream, posicion);

            byte[] fileContents = stream.ToArray();

            return File(fileContents, "text/csv", $"camion_{posicion}.csv");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error al procesar el archivo: {ex.Message}");
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
}
