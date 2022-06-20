using Library.Core.Entities;

namespace Library.Core.Abstractions
{
    public interface IDvdRepository: IRepository<Dvd>
    {
        bool IsDvdAvailable(int id);
    }
}