using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PIMFazendaUrbanaLib
{
    internal class ClienteValidation_
    {
        internal void ValidarCliente(Cliente cliente)
        {
            ValidarNome(cliente.Nome);
            ValidarCNPJ(cliente.CNPJ);
            ValidarEmail(cliente.Email);

            ValidarDDD(cliente.Telefone.DDD);
            ValidarTelefone(cliente.Telefone.Numero);

            ValidarLogradouro(cliente.Endereco.Logradouro);
            ValidarNumero(cliente.Endereco.Numero);
            ValidarBairro(cliente.Endereco.Bairro);
            ValidarCidade(cliente.Endereco.Cidade);
            ValidarUF(cliente.Endereco.UF);
            ValidarCEP(cliente.Endereco.CEP);
        }

        internal bool ValidarNome(string nome)
        {
            if (nome.Length < 3)
            {
                throw new ValidationException("Nome inválido. O nome do cliente deve conter pelo menos 3 caracteres.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarCNPJ(string cnpj)
        {
            string cnpjDigitsOnly = cnpj.Replace(".", "").Replace("/", "").Replace("-", ""); // remove todos os caracteres não numéricos do texto

            if (cnpjDigitsOnly.Length != 14 || !cnpjDigitsOnly.All(char.IsDigit)) // verifica se o CNPJ tem exatamente 14 dígitos
            {
                throw new ValidationException("CNPJ inválido. O CNPJ deve conter exatamente 14 dígitos.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarEmail(string email)
        {
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) // verifica se o email é texto@texto2.texto3
            {
                throw new ValidationException("Email inválido. O email deve ter o formato texto@texto.texto.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarDDD(string ddd)
        {
            if (!Regex.IsMatch(ddd, @"^\d{2}$")) // verifica se o DDD tem exatamente 2 dígitos
            {
                throw new ValidationException("DDD inválido. O DDD deve conter exatamente 2 dígitos.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarTelefone(string telefone)
        {
            if (!Regex.IsMatch(telefone, @"^\d{8,9}$")) // verifica se o telefone tem 8 ou 9 dígitos
            {
                throw new ValidationException("Telefone inválido. O telefone deve conter 8 ou 9 dígitos.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarLogradouro(string logradouro)
        {
            if (logradouro.Length < 3) // verifica se o logradouro tem ao menos 3 caracteres
            {
                throw new ValidationException("Logradouro inválido. O logradouro deve conter pelo menos 3 caracteres.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarNumero(string numero)
        {
            if (!Regex.IsMatch(numero, @"^\d+$")) // verifica se o número contém apenas caracteres numéricos
            {
                throw new ValidationException("Número inválido. O número deve conter apenas dígitos.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarBairro(string bairro)
        {
            if (bairro.Length < 3) // verifica se o bairro tem ao menos 3 caracteres
            {
                throw new ValidationException("Bairro inválido. O bairro deve conter pelo menos 3 caracteres.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarCidade(string cidade)
        {
            if (cidade.Length < 3) // verifica se a cidade tem ao menos 3 caracteres
            {
                throw new ValidationException("Cidade inválida. A cidade deve conter pelo menos 3 caracteres.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarUF(string uf)
        {
            if (!Regex.IsMatch(uf, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$")) // verifica se a UF é uma das siglas válidas
            {
                throw new ValidationException("UF inválida. A UF deve ser uma das siglas válidas.");
            }
            else
            {
                return true;
            }
        }

        internal bool ValidarCEP(string cep)
        {
            string cepDigitsOnly = cep.Replace("-", ""); // remove os caracteres não numéricos do texto
            if (cepDigitsOnly.Length != 8 || !cepDigitsOnly.All(char.IsDigit)) // verifica se o CEP tem exatamente 8 dígitos e se são todos numéricos
            {
                throw new ValidationException("CEP inválido. O CEP deve conter exatamente 8 dígitos.");
            }
            else
            {
                return true;
            }
        }
    }
}
