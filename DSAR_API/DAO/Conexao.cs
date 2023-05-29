using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Dash_API.DAO
{
    public class Conexao
    {
        public class ConexaoDao
        {
            #region Atributos
            protected string strConn = string.Empty;
            protected SqlConnection cn = null;
            protected SqlCommand cmd = null;
            string LstrSql = "";

            #endregion

            #region Propriedades
            public string ConnectionString
            {
                get { return this.strConn; }
                set { this.strConn = value; }
            }
            #endregion


            #region Conexao
            protected static string PegaString(string sDataBase)
            {
                return ConfigurationManager.ConnectionStrings[sDataBase].ToString();

            }
            #endregion


            #region Regras
            public static bool ExecuteNonQuery(string sDataBase, string sql)
            {

                try
                {
                    string LstrConexao = PegaString(sDataBase);
                    SqlConnection cnn = new SqlConnection(LstrConexao);
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    return true;
                }
                catch (SqlException ex)
                {

                    return false;
                }
            }

            public static DataView ExecutaConsulta(string sDataBase, string sql)
            {
                DataSet Ds;
                SqlConnection cnn = new SqlConnection(PegaString(sDataBase));
                SqlCommand cmd;
                SqlDataAdapter da;

                try
                {


                    //cria um objeto DataAdapter
                    da = new SqlDataAdapter();
                    da.TableMappings.Add("Table", "TabelaTemp");

                    cnn.Open();

                    //carrega os dados tabela
                    cmd = new SqlCommand(sql, cnn);
                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.Text;
                    //declaracao SQL para seleionar dados de uma fonte de dados
                    da.SelectCommand = cmd;

                    //dataset
                    Ds = new DataSet("TabelaTemp");
                    da.Fill(Ds);
                    return Ds.Tables[0].DefaultView;

                }

                catch (SqlException ex)
                {

                    return null;
                }

                finally
                {
                    cnn.Close();
                }
            }

            public static DataTable ExecutaTabela(string sDataBase, string sql)
            {
                // define objetos : dataset,connection,command e dataadatper
                DataSet ds = new DataSet();
                SqlConnection cnn = new SqlConnection(PegaString(sDataBase));
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                try
                {



                    // cria um objeto dataadapter
                    da = new SqlDataAdapter();
                    da.TableMappings.Add("Table", "TabelaTemporaria");

                    // abre a conexao
                    cnn.Open();
                    // carrega os dados da tabela categorias
                    cmd = new SqlCommand(sql, cnn);
                    cmd.CommandTimeout = 300;
                    cmd.CommandType = CommandType.Text;
                    // declaracao SQL para seleionar dados de uma fonte de dados
                    da.SelectCommand = cmd;
                    // preenche o dataset com os dados e define o nome da tabela como categorias
                    ds = new DataSet("TabelaTemporaria");
                    da.Fill(ds);
                    // retorna um objeto dataview default para o datatable
                    return ds.Tables[0];

                }
                catch (SqlException ex)
                {

                    return null;
                }

                finally
                {
                    cnn.Close();
                }

            }



            public static string LeItem(string sDataBase, string sql)
            {
                try
                {
                    SqlConnection cnn = new SqlConnection(PegaString(sDataBase)); ;
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    string sRetorno = "";
                    cnn.Open();
                    cmd.CommandTimeout = 300;
                    SqlDataReader Dr = cmd.ExecuteReader();
                    while (Dr.Read())
                    {
                        if (!Dr.IsDBNull(0))
                            sRetorno = Dr.GetValue(0).ToString();
                    }
                    cnn.Close();
                    return sRetorno;
                }

                catch (SqlException ex)
                {

                    return "";
                }
            }

            #endregion
        }
    }
}