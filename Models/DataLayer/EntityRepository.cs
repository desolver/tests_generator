using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TestsGenerator.Models.DataLayer
{
    public class EntityRepository : IEntityRepository
    {
        private const string DATABASE_PATH = "Database";

        public void Insert<T>(string entityId, T entity)
        {
            var savePath = GetEntityPath<T>(entityId);
            var json = JsonSerializer.Serialize(entity);

            File.WriteAllText(savePath, json);
        }

        public IReadOnlyList<T> GetAll<T>()
        {
            var entitiesDirectory = GetEntitiesPath<T>();

            if (!Directory.Exists(entitiesDirectory))
                return Array.Empty<T>();

            return Directory
                .GetFiles(entitiesDirectory)
                .Select(File.ReadAllText)
                .Select(entity => JsonSerializer.Deserialize<T>(entity))
                .ToList()!;
        }

        public void Delete<T>(string entityId)
        {
            var entityPath = GetEntityPath<T>(entityId);

            if (!File.Exists(entityPath))
                return;

            File.Delete(entityPath);
        }

        private static string GetEntitiesPath<T>() => Path.Combine(DATABASE_PATH, typeof(T).Name);
        private static string GetEntityPath<T>(string entityId) => Path.Combine(DATABASE_PATH, typeof(T).Name, entityId);
    }
}