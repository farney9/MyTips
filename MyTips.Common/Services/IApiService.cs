using System.Threading.Tasks;


namespace MyTips.Common.Services
{
    public interface IApiService
    {
        Task<bool> CheckConnectionAsync(string url);
    }
}
