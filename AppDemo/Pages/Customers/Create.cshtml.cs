using AppDemo.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppDemo.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CustomersService _customersService;

        [BindProperty]
        public CustomerDto Customer
        {
            get; set;
        }

        public CreateModel(IMapper mapper)
        {
            _customersService = new CustomersService(new TestRepo(), mapper);
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Customer.Id = Guid.NewGuid();
                var result = _customersService.Add(Customer);
                if (result)
                    return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
