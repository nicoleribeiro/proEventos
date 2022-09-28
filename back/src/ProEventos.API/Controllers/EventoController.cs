using Microsoft.AspNetCore.Mvc;
using ProEventos.API.models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1º Lote",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "imagem.jpg"
            },
            new Evento(){
                EventoId = 2,
                Tema = "Angular e suas Novidades",
                Local = "São Paulo",
                Lote = "2º Lote",
                QtdPessoas = 300,
                DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                ImagemURL = "imagem1.jpg"
            }
        };
    public EventoController()
    {
        
    }

    [HttpGet(Name = "GetEvento")]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}", Name = "GetById")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(evento => evento.EventoId == id);
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
