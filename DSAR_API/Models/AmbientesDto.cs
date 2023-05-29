using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dash_API.Models
{
    public class AmbientesDto
    {
        public string Servidor { get; set; }
        public List<ListaDados> Dados { get; set; }
    }

    public class ListaDados
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Arquivo { get; set; }
    }
}