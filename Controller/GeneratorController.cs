using Service;

namespace Controller
{
    public class GeneratorController
    {
        GeneratorServices services = new GeneratorServices();

        public void GenerateXml()
        {
            if (services.GenerateXml()) Console.WriteLine("Xml gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Xml");
        }
        public void GenerateCsv()
        {
            if (services.GenerateCsv()) Console.WriteLine("Csv gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Csv");
        }
        public void GenerateJson()
        {
            if (services.GenerateJson()) Console.WriteLine("Json gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Json");
        }
        public void GenerateXmlFromMongo()
        {
            if (services.GenerateXmlFromMongo()) Console.WriteLine("Xml do Mongo gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Xml");
        }
        public void GenerateCsvFromMongo()
        {
            if (services.GenerateCsvFromMongo()) Console.WriteLine("Csv do Mongo gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Csv");
        }
        public void GenerateJsonFromMongo()
        {
            if (services.GenerateJsonFromMongo()) Console.WriteLine("Json do Mongo gerado com sucesso");
            else Console.WriteLine("Erro ao gerar Json");
        }
    }
}
