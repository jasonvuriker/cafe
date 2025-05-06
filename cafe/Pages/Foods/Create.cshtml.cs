using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cafe.Pages.Foods
{
    public class CreateModel(IMediator mediator) : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Validation
            // Add logic
        }
    }
}
