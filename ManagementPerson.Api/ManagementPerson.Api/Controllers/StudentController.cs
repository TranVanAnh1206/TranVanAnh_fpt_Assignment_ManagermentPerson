using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPerson.Api.Controllers
{
    public class StudentController : BaseController<StudentViewModel, StudentCreateUpdateViewModel>
    {
        public StudentController(IStudentService studentService) : base(studentService)
        {
        }
    }
}
