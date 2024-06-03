using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    //Aqui eu to criando a interface que eu vou atribuir os metodos obrigatorios a quem herdar
    public interface ISqlRepository
    {
        List<Infracao> ReturnSql();
    }
}
