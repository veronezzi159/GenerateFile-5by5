using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    //Implementa a interface e contem a logica real que posteriormente tratarei com o proxy
    public class SqlRepository : ISqlRepository
    {
        private readonly string connSql;
        private readonly SqlConnection conn;

        public SqlRepository()
        {
            connSql = "Data Source=127.0.0.1;" + // Server
                      "Initial Catalog=Radar;" + // DataBase
                      "User Id=sa; Password=SqlServer2019!;" + // User and Password
                      "TrustServerCertificate=Yes;"; // Certificate

            conn = new SqlConnection(connSql);
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
    }
}
