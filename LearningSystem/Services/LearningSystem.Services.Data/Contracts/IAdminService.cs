namespace LearningSystem.Services.Data.Contracts
{
    using AutoMapper;
    using Web.Models.ViewModels.Users;

    public interface IAdminService
    {
        EditUserViewModel GetEditUserVm(IMapper mapper, string id);
    }
}