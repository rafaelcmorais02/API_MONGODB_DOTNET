using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using api.Data.Collections;
using System;

namespace api.Data
{
    public class MongoDbClass
    {
        public IMongoDatabase DB {get;}

        public MongoDbClass(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possível se conectar ao mongo", ex);
            }
        }
        private void MapClasses()
        {
            var conventionPack =new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t=>true);
            if(!BsonClassMap.IsClassMapRegistered(typeof(Infectados)))
            {
                BsonClassMap.RegisterClassMap<Infectados>(i=>
                    {
                        i.AutoMap();
                        i.SetIgnoreExtraElements(true);
                    }
                );
            }


        }
    }
}