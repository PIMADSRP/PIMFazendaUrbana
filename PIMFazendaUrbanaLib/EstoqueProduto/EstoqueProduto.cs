namespace PIMFazendaUrbanaLib
{
    internal class EstoqueProduto
    {
        // Atributos/Propriedades
        public int ID { get; set; }
        public int Quantidade { get; set; }
        public string DataEntrada { get; set; }
        public string DataSaida { get; set; }
        public bool StatusAtivo { get; set; }
    }
}
