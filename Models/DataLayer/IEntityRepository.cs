using System.Collections.Generic;

namespace TestsGenerator.Models.DataLayer
{
    public interface IEntityRepository
    {
        void Insert<T>(string entityId, T entity);
        IReadOnlyList<T> GetAll<T>();
    }
}