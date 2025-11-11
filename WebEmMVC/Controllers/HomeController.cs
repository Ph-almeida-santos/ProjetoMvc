using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEmMVC.Context;
using WebEmMVC.Models;
using WebEmMVC.Repositories;

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
            if (!ModelState.IsValid)
            {
                TempData["MensagemErro"] = "Por favor, preencha todos os campos obrigatórios.";
                return View("Index", modelo);
            }

            try
            {
                var criarChamado = new ChamadoRepository();
                criarChamado.EncaminharSolicitacao(modelo);

                TempData["MensagemSucesso"] = $"Sua contribuição é essencial para a nossa melhoria! Agradecemos por nos ajudar a evoluir.";
                TempData["NumeroProtocolo"] = criarChamado.totalFormularios;
                return RedirectToAction("Enviar");
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Erro ao enviar: " + ex.Message;
                return RedirectToAction("Enviar");
            }
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
