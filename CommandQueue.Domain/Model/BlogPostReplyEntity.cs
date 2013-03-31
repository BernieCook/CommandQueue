using CommandQueue.Domain.Azure;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Diagnostics;

namespace CommandQueue.Domain.Model
{
    public class BlogPostReplyEntity : TableEntity
    {
        public string Reply { get; set; }
        public string EmailAddress { get; set; }
        public bool ModeratorsNotified { get; set; }
        public bool Authorised { get; set; }
        public DateTime? ModeratorsNotifiedDateTime { get; set; }
        public DateTime? AuthorisedDateTime { get; set; }
        public DateTime AddedDateTime { get; set; }

        public BlogPostReplyEntity()
        {
            PartitionKey = Guid.NewGuid().ToString();
            RowKey = PartitionKey;

            ModeratorsNotified = false;
            ModeratorsNotifiedDateTime = null;

            Authorised = false;
            AuthorisedDateTime = null;

            AddedDateTime = DateTime.UtcNow;
        }

        /// <summary>
        /// Notify all moderators that a new blog post reply needs to be moderated.
        /// </summary>
        public void NotifyModerators()
        {
            // Fabricate some moderators.
            var moderators = new[]
                {
                    new { Name = "Luke Skywalker", EmailAddress = "lukeskywalker@galactic-senate.com" },
                    new { Name = "Han Solo", EmailAddress = "hansolo@galactic-senate.com" },
                    new { Name = "Leia Skywalker", EmailAddress = "leiaskywalker@galactic-senate.com" }
                };
 
            foreach (var moderator in moderators)
            {
                SendModeratorNotificationMessage(moderator.Name, moderator.EmailAddress);
            }

            FlagAsModeratorNotified();
        }

        /// <summary>
        /// Send a moderator notification message.
        /// </summary>
        /// <param name="moderatorName">Moderator's name.</param>
        /// <param name="moderatorEmailAddress">Moderator's email address.</param>
        private void SendModeratorNotificationMessage(
            string moderatorName,
            string moderatorEmailAddress)
        {
            Debug.WriteLine("Send notification message to '{0}' at '{1}' for the blog post reply: '{2}' from: '{3}'",
                moderatorName,
                moderatorEmailAddress,
                Reply,
                EmailAddress);
        }

        /// <summary>
        /// Flag the blog post reply as having had the relevant moderator's notified.
        /// </summary>
        private void FlagAsModeratorNotified()
        {
            ModeratorsNotified = true;
            ModeratorsNotifiedDateTime = DateTime.UtcNow;

            var table = new Table();
            table.ReplaceEntity(this);
        }
    }
}
