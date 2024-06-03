using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MongoProxy : IMongoRepository
    {
        private readonly MongoRepository _mongorepository;
        public MongoProxy()
        {
            _mongorepository = new MongoRepository();
        }

        public List<Infracao> ReturnMongo()
        {
            return _mongorepository.ReturnMongo();
        }
    }
}
