using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    //Aqui eu posso alterar o metodo criando a regra de negocio que eu quiser
    //Exemplo: se eu tivesse feito com inserção aqui eu poderia antes de inserir verificar o tamanho da inserção e tratar por blocos
    public class SqlRepositoryProxy : ISqlRepository
    {
        private readonly SqlRepository _sqlRepository;

        public SqlRepositoryProxy()
        {
            _sqlRepository = new SqlRepository();
        }

        public List<Infracao> ReturnSql()
        {
            return _sqlRepository.ReturnSql();
        }
    }

}
