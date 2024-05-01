namespace PIMFazendaUrbana
{
    public partial class TelaListarClientes : Form
    {
        ClienteDAO clienteDAO; // Declaração de uma instância de ClienteDAO
        ClienteService clienteService; // Declaração de uma instância de ClienteService

        public TelaListarClientes()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados

            clienteDAO = new ClienteDAO(connectionString); // Cria uma instância de ClienteDAO passando a string de conexão como parâmetro
            clienteService = new ClienteService(clienteDAO); // Cria uma instância de ClienteService passando o clienteDAO como parâmetro

            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            dataGridViewListaClientes.AutoGenerateColumns = false;

            // Adicione manualmente as colunas necessárias
            dataGridViewListaClientes.Columns.Add("IDColumn", "ID");
            dataGridViewListaClientes.Columns.Add("NomeColumn", "Nome");
            dataGridViewListaClientes.Columns.Add("EmailColumn", "Email");
            dataGridViewListaClientes.Columns.Add("CNPJColumn", "CNPJ");
            dataGridViewListaClientes.Columns.Add("TelefoneColumn", "Telefone");
            dataGridViewListaClientes.Columns.Add("EnderecoColumn", "Endereço");
            dataGridViewListaClientes.Columns.Add("CEPColumn", "CEP");

            // Configurar as propriedades DataPropertyName das colunas
            dataGridViewListaClientes.Columns["IDColumn"].DataPropertyName = "ID";
            dataGridViewListaClientes.Columns["NomeColumn"].DataPropertyName = "Nome";
            dataGridViewListaClientes.Columns["EmailColumn"].DataPropertyName = "Email";
            dataGridViewListaClientes.Columns["CNPJColumn"].DataPropertyName = "CNPJ";
            dataGridViewListaClientes.Columns["TelefoneColumn"].DataPropertyName = "Telefone"; // Aqui você deve configurar a propriedade do Telefone
            dataGridViewListaClientes.Columns["EnderecoColumn"].DataPropertyName = "Endereco"; // Aqui você deve configurar a propriedade do Endereco
            dataGridViewListaClientes.Columns["CEPColumn"].DataPropertyName = "CEP"; // Aqui você deve configurar a propriedade do Endereco

            // Configurar o modo de redimensionamento das colunas
            foreach (DataGridViewColumn column in dataGridViewListaClientes.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void TelaListarClientes_Load(object sender, EventArgs e)
        {
            ListarClientesAtivosDataGrid();
        }

        private void ListarClientesAtivosDataGrid()
        {
            try
            {
                List<Cliente> clientes = clienteService.ListarClientesAtivos();

                // Verificar se a lista de clientes não está vazia
                if (clientes != null && clientes.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = clientes.Select(c => new
                    {
                        c.ID,
                        c.Nome,
                        c.Email,
                        CNPJ = FormatarCNPJ(c.CNPJ), // Formatar o CNPJ
                        Telefone = FormatarTelefone(c.Telefone), // Formatar o telefone
                        Endereco = FormatarEndereco(c.Endereco), // Formatar o endereço
                        CEP = FormatarCEP(c.Endereco) // Formatar o CEP
                    }).ToList();

                    // Preencher o DataGridView com os dados formatados
                    dataGridViewListaClientes.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para formatar o telefone
        private string FormatarTelefone(TelefoneCliente telefone)
        {
            string numeroFormatado = telefone.Numero;

            // Verifica o tamanho do número de telefone
            if (numeroFormatado.Length == 8)
            {
                // Insere o hífen após os 4 primeiros dígitos
                numeroFormatado = $"{numeroFormatado.Substring(0, 4)}-{numeroFormatado.Substring(4)}";
            }
            else if (numeroFormatado.Length == 9)
            {
                // Insere o hífen após os 5 primeiros dígitos
                numeroFormatado = $"{numeroFormatado.Substring(0, 5)}-{numeroFormatado.Substring(5)}";
            }

            // Formata a exibição do telefone como (DDD) Número
            return $"({telefone.DDD}) {numeroFormatado}";
        }

        // Método para formatar o endereço
        private string FormatarEndereco(EnderecoCliente endereco)
        {
            string enderecoFormatado = $"{endereco.Logradouro}, {endereco.Numero}";

            if (!string.IsNullOrWhiteSpace(endereco.Complemento))
            {
                enderecoFormatado += $", {endereco.Complemento}";
            }

            enderecoFormatado += $", {endereco.Bairro}, {endereco.Cidade} - {endereco.UF}";

            // Retorna o endereço formatado
            return enderecoFormatado;
        }

        // Método para formatar o CEP
        private object FormatarCEP(EnderecoCliente endereco)
        {
            string cepFormatado = endereco.CEP;

            // Insere o hífen no CEP
            if (cepFormatado.Length == 8)
            {
                cepFormatado = $"{cepFormatado.Substring(0, 5)}-{cepFormatado.Substring(5)}";
            }

            return cepFormatado;
        }

        // Método para formatar o CNPJ
        private object FormatarCNPJ(string cnpj)
        {
            string cnpjFormatado = cnpj;

            // Insere os pontos e a barra no CNPJ
            if (cnpjFormatado.Length == 14)
            {
                cnpjFormatado = $"{cnpjFormatado.Substring(0, 2)}.{cnpjFormatado.Substring(2, 3)}.{cnpjFormatado.Substring(5, 3)}/{cnpjFormatado.Substring(8, 4)}-{cnpjFormatado.Substring(12)}";
            }

            return cnpjFormatado;
        }


    }
}
