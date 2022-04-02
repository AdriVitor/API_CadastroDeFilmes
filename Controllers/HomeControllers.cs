using Microsoft.AspNetCore.Mvc;
using Filmes.Models;
using AppDataContext;

namespace FilmesControllers;

    [ApiController]
public class HomeController : ControllerBase{

    [HttpGet("/AllFilmes")]
    public List<FilmeModel> GetAll([FromServices] AppDbContext context){
        return context.FilmeModels.ToList();
    }

    [HttpGet("/{id:int}")]
    public ActionResult<FilmeModel> GetId([FromServices] AppDbContext context,
                                          [FromRoute] int id)
                                          {
                                              
                                              var model = context.FilmeModels.FirstOrDefault(x => x.Id == id);
                                              if(model != null){
                                                return Ok(model);
                                              }else{
                                                  return NotFound(new{message = $"Produto com o id = {id} não encontrado"});
                                              }
                                              
                                          }

    [HttpPost("/")]
    public ActionResult<FilmeModel> PostFilme([FromBody] FilmeModel f,
                                              [FromServices] AppDbContext context){

                                                context.FilmeModels.Add(f);
                                                context.SaveChanges();
                                                return f;
                                               
    }


    [HttpPut("/{id:int}")]
    public ActionResult<FilmeModel> PutFilme([FromRoute] int id,
                                             [FromBody] FilmeModel f,
                                             [FromServices] AppDbContext context){
                                                
                                                 var model = context.FilmeModels.FirstOrDefault(x=>x.Id==id);

                                                 model.Nome = f.Nome;
                                                 model.Genero = f.Genero;
                                                 model.DataDeLancamento = f.DataDeLancamento;
                                                 model.Descricao = f.Descricao;

                                                 context.FilmeModels.Update(model);
                                                 context.SaveChanges();

                                                 return model;
                                                
                                            
                                                
                                             }

    [HttpDelete("/{id:int}")]
    public ActionResult<FilmeModel> DeleteFilme([FromRoute] int id,
                                                [FromServices] AppDbContext context){
                                                   var model = context.FilmeModels.FirstOrDefault(x=>x.Id==id);

                                                    context.FilmeModels.Remove(model);
                                                    context.SaveChanges();

                                                    return Ok("Filme Excluido");
                                                }

    
}