using Microsoft.WindowsAzure.Storage.Table;

namespace CommandQueue.Domain.Azure
{
    public class Table : Storage
    {
        /// <summary>
        /// Add a new table entity.
        /// </summary>
        /// <param name="tableEntity">Table entity to add.</param>
        public void AddEntity(
            ITableEntity tableEntity)
        {
            var table = GetTableReference(tableEntity.GetType().Name);
            var insertOperation = TableOperation.Insert(tableEntity);
            
            table.Execute(insertOperation);
        }

        /// <summary>
        /// Replace (update) an existing table entity.
        /// </summary>
        /// <param name="tableEntity">Table entity to replace (update).</param>
        public void ReplaceEntity(
            ITableEntity tableEntity)
        {
            var table = GetTableReference(tableEntity.GetType().Name);
            var insertOperation = TableOperation.InsertOrReplace(tableEntity);

            table.Execute(insertOperation);
        }

        /// <summary>
        /// Get a reference to the table. If one doesn't exist create it.
        /// </summary>
        /// <param name="tableAddress">Table address (name).</param>
        /// <returns>Reference to the table.</returns>
        private CloudTable GetTableReference(
            string tableAddress)
        {
            var tableClient = StorageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableAddress);

            table.CreateIfNotExists();

            return table;
        }
    }
}
