namespace WebEmMVC.Utils
{
    public class StringUtils
    {
        public string Capitalizar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }
    }
}
