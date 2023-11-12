public class TareaService : ITareaService
{
    TareasContext context;
    public TareaService(TareasContext dbContext)
    {
        this.context = dbContext;
    }

    public async Task Delete(Guid id)
    {
        Tarea tareaActual = this.context.Tareas.Find(id);
        if (tareaActual != null)
        {
            this.context.Remove(tareaActual);

            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Tarea> Get()
    {
        return this.context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        this.context.Add(tarea);
        await this.context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        Tarea tareaActual = this.context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.Prioridad = tarea.Prioridad;
            tareaActual.FechaCreacion = tarea.FechaCreacion;

            await context.SaveChangesAsync();
        }
    }
}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}