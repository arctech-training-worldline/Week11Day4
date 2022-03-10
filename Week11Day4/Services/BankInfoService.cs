using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WorldlineLiveServiceReference;
using System.Linq;

namespace Week11Day4.Services
{
    public class BankInfoService : IBankInfoService
    {
        public readonly string serviceUrl = "https://bankdetailsdemo.azurewebsites.net/WebServices/SoapDemo.asmx";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public BankInfoService()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding = new BasicHttpBinding(
                endpointAddress.Uri.Scheme.ToLower() == "http" ?
                    BasicHttpSecurityMode.None :
                    BasicHttpSecurityMode.Transport)
            {
                OpenTimeout = TimeSpan.MaxValue,
                CloseTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue
            };
        }

        private async Task<SoapDemoSoapClient> GetInstanceAsync()
        {
            return await Task.Run(() => new SoapDemoSoapClient(basicHttpBinding, endpointAddress));
        }

        public async Task<List<BankDetails>> GetByIfscAsync(string ifsc)
        {
            var wsClient = await GetInstanceAsync();
            var getBranchDetailsByIfscResponse = await wsClient.GetBranchDetailsByIfscAsync(ifsc);

            return new List<BankDetails> { getBranchDetailsByIfscResponse.Body.GetBranchDetailsByIfscResult };
        }
    }
}
