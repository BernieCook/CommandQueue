using CommandQueue.Domain.Interfaces;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CommandQueue.Domain.Azure
{
    public class Queue : Storage
    {
        /// <summary>
        /// Add a new message to the queue.
        /// </summary>
        /// <param name="command">Command message to add.</param>
        public void AddMessage(
            ICommand command)
        {
            var queue = GetQueueReference(command.GetType().Name);
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(command));

            queue.AddMessage(message);
        }

        /// <summary>
        /// Get the next message from the specified queue.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <param name="visibilityTimeout">Visibility timeout, in seconds.</param>
        /// <returns>Queue message.</returns>
        public CloudQueueMessage GetMessage(
            string queueName,
            int visibilityTimeout = 2)
        {
            var queue = GetQueueReference(queueName);

            return queue.GetMessage(new TimeSpan(0, 0, visibilityTimeout));
        }

        /// <summary>
        /// Get the next message from the specified queue.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <param name="messageCount">Total messages to retrieve.</param>
        /// <param name="visibilityTimeout">Visibility timeout, in seconds.</param>
        /// <returns>Queue message.</returns>
        public IEnumerable<CloudQueueMessage> GetMessages(
            string queueName,
            int messageCount = 10,
            int visibilityTimeout = 4)
        {
            var queue = GetQueueReference(queueName);

            return queue.GetMessages(messageCount, new TimeSpan(0, 0, visibilityTimeout));
        }

        /// <summary>
        /// Get a reference to a given queue. If one doesn't exist create it.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Reference to the queue.</returns>
        private CloudQueue GetQueueReference(
            string queueName)
        {
            var queueClient = StorageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName.ToLowerInvariant());

            queue.CreateIfNotExists();

            return queue;
        }

        /// <summary>
        /// Delete the specified message.
        /// </summary>
        /// <param name="queueName">Queue to delete the message from.</param>
        /// <param name="message">Delete the message from the queue.</param>
        public void DeleteMessage(
            string queueName,
            CloudQueueMessage message)
        {
            var queue = GetQueueReference(queueName);

            queue.DeleteMessage(message);
        }
    }
}
