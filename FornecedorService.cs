using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;

namespace PIM_FazendaUrbana
{
    // atualizado 26/04
    public class FornecedorService // A classe FornecedorService é responsável por implementar a lógica de negócio relacionada a fornecedores
    {
        private FornecedorDAO fornecedorDAO; // Campo privado para armazenar uma instância de FornecedorDAO

        public FornecedorService(FornecedorDAO fornecedorDAO) // O construtor da classe FornecedorService recebe um FornecedorDAO como parâmetro, permitindo a injeção de dependência.
        {
            this.fornecedorDAO = fornecedorDAO; // Atribui a instância de FornecedorDAO recebida ao campo fornecedorDAO
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //
        // **********************
        // 
        // O CHAT FALOU PARA USAR BOOL EM VEZ DE VOID, PARA RETORNAR SUCESSO OU FALHA
        // E DAÍ EXIBIR A MENSAGEM DE SUCESSO OU FALHA NO MÉTODO QUE CHAMOU O MÉTODO DO SERVICE
        // NO CASO A TELA DA INTERFACE DO FORMS
        // 
        // **********************
        // 
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // 1 - FORNECEDOR

        // 1.1 - Cadastrar Fornecedor
        // ********** MÉTODO CADASTRAR FORNECEDOR (REGRAS DE NEGÓCIO E CHAMAR DAO) **********
        // O método CadastrarFornecedor é responsável por cadastrar um novo fornecedor. Antes de chamar o DAO para inserir um fornecedor no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                // Aqui podem ser feitas validações dos dados antes de chamar o DAO
                // Exemplo: verificar se o e-mail é válido, se o CNPJ é válido, etc
                // Se alguma validação falhar, você pode lançar uma exceção para interromper o cadastro e exibir uma mensagem de erro

                // EXEMPLOS DE VALIDAÇÃO:
                // Exemplo de validação do nome
                if (string.IsNullOrEmpty(fornecedor.Nome))
                {
                    throw new Exception("O nome do fornecedor é obrigatório."); // Lança uma exceção caso o nome do fornecedor seja nulo ou vazio
                }
                // Exemplo de validação do e-mail
                if (string.IsNullOrEmpty(fornecedor.Email) || !fornecedor.Email.Contains("@"))
                {
                    throw new Exception("O e-mail do fornecedor é inválido."); // Lança uma exceção caso o e-mail seja nulo, vazio ou não contenha o caractere '@'
                }
                // Exemplo de validação do CNPJ
                if (string.IsNullOrEmpty(fornecedor.CNPJ) || fornecedor.CNPJ.Length != 14)
                {
                    throw new Exception("O CNPJ do fornecedor é inválido."); // Lança uma exceção caso o CNPJ seja nulo, vazio ou não tenha 14 caracteres
                }
                // Exemplo de validação do endereço
                if (fornecedor.Endereco == null || string.IsNullOrEmpty(fornecedor.Endereco.Logradouro))
                {
                    throw new Exception("O endereço do fornecedor é obrigatório."); // Lança uma exceção caso o endereço seja nulo ou o logradouro seja nulo ou vazio
                }
                // Exemplo de validação do telefone
                if (fornecedor.Telefone == null || string.IsNullOrEmpty(fornecedor.Telefone.DDD) || string.IsNullOrEmpty(fornecedor.Telefone.Numero))
                {
                    throw new Exception("O telefone do fornecedor é obrigatório."); // Lança uma exceção caso o telefone seja nulo ou o DDD e/ou número sejam nulos ou vazios
                }



                // Se todas as validações forem bem-sucedidas, o cadastro do fornecedor pode ser realizado e então o DAO é chamado para inserir o fornecedor no banco de dados
                fornecedorDAO.CadastrarFornecedor_DAO(fornecedor); // Chama o método CadastrarFornecedor do DAO para inserir o novo fornecedor no banco de dados, passando o objeto fornecedor como argumento

                Console.WriteLine("Fornecedor cadastrado com sucesso!"); // Se o cadastro for bem-sucedido, exibe uma mensagem de sucesso

                return true; // Retorna true para indicar que o cadastro foi bem-sucedido
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe uma mensagem de erro ou registra o erro em um log
                Console.WriteLine($"Erro ao cadastrar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante o cadastro
                // Você também pode lançar a exceção novamente se desejar propagá-la para camadas superiores
                // throw;

                return false; // Retorna false para indicar que o cadastro falhou
            }
        }


