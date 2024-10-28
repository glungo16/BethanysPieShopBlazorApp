using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApp.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
}
