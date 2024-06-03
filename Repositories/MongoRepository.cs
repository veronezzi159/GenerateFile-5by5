using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MongoRepository : IMongoRepository
    {
        private readonly string ConnMongo;
        private readonly string DataBaseMongo;
        private readonly string CollectionMongo;
        private readonly MongoClient mongoclient;

        public MongoRepository()
        {
            ConnMongo = "mongodb://root:Mongo%402024%23@localhost:27017/";
            DataBaseMongo = "Radar";
            CollectionMongo = "Infracoes";
            mongoclient = new MongoClient(ConnMongo);
        }

        public List<Infracao> ReturnMongo()
        {
            List<Infracao> infracoes = new List<Infracao>();
            try
            {

                var client = new MongoClient(ConnMongo);
                var database = client.GetDatabase(DataBaseMongo);
                var collection = database.GetCollection<BsonDocument>(CollectionMongo);
                var filter = Builders<BsonDocument>.Filter.Empty;
                var documentos = collection.Find(filter).ToList();

                foreach (var doc in documentos)
                {
                    Infracao infra = new Infracao()
                    {
                        Concessionaria = doc.GetValue("Concessionaria").AsString,
                        AnoDoPnvSnv = doc.GetValue("AnoPnvSnv").AsString,
                        TipoDeRadar = doc.GetValue("TipoRadar").AsString,
                        Rodovia = doc.GetValue("Rodovia").AsString,
                        Uf = doc.GetValue("UF").AsString,
                        KmM = doc.GetValue("Km").AsString,
                        Municipio = doc.GetValue("Municipio").AsString,
                        TipoPista = doc.GetValue("TipoPista").AsString,
                        Sentido = doc.GetValue("Sentido").AsString,
                        Situacao = doc.GetValue("Situacao").AsString,
                        DataDaInativacao = null,
                        Latitude = doc.GetValue("Latitude").AsString,
                        Longitude = doc.GetValue("Longitude").AsString,
                        VelocidadeLeve = doc.GetValue("Velocidade").AsString
                    };
                    infracoes.Add(infra);
                }

                Console.WriteLine();


            }
            catch (Exception)
            {

                throw;
            }
            return infracoes;
        }

    }
}
