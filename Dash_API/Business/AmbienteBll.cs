using Dash_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Dash_API.Business
{
    public class AmbienteBll
    {
        public static List<ListaAmbientesDto> RetornaAmbiente()
        {
            //le lista de ambientes

            string virtualPath = "~/Ambientes.json";
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);
            AmbientesDto dataList;
            List<ListaDados> ListaDados;
            using (StreamReader reader = new StreamReader(physicalPath))
            {
                string json = reader.ReadToEnd();
                dataList = JsonConvert.DeserializeObject<AmbientesDto>(json);
            }
            //pega ambientes
            string NomeServidor = dataList.Servidor;
            ListaDados = dataList.Dados;
            string sdata;
            //pega lista de deploys
            List<DeployDto> ListaDep = new List<DeployDto>();
            List<ListaAmbientesDto> ListaAmb = new List<ListaAmbientesDto>();

            foreach (ListaDados Item in ListaDados)
            {
                physicalPath = Item.Local + Item.Arquivo;
                using (StreamReader reader = new StreamReader(physicalPath))
                {
                    string json = reader.ReadToEnd();
                    ListaDep = JsonConvert.DeserializeObject<List<DeployDto>>(json);
                }
                foreach (DeployDto ItemDp in ListaDep)
                {
                    if (ItemDp.status == "DEPLOYED")
                    {
                        if (ItemDp.init_date == null)
                            sdata = ItemDp.date;
                        else
                            sdata = ItemDp.init_date;

                            ListaAmb.Add(new ListaAmbientesDto
                        {
                            Ambiente = Item.Nome,
                            Atualizacao = ItemDp.last_change_date,
                            versao = ItemDp.version,
                            Diretorio = ItemDp.dir,
                            url = ItemDp.nexus_url,
                            Inclusao = sdata,
                            Servidor = NomeServidor,
                        });
                    }
                }
            }
            return ListaAmb;
        }

        public static List<DeployDto> RetornaDeploy(string NomeAmbiente)
        {
            //le lista de ambientes

            string virtualPath = "~/Ambientes.json";
            string physicalPath = HttpContext.Current.Server.MapPath(virtualPath);
            AmbientesDto dataList;
            List<ListaDados> ListaDados;
            using (StreamReader reader = new StreamReader(physicalPath))
            {
                string json = reader.ReadToEnd();
                dataList = JsonConvert.DeserializeObject<AmbientesDto>(json);
            }
            //pega ambientes
            string NomeServidor = dataList.Servidor;
            ListaDados = dataList.Dados;

            //pega lista de deploys
            List<DeployDto> ListaDep = new List<DeployDto>();

            foreach (ListaDados Item in ListaDados)
            {
                if (Item.Nome == NomeAmbiente)
                {
                    physicalPath = Item.Local + Item.Arquivo;
                    using (StreamReader reader = new StreamReader(physicalPath))
                    {
                        string json = reader.ReadToEnd();
                        ListaDep = JsonConvert.DeserializeObject<List<DeployDto>>(json);
                    }
                }
            }
            return ListaDep;
        }
    }
}
