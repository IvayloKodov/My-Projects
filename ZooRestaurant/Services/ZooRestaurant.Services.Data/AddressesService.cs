namespace ZooRestaurant.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Contracts;
    using ZooRestaurant.Data.Common.Repositories;
    using ZooRestaurant.Data.Models.CustomerAddressModels;

    public class AddressesService : IAddressesService
    {
        private readonly IRepository<Town> towns;

        public AddressesService(IRepository<Town> towns)
        {
            this.towns = towns;
        }

        public IEnumerable<SelectListItem> GetTownNeigborhoodsSelectItems(int townId)
        {
            var town = this.towns.All().FirstOrDefault(t => t.Id == townId);
            var neigborhoods = town.Neighborhoods
                                    .Select(t => new SelectListItem()
                                    {
                                        Text = t.Name,
                                        Value = t.Id.ToString()
                                    });

            return neigborhoods;
        }

        public IEnumerable<SelectListItem> GetTownsSelectItems()
        {
            return this.towns
                        .All()
                        .Select(t => new SelectListItem
                        {
                            Value = t.Id.ToString(),
                            Text = t.TownName
                        });
        }
    }
}