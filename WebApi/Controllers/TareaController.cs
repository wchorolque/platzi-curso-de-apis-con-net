using Microsoft.AspNetCore.Mvc;

public class TareaController: ControllerBase 
{
    protected readonly ITareaService tareaService;

    public TareaController(ITareaService service)
    {
        this.tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this.tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Tarea tarea)
    {
        this.tareaService.Save(tarea);
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Put(Guid id, [FromBody]Tarea tarea)
    {
        this.tareaService.Update(id, tarea);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        this.tareaService.Delete(id);
        return Ok();
    }
}