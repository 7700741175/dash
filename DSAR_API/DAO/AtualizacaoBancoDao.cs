using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Dash_API.DAO
{
    public class AtualizacaoBancoDao
    {

        public static DataView GetAtualizacaoBanco()
        {
            string sql = "SELECT  name BANCO,  crdate DATA FROM sysdatabases WHERE name LIKE 'DB_PREPRD%' ORDER BY 1";
            DataView dv = Conexao.ConexaoDao.ExecutaConsulta("Conexao", sql);
            return dv;
        }

    }
}