

namespace Projeto_Web_LH_Pets
{
    public class Banco
    {
        
        private List<Cliente> lista = new List<Cliente>();

        public List<Cliente> Getlista (){
            return lista;
        }
        public string GetlistaString() {

            string enviar =  <!DOCTYPE html>
<head><meta charset="UTF-8"/><title>Web Site Lh Pets</title></head>
<body style="background-color:#73f05c ">
    <h1>Lista de Cliente </h1>
    <table><thead><tr> +
    <th>CPF/CNPJ</th> +
    <th>/Nome</th> +
    <th>Endereço</th> +
    <th>RG/IE</th> +
    <th>Tipo</th> +
    <th>Valor</th> +
    <th>Valor Imposto/th> +
    <th>Total</th> +
</body>
</html>
</thead><tbody>;
    foreach (Cliente cli in Getlista()){
        enviar += "<tr>" +
        $"<td>{cli.cpf_cnpj}</td>"
        $"<td>{cli.nome}</td>"
        $"<td>{cli.endereco}</td>"
        $"<td>{cli.rg_ie}</td>"
        $"<td>{cli.tipo}</td>"
        $"<td>{cli.valor.ToString("C")}</td>"
        $"<td>{cli.valor_imposto.ToString("C")}</td>"
        $"<td>{cli.total.ToString("C")}</td>" +
        "</tr";

    }
    enviar += "</tbody><table><body></html>";
    return enviar;
        }
        public Banco (){

            try{

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                    "User ID=sa;Password=1234;" +
                    "Server=localhost\\SQLEXPRESS2;" +
                    "Database=vendas;" +
                    "Trusted_Connection=false;" +
                );

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                    string sql = "SELECT * FROM tblclientes";
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn)){
                        conn.Open();

                        using (SqlDataReader tabela = cmd.ExecuteReader()){

                            while(tabela.Read(){
                                lista.Add(new Cliente(){
                                    cpf_cnoj = tabela["cpf_cnpj"].ToString(),
                                    nome = tabela["nome"].ToString(),
                                    endereco = tabela["endereco"].ToString(),
                                    rg_ie = tabela["rg_ie"].ToString(),
                                    tipo = tabela["tipo"].ToString(),
                                    valor = (float)Convert.ToDecimal(tabela["valor"]),
                                    valor_imposto = (float)Convert.ToDecimal(tabela["valor_imposto"]),
                                    total = (float)Convert.ToDecimal(tabela["total"]),

                                });
                            })
                        }
                    } 
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}