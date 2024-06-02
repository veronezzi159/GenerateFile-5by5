using Repositories;

namespace Service
{
    public class GeneratorServices
    {
        GeneratorRepository repository = new GeneratorRepository();

        public bool GenerateXml()
        {
            return repository.GenerateXML(repository.ReturnSql(), 0);
        }

        public bool GenerateCsv()
        {
            return repository.GenerateCsv(repository.ReturnSql(), 0);
        }
        public bool GenerateJson()
        {
            return repository.GenerateJson(repository.ReturnSql(), 0);
        }

        public bool GenerateXmlFromMongo()
        {
            return repository.GenerateXML(repository.ReturnMongo(), 1);
        }
        public bool GenerateCsvFromMongo()
        {
            return repository.GenerateCsv(repository.ReturnMongo(), 1);
        }

        public bool GenerateJsonFromMongo()
        {
            return repository.GenerateJson(repository.ReturnMongo(), 1);
        }
    }
}
