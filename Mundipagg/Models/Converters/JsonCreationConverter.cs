using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mundipagg.Models.Converters
{
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        public string typeName;
        public Dictionary<string, System.Type> dic;

        protected T Create(System.Type objectType, JObject jsonObject)
        {
            JToken token;
            if (!jsonObject.TryGetValue(typeName, out token))
                return (T)Activator.CreateInstance(objectType);
            foreach (var type in dic)
                if (type.Key.Equals(token.ToString()))
                    return (T)Activator.CreateInstance(type.Value);
            return (T)Activator.CreateInstance(objectType);
        }

        public override bool CanConvert(System.Type objectType)
        {
#if  NETSTANDARD1_3
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
#else
            return typeof(T).IsAssignableFrom(objectType);
#endif
        }

        public override object ReadJson(JsonReader reader, System.Type objectType,
          object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value,
       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}