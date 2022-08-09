using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        private readonly IStorageService _storageInterface;

        public StorageController(IStorageService storageInterface)
        {
            _storageInterface = storageInterface;
        }

        [HttpGet]
        public List<Storage> GetAllStorages()
        {
            return _storageInterface.GetAllStorages();
        }

        [HttpGet("{id}")]
        public Storage GetStorageById(int id)
        {
            return _storageInterface.GetStorage(id);
        }

        [HttpDelete("{id}")]
        public void DeleteStorage(int id)
        {
            _storageInterface.DeleteStorage(id);
        }

        [HttpPost]
        public void AddStorage(Storage storage)
        {
            _storageInterface.AddStorage(storage);
        }

        [HttpPut("{id}")]
        public void UpdateStorage(Storage storage)
        {
            _storageInterface.UpdateStorage(storage);
        }
    }
}
