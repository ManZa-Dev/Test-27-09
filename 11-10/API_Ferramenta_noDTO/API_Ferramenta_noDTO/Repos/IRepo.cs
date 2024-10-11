namespace API_Ferramenta_test.Repos
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T? GetByCodice(string cod);
        bool Create(T t);
        bool Update(T t);
        bool Delete(string cod);
    }
}
