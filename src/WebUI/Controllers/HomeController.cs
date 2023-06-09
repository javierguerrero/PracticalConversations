﻿using Application.Services;
using Domain.Interfaces.Services;
using Google.Cloud.TextToSpeech.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapperService _mapperService;
        private readonly IGetAllCategoriesService _getAllCategoriesService;
        private readonly IGetQuestionsService _getQuestionsService;
        private readonly IGetQuestionService _getQuestionService;
        private readonly IGetCategoryService _getCategoryService;
        private readonly IGenerateConversationService _generateConversationService;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger,
            IMapperService mapperService,
            IGetAllCategoriesService getAllCategoriesService,
            IGetQuestionsService getQuestionsService,
            IGetQuestionService getQuestionService,
            IGenerateConversationService generateConversationService,
            IGetCategoryService getCategoryService
            )
        {
            _configuration = configuration;
            _logger = logger;
            _mapperService = mapperService;
            _getAllCategoriesService = getAllCategoriesService;
            _getQuestionsService = getQuestionsService;
            _getQuestionService = getQuestionService;
            _generateConversationService = generateConversationService;
            _getCategoryService = getCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.CategoryList = await GetCategories();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel model)
        {
            if (Convert.ToInt32(model.SelectedCategory) == -1)
                return RedirectToAction("Index");

            var category = _getCategoryService.GetCategory(Convert.ToInt32(model.SelectedCategory));
            var question = _getQuestionService.GetQuestion(Convert.ToInt32(model.SelectedQuestion));

            var prompt = $"Generar una conversación en inglés entre dos personas (Person 1 y Person 2) que hablen sobre: {question.Text}";
            var conversation = await _generateConversationService.GenerateConversation(prompt);

            var viewModel = new ConversationViewModel()
            {
                Category = category.Name,
                Question = question.Text,
                Conversation = _mapperService.ConvertToDto(conversation)
            };

            return View("Conversation", viewModel);
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionsByCategory(int categoryId)
        {
            var questions = await GetQuestions(categoryId);
            return Json(questions);
        }

        [HttpGet]
        public IActionResult Stream([FromQuery] string text, [FromQuery] string gender)
        {
            var credentialPath = _configuration["GoogleTextToSpeech:CredentialPath"];
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
            TextToSpeechClient GAPIClient = TextToSpeechClient.Create();
            SynthesisInput textInput = new SynthesisInput { Text = text };
            VoiceSelectionParams vsParams = new VoiceSelectionParams()
            {
                LanguageCode = "en-US",
                Name = (gender == "Female") ? "en-US-Standard-H" : "en-US-Standard-A"
            };
            AudioConfig config = new AudioConfig { AudioEncoding = AudioEncoding.Mp3 };
            SynthesizeSpeechResponse response = GAPIClient.SynthesizeSpeech(new SynthesizeSpeechRequest
            {
                Input = textInput,
                Voice = vsParams,
                AudioConfig = config
            });

            MemoryStream output = new MemoryStream();
            response.AudioContent.WriteTo(output);

            return File(output.ToArray(), "audio/mpeg");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}