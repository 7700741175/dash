using Dash_API.DAO;
using Dash_API.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Dash_API.Business
{
    public class AtualizacaoBancoBll
    {

        public static List<AtualizacaoBancoDto> GetAtualizacaoBancos()
        {
            List<AtualizacaoBancoDto> Lista = new List<AtualizacaoBancoDto>();
            DataView dv = AtualizacaoBancoDao.GetAtualizacaoBanco();
            foreach (DataRowView row in dv)
            {
                Lista.Add(new AtualizacaoBancoDto { Banco = row["Banco"].ToString(), Data = row["Data"].ToString() });
            }
            return Lista;
        }
    }
}