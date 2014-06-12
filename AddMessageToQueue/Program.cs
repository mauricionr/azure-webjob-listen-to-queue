using Common;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMessageToQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("sendoutqueue");

            queue.CreateIfNotExists();

            var email = new Email()
            {
                To = "kalle@anka.se",
                Message = "Hello"
            };

            queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(email)));

        }
    }
}
