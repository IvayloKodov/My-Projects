﻿namespace ZooRestaurant.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common.Models.ViewModels.Address;
    using Infrastructure.Mapping.Extensions;
    using Services.Data.Contracts;

    [RoutePrefix("towns")]
    public class TownsController : BaseController
    {
        private readonly ITownsService towns;

        public TownsController(ITownsService towns)
        {
            this.towns = towns;
        }

        [HttpPost]
        [Route("{townId}/neighborhoods")]
        public ActionResult GetNeighborhoodsByTownId(int townId)
        {
            var neighborhoodsVm = this.towns
                                      .GetTownNeigborhoods(townId)
                                      .To<NeighborhoodViewModel>()
                                      .ToList();

            return this.PartialView("_NeighborhoodsDropDown", neighborhoodsVm);
        }
    }
}