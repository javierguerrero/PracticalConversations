using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "Category is required.")]

        public string SelectedCategory { get; set; }
        public List<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        public string SelectedQuestion { get; set; }
        public List<SelectListItem> QuestionList { get; set; } = new List<SelectListItem>();
    }
}