using System;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage.Table;

namespace CommandQueue.Domain.Model
{
    public class ComplaintEntity : TableEntity
    {
        private const string LevelsToProcess = "top-priority";

        public string FullName { get; set; }
        public string Complaint { get; set; }
        public string Level { get; set; }

        /// <summary>
        /// Handle the complaint.
        /// </summary>
        internal void HandleComplaint()
        {
            if (Level.Equals(LevelsToProcess, StringComparison.OrdinalIgnoreCase))
            {
                SendComplaintToManager();
            }
        }

        /// <summary>
        /// Send this complaint to the manager.
        /// </summary>
        private void SendComplaintToManager()
        {
            Debug.WriteLine("Send complaint message: '{0}' from '{1}'",
                Complaint,
                FullName);
        }
    }
}
