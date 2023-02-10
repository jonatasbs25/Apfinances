using Apfinances.Models;
using Apfinances.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Apfinances.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public HomeController(ILogger<HomeController> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        //GET: 
        public async Task<IActionResult> Index()
        {
            return View(await _transactionRepository.FindTransactionsAsync());
        }

        public IActionResult CreateTransaction()
        {
            return View();
        }

        [HttpPost, ActionName("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction(
            [Bind("Id,Description,Company,Amount,Installments,ValueOfInstallments,StarDate,EndDate")]
            Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _transactionRepository.CreateTransactionAsync(transaction);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(transaction);
        }

        public async Task<IActionResult> EditTransaction(int id)
        {
            return View(await _transactionRepository.FindTransactionByIdAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTransaction(int id,
            [Bind("Id, Description, Company, Amount, Installments, ValueOfInstallments, StarDate, EndDate")]
            Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _transactionRepository.UpdateTransactionAsync(transaction);
                }
                catch (Exception ex)
                {

                }
            }

            return View(transaction);
        }

        public IActionResult DeleteTransaction()
        {
            return View();
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