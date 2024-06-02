using Newtonsoft.Json;
namespace Models
{
    public class Infracao
    {
        [JsonProperty("concessionaria")]
        public string Concessionaria { get; set; }
        [JsonProperty("ano_do_pnv_snv")]
        public string AnoDoPnvSnv { get; set; }
        [JsonProperty("tipo_de_radar")]
        public string TipoDeRadar { get; set; }
        [JsonProperty("rodovia")]
        public string Rodovia { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("km_m")]
        public string KmM { get; set; }
        [JsonProperty("municipio")]
        public string Municipio { get; set; }
        [JsonProperty("tipo_pista")]
        public string TipoPista { get; set; }
        [JsonProperty("sentido")]
        public string Sentido { get; set; }
        [JsonProperty("situacao")]
        public string Situacao { get; set; }
        [JsonProperty("data_da_inativacao")]
        public string[] DataDaInativacao { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        [JsonProperty("velocidade_leve")]
        public string VelocidadeLeve { get; set; }

        public override string ToString() => $"Concessionaria: {Concessionaria}, AnoDoPnvSnv: {AnoDoPnvSnv}, TipoDeRadar: {TipoDeRadar}, Rodovia: {Rodovia}, " +
            $"Uf: {Uf}, KmM: {KmM}, Municipio: {Municipio}, TipoPista: {TipoPista}, Sentido: {Sentido}, Situacao: {Situacao}, DataDaInativacao: {DataDaInativacao}, " +
            $"Latitude: {Latitude}, Longitude: {Longitude}, VelocidadeLeve: {VelocidadeLeve}";

    }
}
