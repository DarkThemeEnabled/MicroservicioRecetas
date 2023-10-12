namespace Application.Interfaces
{
    public interface IUserIngredienteService
    {
        dynamic GetByID(int Id);
        dynamic GetByName(string Name);
    }
}
