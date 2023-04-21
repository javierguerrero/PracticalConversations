using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapperService _mapperService;
        private readonly IGetAllCategoriesService _getAllCategoriesService;
        private readonly IGetQuestionsService _getQuestionsService;
        private readonly IGetQuestionService _getQuestionService;
        private readonly IGenerateConversationService _generateConversationService;

        public HomeController(
            ILogger<HomeController> logger,
            IMapperService mapperService,
            IGetAllCategoriesService getAllCategoriesService,
            IGetQuestionsService getQuestionsService,
            IGetQuestionService getQuestionService,
            IGenerateConversationService generateConversationService
            )
        {
            _logger = logger;
            _mapperService = mapperService;
            _getAllCategoriesService = getAllCategoriesService;
            _getQuestionsService = getQuestionsService;
            _getQuestionService = getQuestionService;
            _generateConversationService = generateConversationService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.CategoryList = await GetCategories();

            return View(viewModel);
        }

        private async Task<List<SelectListItem>> GetCategories()
        {
            var results = new List<SelectListItem>();

            var categoriesData = await _getAllCategoriesService.GetAllCategories();
            foreach (var category in categoriesData)
            {
                results.Add(new SelectListItem
                {
                    Text = category.Name,
                    Value = Convert.ToString(category.Id)
                });
            }

            return results;
        }

        private async Task<List<SelectListItem>> GetQuestions(int categoryId = 1)
        {
            var results = new List<SelectListItem>();

            var questionsData = await _getQuestionsService.GetQuestions(categoryId);
            foreach (var question in questionsData)
            {
                results.Add(new SelectListItem
                {
                    Text = question.Text,
                    Value = Convert.ToString(question.Id)
                });
            }

            return results;
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionsByCategory(int categoryId)
        {
            var questions = await GetQuestions(categoryId);
            return Json(questions);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel model)
        {
            var selectedQuestion = model.SelectedQuestion;
            //TODO: GetCategory

            var question = _getQuestionService.GetQuestion(Convert.ToInt32(selectedQuestion));
            var prompt = $"Generar una conversación en inglés entre dos personas que hablen sobre {question.Text}";
            var conversation = await _generateConversationService.GenerateConversation(prompt);

            var viewModel = new ConversationViewModel()
            {
                Category = "",
                Question = question.Text,
                Content = conversation.Content
            };

            return View("Conversation", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}