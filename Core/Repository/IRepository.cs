namespace Repository
{
    public interface IRepository
    {
        Task<String> Get();
        Task Save();
    }
}
