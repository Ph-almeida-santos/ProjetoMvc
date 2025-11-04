using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEmMVC.Context;
using WebEmMVC.Models;

namespace WebEmMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Enviar()
        {
            return View(new FormularioCliente());
        }


        [HttpPost]
        public IActionResult EnviarMensagem(FormularioCliente modelo)
        {
            int idGerado;
            int categoriaId = modelo.Categoria == "Reclamação" ? 1 : 2;

            if (!ModelState.IsValid)
            {
                TempData["MensagemErro"] = "Por favor, preencha todos os campos obrigatórios.";
                return View("Index", modelo);
            }

            try
            {
                using (var context = new AppDbContext())
                {

                    var novoFormulario = new FormularioCliente
                    {
                        Nome = Capitalizar(modelo.Nome),
                        Empresa = Capitalizar(modelo.Empresa),
                        Email = modelo.Email.ToLower(),
                        Telefone = modelo.Telefone,
                        Categoria = categoriaId.ToString(),

                        Descricao = modelo.Descricao,
                        DataCriacao = DateTime.Now
                    };

                    context.Formularios.Add(novoFormulario);
                    context.SaveChanges();
                }

                //idGerado = Convert.ToInt32(cmd.ExecuteScalar());

                /*using (var cmdUpdate = conn.CreateCommand())
                {
                    cmdUpdate.CommandText = "UPDATE Sugestao SET NumeroProtocolo = @protocolo WHERE Id = @id";
                    cmdUpdate.Parameters.AddWithValue("@protocolo", $"REQ{idGerado}");
                    cmdUpdate.Parameters.AddWithValue("@id", idGerado);
                    cmdUpdate.ExecuteNonQuery();
                }*/

                TempData["MensagemSucesso"] = $"Sua contribuição é essencial para a nossa melhoria! Agradecemos por nos ajudar a evoluir.";
                //TempData["NumeroProtocolo"] = $"REQ{idGerado}";
                return RedirectToAction("Enviar");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Erro ao enviar: " + ex.Message;
                return RedirectToAction("Enviar");
            }
        }

        private string Capitalizar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
