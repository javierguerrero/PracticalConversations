using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public string SelectedCategory { get; set; }
        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        public string SelectedQuestion { get; set; }
        public List<SelectListItem> QuestionList { get; set; } = new List<SelectListItem>();
    }
}