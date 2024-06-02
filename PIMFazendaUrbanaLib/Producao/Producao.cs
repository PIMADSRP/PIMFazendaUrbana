namespace PIMFazendaUrbanaLib
{
    public class Producao
    {
        // Atributos/Propriedades
        public int Id { get; set; }
        public int IdCultivo { get; set; }
        public string Nome { get; set; }
        public string Variedade { get; set; }
        public string Categoria { get; set; }
        public int TempoProdTradicional { get; set; }
        public int TempoProdControlado { get; set; }
        public int Qtd { get; set; }
        public string Unidqtd { get; set; }
        public string Data { get; set; }
        public string DataColheita { get; set; }
        public bool AmbienteControlado { get; set; }
        public bool StatusFinalizado { get; set; }

        // Métodos
        public string CalcularDataColheita(Producao producao)
        {
            string dataColheita = "";

            DateTime data = DateTime.Now;
            int tempoProd;
            if (producao.AmbienteControlado)
            {
                tempoProd = producao.TempoProdControlado;
            }
            else
            {
                tempoProd = producao.TempoProdTradicional;
            }

            dataColheita = data.AddDays(tempoProd).ToShortDateString();

            return dataColheita;
        }

        public string CalcularDataHoraColheita(Producao producao)
        {
            string dataHoraColheita = "";

            DateTime data = DateTime.Now;
            int tempoProd;
            if (producao.AmbienteControlado)
            {
                tempoProd = producao.TempoProdControlado;
            }
            else
            {
                tempoProd = producao.TempoProdTradicional;
            }

            dataHoraColheita = data.AddDays(tempoProd).ToString("yyyy-MM-dd HH:mm:ss");

            return dataHoraColheita;
        }

    }
}
