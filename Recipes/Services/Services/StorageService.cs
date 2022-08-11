using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class StorageService : IStorageService
    {
        private PraksaDBContext praksaDBContext;
        public StorageService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public Storage GetStorage(int id)
        {
            return praksaDBContext.Storages.Find(id);
        }

        public List<Storage> GetAllStorages()
        {
            //Order by UnderMin desc, Name asc
            return praksaDBContext.Storages.OrderByDescending(ob => ob.UnderMin).ThenBy(ob2 => ob2.Foodstuff.FoodstuffName).ToList();
        }

        public void DeleteStorage(int id)
        {
            praksaDBContext.Storages.Remove(GetStorage(id));
            praksaDBContext.SaveChanges();
        }

        public void AddStorage(Storage storage)
        {
            storage.Foodstuff = praksaDBContext.Foodstuffs.Find(storage.FoodstuffId);
            praksaDBContext.Storages.Add(storage);
            praksaDBContext.SaveChanges();
        }

        public void UpdateStorage(Storage storage)
        {
            praksaDBContext.Storages.Update(storage);
            praksaDBContext.SaveChanges();
        }
    }
}
