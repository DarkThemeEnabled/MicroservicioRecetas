namespace Application.Interfaces
{
    public interface ICategoriaRecetaService
    {
        Task<bool> ValidateCategoriaRecetaById(int categoriaRecetaId);
    }
}
