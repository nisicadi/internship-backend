using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementUnitController : Controller
    {
        private readonly IMeasurementUnitService _measurementUnitInterface;
        public MeasurementUnitController(IMeasurementUnitService measurementInterface)
        {
            _measurementUnitInterface = measurementInterface;
        }

        //Categories
        [HttpGet]
        public List<MeasurementUnit> GetAllMeasurementUnits()
        {
            return _measurementUnitInterface.GetAllMeasurementUnits();
        }

        [HttpGet("{id}")]
        public MeasurementUnit GetMeasurementUnitById(int id)
        {
            return _measurementUnitInterface.GetMeasurementUnit(id);
        }

        [HttpDelete("{id}")]
        public void DeleteMeasurementUnit(int id)
        {
            _measurementUnitInterface.DeleteMeasurementUnit(id);
        }

        [HttpPost]
        public void AddMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _measurementUnitInterface.AddMeasurementUnit(measurementUnit);
        }

        [HttpPut("{id}")]
        public void UpdateMeasurementUnit(MeasurementUnit measurementUnit)
        {
            _measurementUnitInterface.UpdateMeasurementUnit(measurementUnit);
        }
    }
}
