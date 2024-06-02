using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Menu
    {
        public static int MenuStart()
        {
            int op = 0;
            Console.WriteLine("Digete sua opção");
            Console.WriteLine("1 - Converter do SQL para XML");
            Console.WriteLine("2 - Converter do SQL para CSV");
            Console.WriteLine("3 - Converter do SQL para JSON");
            Console.WriteLine("4 - Converter do Mongo para XML");
            Console.WriteLine("5 - Converter do Mongo para CSV");
            Console.WriteLine("6 - Converter do Mongo para JSON");
            Console.WriteLine("0 - Sair");
            do
            {
                try
                {
                    op = int.Parse(Console.ReadLine());
                    if (op > 7 || op < 0) Console.WriteLine("opção Invalida");
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor invalido");
                }
            } while (op > 7 || op < 0);

            return op;
        }

        public static void MenuProgress()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadKey();
        }
        public static void MenuEnd()
        {
            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
    }
}
