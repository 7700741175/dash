using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dash_API.Models
{
    public class ListaAmbientesDto
    {
        public string Ambiente { get; set; }
        public string Servidor { get; set; }
        public string Diretorio { get; set; }
        public string url { get; set; }
        public string Atualizacao { get; set; }
        public string versao { get; set; }
        public string Inclusao { get; set; }
    }
}