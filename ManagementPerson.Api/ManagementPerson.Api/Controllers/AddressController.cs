using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPerson.Api.Controllers
{
    public class AddressController : BaseController<AddressViewModel, AddressCreateUpdateViewModel>
    {
        public AddressController(IAddressService addressService) : base(addressService)
        {
        }
    }
}
