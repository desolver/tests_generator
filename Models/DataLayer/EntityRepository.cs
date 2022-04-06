﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TestsGenerator.Models.DataLayer
{
    public class EntityRepository : IEntityRepository
    {
        private const string DATABASE_PATH = "DataBase";

        public void Insert<T>(string entityId, T entity)
        {
            var savePath = GetSavePath<T>(entityId);
            var json = JsonSerializer.Serialize(entity);

            File.WriteAllText(savePath, json);
        }

        public IReadOnlyList<T> GetAll<T>()
        {
            var entitiesDirectory = GetEntitiesPath<T>();

            if (Directory.Exists(entitiesDirectory))
                Directory.CreateDirectory(entitiesDirectory);

            return Directory
                .GetFiles(entitiesDirectory)
                .Select(File.ReadAllText)
                .Select(entity => JsonSerializer.Deserialize<T>(entity))
                .ToList()!;
        }

        private static string GetEntitiesPath<T>() => Path.Combine(DATABASE_PATH, typeof(T).Name);
        private static string GetSavePath<T>(string entityId) => Path.Combine(DATABASE_PATH, typeof(T).Name, entityId);
    }
}