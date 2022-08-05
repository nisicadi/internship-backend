using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class MeasurementUnitService : IMeasurementUnitService
    {
        private PraksaDBContext praksaDBContext;
        public MeasurementUnitService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public MeasurementUnit GetMeasurementUnit(int id)
        {
            return praksaDBContext.MeasurementUnits.Find(id);
        }

        public List<MeasurementUnit> GetAllMeasurementUnits()
        {
            return praksaDBContext.MeasurementUnits.ToList();
        }

        public void DeleteMeasurementUnit(int id)
        {
            praksaDBContext.MeasurementUnits.Remove(GetMeasurementUnit(id));
            praksaDBContext.SaveChanges();
        }

        public void AddMeasurementUnit(MeasurementUnit measurementUnit)
        {
            praksaDBContext.MeasurementUnits.Add(measurementUnit);
            praksaDBContext.SaveChanges();
        }

        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            praksaDBContext.MeasurementUnits.Update(measurementUnit);
            praksaDBContext.SaveChanges();
        }
    }
}
