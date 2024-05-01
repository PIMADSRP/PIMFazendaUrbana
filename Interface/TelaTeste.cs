﻿namespace PIMFazendaUrbana
{
    public partial class TelaTeste : Form
    {
        Funcionario funcionario = new Funcionario();
        FuncionarioService funcionarioService; // Declaração de uma instância de FuncionarioService
        FuncionarioDAO funcionarioDAO; // Declaração de uma instância de FuncionarioDAO

        public TelaTeste()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=testepim;Uid=root;Pwd=marcelogomesrp;"; // Substitua pelos valores reais da conexão com o banco de dados

            funcionarioDAO = new FuncionarioDAO(connectionString); // Cria uma instância de FuncionarioDAO passando a string de conexão como parâmetro
            funcionarioService = new FuncionarioService(funcionarioDAO); // Cria uma instância de FuncionarioService passando o funcionarioDAO como parâmetro
        }

        // Autenticar login de funcionário
        // ********** FUNCIONAL **********
        private void BotaoAutenticarFuncionario_Click(object sender, EventArgs e)
        {
            string usuario = CampoUsuario.Text; // Obtendo o valor do campo de texto do usuário
            string senha = CampoSenha.Text; // Obtendo o valor do campo de texto da senha

            /*
            string usuario = "nomedeusuarioteste";
            string senha = "Novasenhateste1_";
            */

            bool autenticado = AutenticarFuncionario(usuario, senha); // Chamando o método dedicado AutenticarFuncionario daqui dessa classe TelaTeste
        }

        // Autenticar um funcionário como gerente
        // ********** FUNCIONAL **********
        private void BotaoAutenticarGerente_Click(object sender, EventArgs e)
        {
            string usuario = CampoUsuario.Text; // Obtendo o valor do campo de texto do usuário
            string senha = CampoSenha.Text; // Obtendo o valor do campo de texto da senha
            
            /*
            string usuario = "nomedeusuarioteste";
            string senha = "Novasenhateste1_";
            */

            bool autenticado = AutenticarFuncionario(usuario, senha); // Chamando o método dedicado AutenticarFuncionario daqui dessa classe TelaTeste
            if (autenticado == true)
            {
                string autenticargerente = funcionarioService.AutenticarGerente(usuario); // Chamando o método AutenticarGerente da instância funcionarioService
                if (autenticargerente == "gerente")
                {
                    MessageBox.Show("Acesso permitido, usuário autenticado como gerente.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Criar uma instância do segundo formulário
                    //TelaFuncionarios telaFuncionarios = new TelaFuncionarios();

                    // Exibir o segundo formulário
                    //telaFuncionarios.Show();
                }
                else if (autenticargerente == "naogerente")
                {
                    MessageBox.Show("Acesso negado, usuário não autenticado como gerente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (autenticargerente == "erro")
                {
                    MessageBox.Show("Erro ao autenticar usuário como gerente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        // Verificar se um nome de usuário já está em uso
        // ********** DANDO ERRO **********
        private void BotaoVerificarUsuarioDisponivel_Click(object sender, EventArgs e)
        {
            string usuario = CampoUsuario.Text; // Obtendo o valor do campo de texto do usuário

            /*
            string usuario = "nomedeusuarioteste";
            */

            string verificarUsuarioDisponivel = funcionarioService.VerificarUsuarioDisponivel(usuario); // Chamando o método VerificarUsuarioDisponivel da instância funcionarioService
            if (verificarUsuarioDisponivel == "disponivel")
            {
                MessageBox.Show("Nome de usuário disponível.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (verificarUsuarioDisponivel == "indisponivel")
            {
                MessageBox.Show("Nome de usuário indisponível.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verificarUsuarioDisponivel == "erro")
            {
                MessageBox.Show("Erro ao verificar disponibilidade do nome de usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Alterar senha de um funcionário
        // ********** FUNCIONAL **********
        private void BotaoAlterarSenhaFuncionario_Click(object sender, EventArgs e)
        {
            string usuario = CampoUsuario.Text; // Obtendo o valor do campo de texto do usuário
            string senha = CampoSenha.Text; // Obtendo o valor do campo de texto da senha

            /*
            string usuario = "nomedeusuarioteste";
            string senha = "Novasenhateste1_";
            */

            bool autenticado = AutenticarFuncionario(usuario, senha); // Chamando o método dedicado AutenticarFuncionario daqui dessa classe TelaTeste

            if (autenticado == false)
            {
                return;
            }
            else
            {
                string novasenha1 = CampoNovaSenha1.Text; // Obtendo o valor do campo de texto da nova senha
                string novasenha2 = CampoNovaSenha2.Text; // Obtendo o valor do campo de texto da nova senha

                /*
                string novasenha1 = "Novasenhateste2_";
                string novasenha2 = "Novasenhateste2_";
                */

                bool senhasiguais = false;

                //pode colocar a verificação de novas senhas iguais aqui ou na validação dos campos
                if (novasenha1 != novasenha2)
                {
                    MessageBox.Show("As senhas são diferentes, confira e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    senhasiguais = false;
                }
                else
                {
                    senhasiguais = true;
                }

                if (senhasiguais == false)
                {
                    return;
                }
                else
                {
                    // Verificar se a nova senha é forte o suficiente
                    bool senhaforte = VerificarSenhaForte(novasenha1);

                    if (senhaforte == false)
                    {
                        return;
                    }
                    else
                    {
                        bool alterarSenha = funcionarioService.AlterarSenhaFuncionario(usuario, novasenha1); // Chamando o método AlterarSenhaFuncionario da instância funcionarioService
                        if (alterarSenha == true)
                        {
                            MessageBox.Show("Senha alterada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }

        // Excluir (desativar) funcionário
        // ********** FUNCIONAL **********
        private void BotaoExcluirFuncionario_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CampoID.Text); // Obtendo o valor do campo de texto do ID

            /*
            int id = 1;
            */

                bool excluirFuncionario = funcionarioService.ExcluirFuncionario(id); // Chamando o método ExcluirFuncionario da instância funcionarioService
            if (excluirFuncionario == true)
            {
                MessageBox.Show("Funcionário excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao excluir funcionário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consultar funcionário por ID
        // ********** FUNCIONAL **********
        private void BotaoConsultarFuncionarioID_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CampoID.Text); // Obtendo o valor do campo de texto do ID

            /*
            int id = 1;
            */

            Funcionario funcionario = funcionarioService.ConsultarFuncionarioID(id); // Chamando o método ConsultarFuncionarioID da instância funcionarioService
            if (funcionario != null)
            {
                MessageBox.Show($"Funcionário encontrado: {funcionario.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        // Consultar funcionário por nome
        // ********** FUNCIONAL **********
        private void BotaoConsultarFuncionarioNome_Click(object sender, EventArgs e)
        {
            string nome = CampoNome.Text; // Obtendo o valor do campo de texto do nome

            /*
            string nome = "nomefuncionarioteste";
            */

            Funcionario funcionario = funcionarioService.ConsultarFuncionarioNome(nome); // Chamando o método ConsultarFuncionarioNome da instância funcionarioService
            if (funcionario != null)
            {
                MessageBox.Show($"Funcionário encontrado: {funcionario.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Consultar funcionário por nome de usuário
        // ********** FUNCIONAL **********
        private void BotaoConsultarFuncionarioUsuario_Click(object sender, EventArgs e)
        {
            string usuario = CampoUsuario.Text; // Obtendo o valor do campo de texto do usuário

            /*
            string usuario = "nomedeusuarioteste";
            */

            Funcionario funcionario = funcionarioService.ConsultarFuncionarioUsuario(usuario); // Chamando o método ConsultarFuncionarioUsuario da instância funcionarioService
            if (funcionario != null)
            {
                MessageBox.Show($"Funcionário encontrado: {funcionario.Nome}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método dedicado para autenticar login do funcionário
        // ********** FUNCIONAL **********
        private bool AutenticarFuncionario(string usuario, string senha)
        {
            string autenticarfuncionario = funcionarioService.AutenticarFuncionario(usuario, senha); // Chamando o método AutenticarFuncionario da instância funcionarioService
            if (autenticarfuncionario == "autenticado")
            {
                MessageBox.Show("Acesso permitido, usuário autenticado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (autenticarfuncionario == "naoautenticado")
            {
                MessageBox.Show("Acesso negado, usuário não autenticado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (autenticarfuncionario == "erro")
            {
                MessageBox.Show("Erro ao autenticar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return false;
            }
        }

        // Método dedicado para verificar se a senha é forte o suficiente
        // ********** FUNCIONAL **********
        public bool VerificarSenhaForte(string novaSenha)
        {
            // Verifica se a senha tem pelo menos 8 caracteres
            if (novaSenha.Length < 8)
            {
                MessageBox.Show("A senha deve conter no mínimo 8 caracteres.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica se a senha contém pelo menos um número
            bool contemNumero = false;
            foreach (char c in novaSenha)
            {
                if (char.IsDigit(c))
                {
                    contemNumero = true;
                    break;
                }
            }
            if (!contemNumero)
            {
                MessageBox.Show("A senha deve conter pelo menos um número.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica se a senha contém pelo menos uma letra maiúscula
            bool contemMaiuscula = false;
            foreach (char c in novaSenha)
            {
                if (char.IsUpper(c))
                {
                    contemMaiuscula = true;
                    break;
                }
            }
            if (!contemMaiuscula)
            {
                MessageBox.Show("A senha deve conter pelo menos uma letra maiúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica se a senha contém pelo menos uma letra minúscula
            bool contemMinuscula = false;
            foreach (char c in novaSenha)
            {
                if (char.IsLower(c))
                {
                    contemMinuscula = true;
                    break;
                }
            }
            if (!contemMinuscula)
            {
                MessageBox.Show("A senha deve conter pelo menos uma letra minúscula.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verifica se a senha contém pelo menos um caractere especial
            bool contemEspecial = false;
            foreach (char c in novaSenha)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    contemEspecial = true;
                    break;
                }
            }
            if (!contemEspecial)
            {
                MessageBox.Show("A senha deve conter pelo menos um caractere especial.", "Senha Fraca", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Se a senha passar por todas as verificações, é considerada forte
            return true;
            //MessageBox.Show("Senha forte.", "Senha Forte", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
