﻿using PIMFazendaUrbana;

namespace PIMFazendaUrbana
{
    public partial class TelaFuncionarios : Form
    {
        FuncionarioDAO funcionarioDAO; // Declaração de uma instância de FuncionarioDAO
        FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService
        public TelaFuncionarios()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados

            funcionarioDAO = new FuncionarioDAO(connectionString); // Cria uma instância de FuncionarioDAO passando a string de conexão como parâmetro
            funcionarioService = new FuncionarioService(funcionarioDAO); // Cria uma instância de funcionarioService passando o funcionarioDAO como parâmetro

            // Define AutoGenerateColumns como false para evitar a geração automática de colunas
            DataGridViewListaFuncionarios.AutoGenerateColumns = false;

            // Adicione manualmente as colunas necessárias
            DataGridViewListaFuncionarios.Columns.Add("IDColumn", "ID");
            DataGridViewListaFuncionarios.Columns.Add("NomeColumn", "Nome");
            DataGridViewListaFuncionarios.Columns.Add("SexoColumn", "Sexo");
            DataGridViewListaFuncionarios.Columns.Add("EmailColumn", "Email");
            DataGridViewListaFuncionarios.Columns.Add("CargoColumn", "Cargo");
            DataGridViewListaFuncionarios.Columns.Add("UsuarioColumn", "Usuário"); // talvez não listar o nome de usuário dos funcionários?

            DataGridViewListaFuncionarios.Columns.Add("TelefoneColumn", "Telefone");
            DataGridViewListaFuncionarios.Columns.Add("EnderecoColumn", "Endereço");
            DataGridViewListaFuncionarios.Columns.Add("CEPColumn", "CEP");

            // Configurar as propriedades DataPropertyName das colunas
            DataGridViewListaFuncionarios.Columns["IDColumn"].DataPropertyName = "ID";
            DataGridViewListaFuncionarios.Columns["NomeColumn"].DataPropertyName = "Nome";
            DataGridViewListaFuncionarios.Columns["SexoColumn"].DataPropertyName = "Sexo";
            DataGridViewListaFuncionarios.Columns["EmailColumn"].DataPropertyName = "Email";
            DataGridViewListaFuncionarios.Columns["CargoColumn"].DataPropertyName = "Cargo";
            DataGridViewListaFuncionarios.Columns["UsuarioColumn"].DataPropertyName = "Usuario"; // talvez não listar o nome de usuário dos funcionários?

            DataGridViewListaFuncionarios.Columns["TelefoneColumn"].DataPropertyName = "Telefone";
            DataGridViewListaFuncionarios.Columns["EnderecoColumn"].DataPropertyName = "Endereco";
            DataGridViewListaFuncionarios.Columns["CEPColumn"].DataPropertyName = "CEP";

            // Configurar o modo de redimensionamento das colunas
            foreach (DataGridViewColumn column in DataGridViewListaFuncionarios.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }
        private void TelaFuncionarios_Load(object sender, EventArgs e)
        {
            ListarFuncionariosAtivosDataGrid();
        }

        // Manipulador de eventos para o evento FuncionarioCadastradoSucesso
        private void TelaCadastrarFuncionario_FuncionarioCadastradoSucesso(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        // Manipulador de eventos para o evento FuncionarioEditadoSucesso
        private void TelaEditarFuncionario_FuncionarioEditadoSucesso(object sender, EventArgs e)
        {
            AtualizarDataGridView();
        }

        // Método para atualizar o DataGridView
        private void AtualizarDataGridView()
        {
            ListarFuncionariosAtivosDataGrid();
        }

        private void ListarFuncionariosAtivosDataGrid()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioService.ListarFuncionariosAtivos();

                // Verificar se a lista de funcionários não está vazia
                if (funcionarios != null && funcionarios.Count > 0)
                {
                    // Criar uma lista temporária de objetos anônimos para armazenar os dados formatados
                    var data = funcionarios.Select(f => new
                    {
                        f.ID,
                        f.Nome,
                        f.Sexo,
                        f.Email,
                        f.Cargo,
                        f.Usuario, // talvez não listar o nome de usuário dos funcionários?

                        Telefone = FormatarTelefone(f.Telefone), // Formatar o telefone
                        Endereco = FormatarEndereco(f.Endereco), // Formatar o endereço
                        CEP = FormatarCEP(f.Endereco) // Formatar o CEP
                    }).ToList();

                    // Preencher o DataGridView com os dados formatados
                    DataGridViewListaFuncionarios.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Nenhum funcionário encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para formatar o telefone
        private string FormatarTelefone(TelefoneFuncionario telefone)
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
        private string FormatarEndereco(EnderecoFuncionario endereco)
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
        private object FormatarCEP(EnderecoFuncionario endereco)
        {
            string cepFormatado = endereco.CEP;

            // Insere o hífen no CEP
            if (cepFormatado.Length == 8)
            {
                cepFormatado = $"{cepFormatado.Substring(0, 5)}-{cepFormatado.Substring(5)}";
            }

            return cepFormatado;
        }

        private void PictureBoxIncluir_Click(object sender, EventArgs e)
        {
            // Criar uma instância do segundo formulário
            TelaCadastrarFuncionario telaCadastrarFuncionario = new TelaCadastrarFuncionario();

            // Exibir o segundo formulário
            telaCadastrarFuncionario.Show();

            telaCadastrarFuncionario.FuncionarioCadastradoSucesso += TelaCadastrarFuncionario_FuncionarioCadastradoSucesso;
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarDataGridView();
            MessageBox.Show("Lista de usuários atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PictureBoxDeletar_Click(object sender, EventArgs e)
        {
            // Verificar se alguma linha está selecionada no DataGridView
            if (DataGridViewListaFuncionarios.SelectedRows.Count > 0)
            {
                // Obter o índice da linha selecionada
                int selectedIndex = DataGridViewListaFuncionarios.SelectedRows[0].Index;

                // Obter o ID do funcionário selecionado
                int funcionarioID = (int)DataGridViewListaFuncionarios.Rows[selectedIndex].Cells["IDColumn"].Value;

                // Confirmar a exclusão com o usuário
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este usuário?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Excluir o funcionário usando o serviço de funcionário
                        funcionarioService.ExcluirFuncionario(funcionarioID);

                        // Atualizar o DataGridView após a exclusão
                        ListarFuncionariosAtivosDataGrid();

                        MessageBox.Show("Usuário excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para excluir (botão '>' à esquerda do ID do usuário).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PictureBoxHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBoxEditar_Click(object sender, EventArgs e)
        {
            // Verificar se alguma linha está selecionada no DataGridView
            if (DataGridViewListaFuncionarios.SelectedRows.Count == 1)
            {
                // Obter o índice da linha selecionada
                int selectedIndex = DataGridViewListaFuncionarios.SelectedRows[0].Index;

                // Obter o ID do funcionário selecionado
                int funcionarioID = (int)DataGridViewListaFuncionarios.Rows[selectedIndex].Cells["IDColumn"].Value;

                // Criar uma instância do segundo formulário
                TelaEditarFuncionario telaEditarFuncionario = new TelaEditarFuncionario(funcionarioID);

                // Exibir o segundo formulário
                telaEditarFuncionario.Show();

                telaEditarFuncionario.FuncionarioEditadoSucesso += TelaEditarFuncionario_FuncionarioEditadoSucesso;
            }
            else if (DataGridViewListaFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um usuário para editar (botão '>' à esquerda do ID do usuário).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Por favor, selecione apenas um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
