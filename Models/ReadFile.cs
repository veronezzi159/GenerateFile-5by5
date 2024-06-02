using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReadFile
    {
        public static List<Infracao> GetData(string path, string file)
        {
            StreamReader reader = new StreamReader(path + file);
            string json = reader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<Radar>(json);

            if (list != null) return list.infracoes;
            return null;
        }
    }
}
