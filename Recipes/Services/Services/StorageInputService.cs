using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class StorageInputService : IStorageInputService
    {
        private PraksaDBContext praksaDBContext;
        public StorageInputService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public StorageInput GetStorageInput(int id)
        {
            return praksaDBContext.StorageInputs.Find(id);
        }

        public List<StorageInput> GetAllStorageInputs()
        {
            return praksaDBContext.StorageInputs.ToList();
        }

        public void DeleteStorageInput(int id)
        {
            praksaDBContext.StorageInputs.Remove(GetStorageInput(id));
            praksaDBContext.SaveChanges();
        }

        public void AddStorageInput(StorageInput storageInput)
        {
            Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == storageInput.FoodstuffId).First();
            if(storageInput.RemoveQuantity)
                storage.Quantity-=storageInput.Quantity;
            else
                storage.Quantity += storageInput.Quantity;
            storage.UnderMin = storage.Quantity < storage.MinQuantity;
            praksaDBContext.Storages.Update(storage);

            storageInput.InputDate = System.DateTime.Now;
            storageInput.Foodstuff = praksaDBContext.Foodstuffs.Find(storageInput.FoodstuffId);
            praksaDBContext.StorageInputs.Add(storageInput);
            praksaDBContext.SaveChanges();
        }

        public void UpdateStorageInput(StorageInput storageInput)
        {
            praksaDBContext.StorageInputs.Update(storageInput);
            praksaDBContext.SaveChanges();
        }
    }
}
