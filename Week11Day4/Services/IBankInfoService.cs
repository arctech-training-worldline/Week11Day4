using System.Collections.Generic;
using System.Threading.Tasks;
using WorldlineLiveServiceReference;

namespace Week11Day4.Services
{
    public interface IBankInfoService
    {
        Task<List<BankDetails>> GetByIfscAsync(string ifsc);
    }
}