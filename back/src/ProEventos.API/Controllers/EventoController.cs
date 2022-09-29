using Microsoft.AspNetCore.Mvc;
using ProEventos.API.data;
using ProEventos.API.models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _contexto;

    public IEnumerable<Evento> _evento = new Evento[]{
    
    };

    public EventoController(DataContext contexto)
    {
            this._contexto = contexto;
        
    }

    [HttpGet(Name = "GetEvento")]
    public IEnumerable<Evento> Get()
    {
        return _contexto.Eventos;
    }

    [HttpGet("{id}", Name = "GetById")]
    public Evento GetById(int id)
    {
        return _contexto.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }

    [HttpPost(Name = "PostEvento")]
    public string Post()
    {
        return "exemplo de post";
    }

    [HttpPut("{id}", Name = "PutEvento")]
    public string Put(int id)
    {
        return $"exemplo de put com id = {id}";
    }

    [HttpDelete("{id}", Name = "DeleteEvento")]
    public string Delete(int id)
    {
        return $"exemplo de Delete com id = {id}";
    }
}