        // 1.2 - Alterar Fornecedor
        // ********** MÉTODO ALTERAR FORNECEDOR (REGRAS DE NEGÓCIO E CHAMAR DAO) **********
        // O método AlterarFornecedor é responsável por alterar os dados de um fornecedor existente. Antes de chamar o DAO para atualizar os dados no banco de dados, este método pode realizar validações dos dados, se necessário.
        public bool AlterarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                fornecedorDAO.AlterarFornecedor_DAO(fornecedor); // Chama o método AlterarFornecedor da classe FornecedorDAO, passando o objeto fornecedor como argumento
                Console.WriteLine("Fornecedor alterado com sucesso."); // Exibe uma mensagem de sucesso após a alteração

                return true; // Retorna true para indicar que a alteração foi bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao alterar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a alteração

                return false; // Retorna false para indicar que a alteração falhou
            }
        }


        // 1.3 - Excluir Fornecedor
        // ********** MÉTODO EXCLUIR FORNECEDOR (REGRAS DE NEGÓCIO E CHAMAR DAO) **********
        // O método ExcluirFornecedor é responsável por excluir (DESATIVAR) um fornecedor do banco de dados. Antes de chamar o DAO para realizar a exclusão, este método pode realizar validações ou outras operações necessárias.
        public bool ExcluirFornecedor(int fornecedorId)
        {
            try
            {
                fornecedorDAO.ExcluirFornecedor_DAO(fornecedorId); // Chama o método ExcluirFornecedor da classe FornecedorDAO, passando o ID do fornecedor como argumento
                Console.WriteLine("Fornecedor excluído com sucesso."); // Exibe uma mensagem de sucesso após a exclusão

                return true; // Retorna true para indicar que a exclusão foi bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a exclusão

                return false; // Retorna false para indicar que a exclusão falhou
            }
        }


        // 1.4 - Listar Fornecedores
        // ********** MÉTODO LISTAR FORNECEDORES (CHAMAR DAO) **********
        // O método ListarFornecedores é responsável por obter a lista de todos os fornecedores cadastrados no banco de dados e exibir esses dados na tela.
        public bool ListarFornecedores()
        {
            try
            {
                List<Fornecedor> fornecedores = fornecedorDAO.ListarFornecedores_DAO(); // Chama o método ListarFornecedores da classe FornecedorDAO para obter uma lista de fornecedores


                // Exibição em console
                Console.WriteLine("Lista de fornecedores:");
                foreach (var fornecedor in fornecedores)
                {
                    // Para cada fornecedor na lista, exibe seus dados básicos (ID, nome, cnpj, email e status), endereço e telefone
                    Console.WriteLine($"ID: {fornecedor.ID}, Nome: {fornecedor.Nome}, Email: {fornecedor.Email}, CNPJ: {fornecedor.CNPJ}, Status: {fornecedor.StatusAtivo}");
                    Console.WriteLine($"Endereço: {fornecedor.Endereco.Logradouro}, {fornecedor.Endereco.Numero}, {fornecedor.Endereco.Complemento}, {fornecedor.Endereco.Bairro}, {fornecedor.Endereco.Cidade}, {fornecedor.Endereco.UF}, {fornecedor.Endereco.CEP}");
                    Console.WriteLine($"Telefone: ({fornecedor.Telefone.DDD}) {fornecedor.Telefone.Numero}");
                }

                return true; // Retorna true para indicar que a listagem foi bem-sucedida
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar fornecedores: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a listagem

                return false; // Retorna false para indicar que a listagem falhou
            }
        }


        // 1.5.1 - Consultar Fornecedor por ID
        // ********** MÉTODO CONSULTAR FORNECEDOR POR ID (CHAMAR DAO) **********
        // O método ConsultarFornecedorID é responsável por consultar um fornecedor pelo ID e exibir seus dados na tela.
        public string ConsultarFornecedorID(int fornecedorId)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorID_DAO(fornecedorId); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo ID
                if (fornecedor != null)
                {
                    // Exibição em console
                    // Se o fornecedor for encontrado, exibe seus dados básicos (ID, nome, cnpj, email e status), endereço e telefone
                    Console.WriteLine($"ID: {fornecedor.ID}, Nome: {fornecedor.Nome}, Email: {fornecedor.Email}, CNPJ: {fornecedor.CNPJ}, Status: {fornecedor.StatusAtivo}");
                    Console.WriteLine($"Endereço: {fornecedor.Endereco.Logradouro}, {fornecedor.Endereco.Numero}, {fornecedor.Endereco.Complemento}, {fornecedor.Endereco.Bairro}, {fornecedor.Endereco.Cidade}, {fornecedor.Endereco.UF}, {fornecedor.Endereco.CEP}");
                    Console.WriteLine($"Telefone: ({fornecedor.Telefone.DDD}) {fornecedor.Telefone.Numero}");

                    return "encontrado"; // Retorna uma string para indicar que o fornecedor foi encontrado
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado."); // Exibe uma mensagem caso o fornecedor não seja encontrado

                    return "naoencontrado"; // Retorna uma string para indicar que o fornecedor não foi encontrado
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a consulta

                return "erro"; // Retorna uma string para indicar que ocorreu um erro na consulta
            }
        }

        // 1.5.2 - Consultar Fornecedor por nome
        // ********** MÉTODO CONSULTAR FORNECEDOR POR NOME (CHAMAR DAO) **********
        // O método ConsultarFornecedorNome é responsável por consultar um fornecedor pelo nome e exibir seus dados na tela.
        public string ConsultarFornecedorNome(string fornecedorNome)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorNome_DAO(fornecedorNome); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo nome
                if (fornecedor != null)
                {
                    // Exibição em console
                    // Se o fornecedor for encontrado, exibe seus dados básicos (ID, nome, cnpj, email e status), endereço e telefone
                    Console.WriteLine($"ID: {fornecedor.ID}, Nome: {fornecedor.Nome}, Email: {fornecedor.Email}, CNPJ: {fornecedor.CNPJ}, Status: {fornecedor.StatusAtivo}");
                    Console.WriteLine($"Endereço: {fornecedor.Endereco.Logradouro}, {fornecedor.Endereco.Numero}, {fornecedor.Endereco.Complemento}, {fornecedor.Endereco.Bairro}, {fornecedor.Endereco.Cidade}, {fornecedor.Endereco.UF}, {fornecedor.Endereco.CEP}");
                    Console.WriteLine($"Telefone: ({fornecedor.Telefone.DDD}) {fornecedor.Telefone.Numero}");

                    return "encontrado"; // Retorna uma string para indicar que o fornecedor foi encontrado
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado."); // Exibe uma mensagem caso o fornecedor não seja encontrado

                    return "naoencontrado"; // Retorna uma string para indicar que o fornecedor não foi encontrado
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a consulta

                return "erro"; // Retorna uma string para indicar que ocorreu um erro na consulta
            }
        }

        // 1.5.3 - Consultar Fornecedor por CNPJ
        // ********** MÉTODO CONSULTAR FORNECEDOR POR CNPJ (CHAMAR DAO) **********
        // O método ConsultarFornecedorCNPJ é responsável por consultar um fornecedor pelo cnpj e exibir seus dados na tela.
        public string ConsultarFornecedorCNPJ(string fornecedorCNPJ)
        {
            try
            {
                Fornecedor fornecedor = fornecedorDAO.ConsultarFornecedorCNPJ_DAO(fornecedorCNPJ); // Chama o método ConsultarFornecedor da classe FornecedorDAO para obter os dados de um fornecedor pelo cnpj
                if (fornecedor != null)
                {
                    // Exibição em console
                    // Se o fornecedor for encontrado, exibe seus dados básicos (ID, nome, cnpj, email e status), endereço e telefone
                    Console.WriteLine($"ID: {fornecedor.ID}, Nome: {fornecedor.Nome}, Email: {fornecedor.Email}, CNPJ: {fornecedor.CNPJ}, Status: {fornecedor.StatusAtivo}");
                    Console.WriteLine($"Endereço: {fornecedor.Endereco.Logradouro}, {fornecedor.Endereco.Numero}, {fornecedor.Endereco.Complemento}, {fornecedor.Endereco.Bairro}, {fornecedor.Endereco.Cidade}, {fornecedor.Endereco.UF}, {fornecedor.Endereco.CEP}");
                    Console.WriteLine($"Telefone: ({fornecedor.Telefone.DDD}) {fornecedor.Telefone.Numero}");

                    return "encontrado"; // Retorna uma string para indicar que o fornecedor foi encontrado
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado."); // Exibe uma mensagem caso o fornecedor não seja encontrado

                    return "naoencontrado"; // Retorna uma string para indicar que o fornecedor não foi encontrado
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar fornecedor: {ex.Message}"); // Exibe uma mensagem de erro caso ocorra uma exceção durante a consulta

                return "erro"; // Retorna uma string para indicar que ocorreu um erro na consulta
            }
        }

    }
}
