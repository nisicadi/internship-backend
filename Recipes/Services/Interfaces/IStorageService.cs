using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IStorageService
    {
        public Storage GetStorage(int id);
        public List<Storage> GetAllStorages();
        public void DeleteStorage(int id);
        public void AddStorage(Storage storage);
        public void UpdateStorage(Storage storage);
    }
}
