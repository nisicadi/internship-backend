using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IMeasurementUnitService
    {
        public MeasurementUnit GetMeasurementUnit(int id);
        public List<MeasurementUnit> GetAllMeasurementUnits();
        public void DeleteMeasurementUnit(int id);
        public void AddMeasurementUnit(MeasurementUnit measurementUnit);
        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit);
    }
}
