namespace PIMFazendaUrbanaLib
{
    public class Utility
    {
        public string FormatarDataSemHora(string dataHoraOriginal)
        {
            // Especifica o formato da string original
            string formatoOriginal = "yyyy-MM-dd HH:mm:ss";

            // Converte a string para um objeto DateTime
            DateTime dataHora = DateTime.ParseExact(dataHoraOriginal, formatoOriginal, System.Globalization.CultureInfo.InvariantCulture);

            // Obtém a parte da data (sem a hora)
            string dataFormatada = dataHora.ToString("yyyy-MM-dd");

            return dataFormatada;
        }
    }
}
