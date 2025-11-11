namespace WebEmMVC.Context
{
    public class AppConfig
    {
        public static string GetConnectionString()
        {
            return "Server = (localdb)\\MSSQLLocalDB; Database = ProjetoMvc; Trusted_Connection = True;";
        }
    }
}
