namespace ZooRestaurant.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IAddressesService
    {
        IEnumerable<SelectListItem> GetTownNeigborhoodsSelectItems(int townId);

        IEnumerable<SelectListItem> GetTownsSelectItems();
    }
}