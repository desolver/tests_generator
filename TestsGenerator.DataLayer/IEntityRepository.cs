using System.Collections.Generic;

namespace TestsGenerator.DataLayer
{
    public interface IEntityRepository
    {
        void Insert<T>(string entityId, T entity);
        IReadOnlyList<T> GetAll<T>();
        void Delete<T>(string entityId);
    }
}