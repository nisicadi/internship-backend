using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IStorageInputService
    {
        public StorageInput GetStorageInput(int id);
        public List<StorageInput> GetAllStorageInputs();
        public void DeleteStorageInput(int id);
        public void AddStorageInput(StorageInput storageInput);
        public void UpdateStorageInput(StorageInput storageInput);
    }
}
