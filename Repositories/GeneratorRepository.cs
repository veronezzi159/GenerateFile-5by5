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
        string connSql;
        SqlConnection conn;

        string ConnMongo;
        string DataBaseMongo;
        string CollectionMongo;


        public GeneratorRepository()
        {
            connSql += "Data Source=127.0.0.1;"; // Server
            connSql += "Initial Catalog=Radar;"; //DataBase
            connSql += " User Id=sa; Password=SqlServer2019!;";//User and Password
            connSql += "TrustServerCertificate=Yes;";//certificate

            conn = new SqlConnection(connSql);

            ConnMongo = "mongodb://root:Mongo%402024%23@localhost:27017/";
            DataBaseMongo = "Radar";
            CollectionMongo = "Infracoes";
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


        public List<Infracao> ReturnSql()
        {
            List<Infracao> infracoes = new List<Infracao>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve " +
                            "FROM RadarInfo", conn);
                cmd.Connection = conn;
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Infracao infra = new Infracao()
                        {
                            Concessionaria = reader.GetString(0),
                            AnoDoPnvSnv = reader.GetString(1),
                            TipoDeRadar = reader.GetString(2),
                            Rodovia = reader.GetString(3),
                            Uf = reader.GetString(4),
                            KmM = reader.GetString(5),
                            Municipio = reader.GetString(6),
                            TipoPista = reader.GetString(7),
                            Sentido = reader.GetString(8),
                            Situacao = reader.GetString(9),
                            DataDaInativacao = reader.GetString(10).Split(new[] { ", " }, StringSplitOptions.None),
                            Latitude = reader.GetString(11),
                            Longitude = reader.GetString(12),
                            VelocidadeLeve = reader.GetString(13)
                        };
                        infracoes.Add(infra);
                    }
                return infracoes;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                conn.Close();
            }
        }

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
                File.Create(path + file);
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
                    sw.WriteLine($"{item.Concessionaria}; {item.AnoDoPnvSnv}; {item.TipoDeRadar}; {item.Rodovia}; {item.Uf}; {item.KmM}; {item.Municipio}; {item.TipoPista}; {item.Sentido}; {item.Situacao}; {item.DataDaInativacao}; {item.Latitude}; {item.Longitude}; {item.VelocidadeLeve}");
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
            Radar r = new Radar();
            r.infracoes = lst;
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
                    File.Create(path + file);
                }
                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(JsonConvert.SerializeObject(r));
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
