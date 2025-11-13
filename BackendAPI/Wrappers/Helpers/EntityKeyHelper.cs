using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Wrappers.Helpers
{
    public static class EntityKeyHelper
    {
        public static string GetPrimaryKeyName<T>(DbContext context)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var key = entityType.FindPrimaryKey();

            if (key == null)
                throw new InvalidOperationException($"L'entité {typeof(T).Name} ne possède pas de clé primaire.");

            if (key.Properties.Count > 1)
                throw new NotSupportedException($"L'entité {typeof(T).Name} possède une clé composite, non supportée ici.");

            return key.Properties.First().Name;
        }
    }
}
