using WebEmMVC.Context;
using WebEmMVC.Models;
using WebEmMVC.Utils;

namespace WebEmMVC.Repositories
{
    public class ChamadoRepository
    {
        private StringUtils stringUtils = new StringUtils();
        public string totalFormularios = TotalFormularios();
        public void EncaminharSolicitacao(FormularioCliente modelo)
        {
            int categoriaId = modelo.Categoria == "Reclamação" ? 1 : 2;
            using (var context = new AppDbContext())
            {

                //context.Database.EnsureDeleted();
                Console.WriteLine("Criando o banco de dados...\n");
                //context.Database.EnsureCreated();

                var novoFormulario = new FormularioCliente
                {
                    Nome = stringUtils.Capitalizar(modelo.Nome),
                    Empresa = stringUtils.Capitalizar(modelo.Empresa),
                    Email = modelo.Email.ToLower(),
                    Telefone = modelo.Telefone,
                    Categoria = categoriaId.ToString(),
                    Descricao = modelo.Descricao,
                    DataCriacao = DateTime.Now,
                    NumeroProtocolo = totalFormularios
                };

                context.Formularios.Add(novoFormulario);
                context.SaveChanges();
            }
        }
        private static string TotalFormularios()
        {
            string novoProtocolo = "";
            using (var context = new AppDbContext())
            {
                var numeros = context.Formularios
                    .Where(f => f.NumeroProtocolo.StartsWith("REQ"))
                    .AsEnumerable() // força execução em memória
                    .Select(f =>
                    {
                        string numero = f.NumeroProtocolo.Replace("REQ", "");
                        return int.TryParse(numero, out int n) ? n : 0;
                    })
                    .DefaultIfEmpty(0)
                    .ToList();

                int ultimoNumero = numeros.Max() + 1;

                novoProtocolo = "REQ" + ultimoNumero;

                while (context.Formularios.Any(f => f.NumeroProtocolo == novoProtocolo))
                {
                    ultimoNumero++;
                    novoProtocolo = "REQ" + ultimoNumero;
                }
            }

            return novoProtocolo;
        }
    }
}
