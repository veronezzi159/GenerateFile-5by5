using Models;
using Controller;
using Models;

GeneratorController controller = new GeneratorController();
int option = 0;

do
{
    option = Menu.MenuStart();
    switch (option)
    {
        case 1:
            controller.GenerateXml();
            Menu.MenuProgress();
            break;
        case 2:
            controller.GenerateCsv();
            Menu.MenuProgress();
            break;
        case 3:
            controller.GenerateJson();
            Menu.MenuProgress();
            break;
        case 4:
            controller.GenerateXmlFromMongo();
            Menu.MenuProgress();
            break;
        case 5:
            controller.GenerateCsvFromMongo();
            Menu.MenuProgress();
            break;
        case 6:
            controller.GenerateJsonFromMongo();
            Menu.MenuProgress();
            break;
        case 0:
            Menu.MenuEnd();
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

} while (option != 0);
