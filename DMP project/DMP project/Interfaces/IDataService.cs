using DMP_project.Models;

namespace DMP_project.Interfaces
{
    public interface IDataService
    {
        List<ExtractedDataModel> GetExtractedData();
    }
}
