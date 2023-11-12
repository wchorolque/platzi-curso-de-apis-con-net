using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    protected readonly ICategoriaService categoriaService;
    public CategoriaController(ICategoriaService service)
    {
        this.categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this.categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Categoria categoria)
    {
        this.categoriaService.Save(categoria);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put(Guid id, [FromBody]Categoria categoria)
    {
        this.categoriaService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        this.categoriaService.Delete(id);
        return Ok();
    }
}