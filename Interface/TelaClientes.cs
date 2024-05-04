namespace PIMFazendaUrbana
{
    public partial class TelaClientes : Form
    {
        ClienteDAO clienteDAO; // Declaração de uma instância de ClienteDAO
        ClienteService clienteService; // Declaração de uma instância de ClienteService

        public TelaClientes()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados

            clienteDAO = new ClienteDAO(connectionString); // Cria uma instância de ClienteDAO passando a string de conexão como parâmetro
            clienteService = new ClienteService(clienteDAO); // Cria uma instância de ClienteService passando o clienteDAO como parâmetro

            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewListaClientes.AutoGenerateColumns = false;

            // Adicione manualmente as colunas necessárias
            DataGridViewListaClientes.Columns.Add("IDColumn", "ID");
            DataGridViewListaClientes.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaClientes.Columns.Add("EmailColumn", "Email");
            DataGridViewListaClientes.Columns.Add("CNPJColumn", "CNPJ");

            DataGridViewListaClientes.Columns.Add("TelefoneColumn", "Telefone");
            DataGridViewListaClientes.Columns.Add("EnderecoColumn", "Endereço");
            DataGridViewListaClientes.Columns.Add("CEPColumn", "CEP");

            // Configurar as propriedades DataPropertyName das colunas
            DataGridViewListaClientes.Columns["IDColumn"].DataPropertyName = "ID";
            DataGridViewListaClientes.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaClientes.Columns["EmailColumn"].DataPropertyName = "Email";
            DataGridViewListaClientes.Columns["CNPJColumn"].DataPropertyName = "CNPJ";

            DataGridViewListaClientes.Columns["TelefoneColumn"].DataPropertyName = "Telefone";
            DataGridViewListaClientes.Columns["EnderecoColumn"].DataPropertyName = "Endereco";
            DataGridViewListaClientes.Columns["CEPColumn"].DataPropertyName = "CEP";

            // Configurar o modo de redimensionamento das colunas
            foreach (DataGridViewColumn column in DataGridViewListaClientes.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void TelaListarClientes_Load(object sender, EventArgs e)
        {
            ListarClientesAtivosDataGrid();
        }

        // Manipulador de eventos para o evento ClienteCadastradoSucesso
        private void TelaCadastrarCliente_ClienteCadastradoSucesso(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        // Método para atualizar o DataGridView
        private void AtualizarDataGridView()
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
                    DataGridViewListaClientes.DataSource = data;
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

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            // Criar uma instância do segundo formulário
            TelaCadastrarCliente telaCadastrarCliente = new TelaCadastrarCliente();

            // Exibir o segundo formulário
            telaCadastrarCliente.Show();

            telaCadastrarCliente.ClienteCadastradoSucesso += TelaCadastrarCliente_ClienteCadastradoSucesso;
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            this.Close();
            TelaClientes tela = new TelaClientes();
            tela.ShowDialog();
        }

        private void PictureBoxEditar_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxDeletar_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
