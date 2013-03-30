using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;

namespace CommandQueue.Domain.Azure
{
    public abstract class Storage
    {
        private const string StorageConnectionString = "StorageConnectionString";

        protected readonly CloudStorageAccount StorageAccount;

        protected Storage()
        {
            StorageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting(StorageConnectionString));
        }
    }
}
