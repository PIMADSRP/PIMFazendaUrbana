using System;
using System.Collections.Generic;

namespace PIM_FazendaUrbana
{
    // atualizado 26/04
    public class Fornecedor
    {
        // Atributos/Propriedades
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public bool StatusAtivo { get; set; }
        public EnderecoFornecedor Endereco { get; set; }
        public TelefoneFornecedor Telefone { get; set; }


        // Construtores?
        /*
        public Fornecedor()
        {
            StatusAtivo = true;
        }
        */

        // Métodos
        // Nem sei se é necessário ter métodos aqui, já que a lógica de negócio está no service


    }
}
