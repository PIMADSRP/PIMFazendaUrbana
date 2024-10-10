using System.Text.RegularExpressions;

namespace PIMFazendaUrbanaLib
{
    internal class ClienteValidation
    {
        internal void ValidarCliente(Cliente cliente)
        {
            var erros = new List<ValidationError>();

            if (string.IsNullOrEmpty(cliente.Nome) || cliente.Nome.Length < 3)
            {
                erros.Add(new ValidationError("Nome", "O nome deve ter pelo menos 3 caracteres"));
            }
            if (!Regex.IsMatch(cliente.CNPJ, @"^\d{14}$") || !cliente.CNPJ.All(char.IsDigit))
            {
                erros.Add(new ValidationError("CNPJ", "O CNPJ deve conter 14 dígitos"));
            }
            if (!Regex.IsMatch(cliente.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                erros.Add(new ValidationError("Email", "Email inválido. O email deve ter o formato exemplo@exemplo.exeplo"));
            }
            if (string.IsNullOrEmpty(cliente.Telefone.DDD) || cliente.Telefone.DDD.Length != 2 || !cliente.Telefone.DDD.All(char.IsDigit))
            {
                erros.Add(new ValidationError("DDD", "O DDD deve conter 2 dígitos"));
            }
            if (string.IsNullOrEmpty(cliente.Telefone.Numero) || cliente.Telefone.Numero.Length < 8 || cliente.Telefone.Numero.Length > 9 || !cliente.Telefone.Numero.All(char.IsDigit))
            {
                erros.Add(new ValidationError("Telefone", "O telefone deve conter 8 ou 9 dígitos"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.Logradouro) || cliente.Endereco.Logradouro.Length < 3)
            {
                erros.Add(new ValidationError("Logradouro", "O logradouro deve conter pelo menos 3 caracteres"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.Numero) || !Regex.IsMatch(cliente.Endereco.Numero, @"^\d+$"))
            {
                erros.Add(new ValidationError("Número", "O número deve conter apenas dígitos"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.Bairro) || cliente.Endereco.Bairro.Length < 3)
            {
                erros.Add(new ValidationError("Bairro", "O bairro deve conter pelo menos 3 caracteres"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.Cidade) || cliente.Endereco.Cidade.Length < 3)
            {
                erros.Add(new ValidationError("Cidade", "A cidade deve conter pelo menos 3 caracteres"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.UF) || !Regex.IsMatch(cliente.Endereco.UF, @"^(AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RO|RR|SC|SP|SE|TO)$"))
            {
                erros.Add(new ValidationError("UF", "A UF deve ser uma das siglas válidas"));
            }
            if (string.IsNullOrEmpty(cliente.Endereco.CEP) || !Regex.IsMatch(cliente.Endereco.CEP, @"^\d{8}$"))
            {
                erros.Add(new ValidationError("CEP", "O CEP deve conter 8 dígitos"));
            }

            if (erros.Any())
            {
                throw new ValidationException(erros);
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
