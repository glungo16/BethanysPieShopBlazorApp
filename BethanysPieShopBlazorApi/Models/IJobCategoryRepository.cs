using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopBlazorApi.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}
