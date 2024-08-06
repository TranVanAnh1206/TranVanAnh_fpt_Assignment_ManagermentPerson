using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPerson.Api.Controllers
{
    public class ProfessorController : BaseController<ProfessorViewModel, ProfessorCreateUpdateViewModel>
    {
        public ProfessorController(IProfessorService professorService) : base(professorService)
        {
        }
    }
}
