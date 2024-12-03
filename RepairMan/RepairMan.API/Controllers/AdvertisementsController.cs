using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairMan.DataClasses.Common;
using RepairMan.Services.Advertising;

namespace RepairMan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        private double DistanceTo(Geoposition baseCoordinates, Geoposition targetCoordinates)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.34;
        }

        public AdvertisementsController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet]
        public IActionResult GetAdvertisement(float? latitude = null, float? longitude = null, string url = null)
        {
            return Ok(_advertisementService.All(x => 
            (url == null || x.Url == url)
            && (x.Context.Start == null || (DateTime.UtcNow >= x.Context.Start))
            && (x.Context.End == null || (DateTime.UtcNow <= x.Context.End))
            && (x.Context.GeopositionId == null || ((latitude == null || longitude == null) || DistanceTo(new Geoposition(latitude.Value, longitude.Value), x.Context.Geoposition) < x.Context.Range))
            ).OrderBy(x => x.Relevance));
        }
    }
}
