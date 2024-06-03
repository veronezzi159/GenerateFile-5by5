using Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Xml.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Data.SqlClient;


namespace Repositories
{
    public class GeneratorRepository
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly IMongoRepository _mongoRepository;
        public GeneratorRepository()
        {
            _sqlRepository = new SqlRepositoryProxy();
            _mongoRepository = new MongoProxy();
        }
        public List<Infracao> ReturnSql()
        {
            return _sqlRepository.ReturnSql();
        }
        public List<Infracao> ReturnMongo()
        {
            return _mongoRepository.ReturnMongo();
        }
        #region Generates
        public bool GenerateXML(List<Infracao> lst, int option)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
            string file = option == 1 ? "Infracoes.xml" : "InfracoesMongo.xml";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + file))
            {
                var x =  File.Create(path + file);
                x.Close();
            }
            if (lst.Count > 0)
            {
                var infracao = new XElement("Root", from infra in lst
                                                    select new XElement("Infracao",
                                                        new XElement("Concessionaria", infra.Concessionaria),
                                                        new XElement("AnoDoPnvSnv", infra.AnoDoPnvSnv),
                                                        new XElement("TipoDeRadar", infra.TipoDeRadar),
                                                        new XElement("Rodovia", infra.Rodovia),
                                                        new XElement("Uf", infra.Uf),
                                                        new XElement("KmM", infra.KmM),
                                                        new XElement("Municipio", infra.Municipio),
                                                        new XElement("TipoPista", infra.TipoPista),
                                                        new XElement("Sentido", infra.Sentido),
                                                        new XElement("Situacao", infra.Situacao),
                                                        new XElement("DataDaInativacao", infra.DataDaInativacao),
                                                        new XElement("Latitude", infra.Latitude),
                                                        new XElement("Longitude", infra.Longitude),
                                                        new XElement("VelocidadeLeve", infra.VelocidadeLeve)
                                                    )
                );

                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(infracao);
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GenerateCsv(List<Infracao> lst, int option)
        {
            if (lst.Count > 0)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string file = option == 1 ? "Infracoes.csv" : "InfracoesMongo.csv";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(path + file))
                {
                    var x = File.Create(path + file);
                    x.Close();
                }

                StreamWriter sw = new StreamWriter(path + file);

                sw.WriteLine("Concessionaria, AnoDoPnvSnv, TipoDeRadar, Rodovia, Uf, KmM, Municipio, TipoPista, Sentido, Situacao, DataDaInativacao, Latitude, Longitude, VelocidadeLeve");

                foreach (var item in lst)
                {
                    if (item.DataDaInativacao == null)
                    {
                     sw.WriteLine($"{item.Concessionaria}; {item.AnoDoPnvSnv}; {item.TipoDeRadar}; {item.Rodovia}; {item.Uf}; {item.KmM}; {item.Municipio}; {item.TipoPista}; {item.Sentido}; {item.Situacao}; {null}; {item.Latitude}; {item.Longitude}; {item.VelocidadeLeve}");

                    }
                    else
                    {
                        foreach(var data in item.DataDaInativacao)
                        sw.WriteLine($"{item.Concessionaria}; {item.AnoDoPnvSnv}; {item.TipoDeRadar}; {item.Rodovia}; {item.Uf}; {item.KmM}; {item.Municipio}; {item.TipoPista}; {item.Sentido}; {item.Situacao}; {data}; {item.Latitude}; {item.Longitude}; {item.VelocidadeLeve}");
                    }
                }
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GenerateJson(List<Infracao> lst, int option)
        {
            if (lst.Count > 0)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                string file = option == 1 ? "Infracoes.json" : "InfracoesMongo.json";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(path + file))
                {

                    var x = File.Create(path + file);
                    x.Close();
                }
                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(JsonConvert.SerializeObject(lst));
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
