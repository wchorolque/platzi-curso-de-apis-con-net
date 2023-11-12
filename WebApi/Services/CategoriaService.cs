public class CategoriaService : ICategoriaService
{
    TareasContext context;
    public CategoriaService(TareasContext dbContext)
    {
        this.context = dbContext;
    }

    public IEnumerable<Categoria> Get()
    {
        return this.context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        this.context.Categorias.Add(categoria);
        await this.context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        Categoria categoriaActual = this.context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        Categoria categoriaActual = this.context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            this.context.Categorias.Remove(categoriaActual);

            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}