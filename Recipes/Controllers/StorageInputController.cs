using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageInputController : Controller
    {
        private readonly IStorageInputService _storageInputInterface;

        public StorageInputController(IStorageInputService storageInputInterface)
        {
            _storageInputInterface = storageInputInterface;
        }

        [HttpGet]
        public List<StorageInput> GetAllStorageInputs()
        {
            return _storageInputInterface.GetAllStorageInputs();
        }

        [HttpGet("{id}")]
        public StorageInput GetStorageInputById(int id)
        {
            return _storageInputInterface.GetStorageInput(id);
        }

        [HttpDelete("{id}")]
        public void DeleteStorageInput(int id)
        {
            _storageInputInterface.DeleteStorageInput(id);
        }

        [HttpPost]
        public void AddStorageInput(StorageInput storageInput)
        {
            _storageInputInterface.AddStorageInput(storageInput);
        }

        [HttpPut("{id}")]
        public void UpdateStorageInput(StorageInput storageInput)
        {
            _storageInputInterface.UpdateStorageInput(storageInput);
        }
    }
}
