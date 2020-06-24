using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class Comment : Entity<Guid>
    {
        #region Constructors and properites

        private List<Guid> _replies;
        private Comment(Guid id) : base(id)
        {

        }

        public Guid AuthorProfileId { get; private set; }
        public string Message { get; private set; }
        public DateTime? DateCreated { get; private set; }
        public DateTime? LastModified { get; private set; }
        public IEnumerable<Guid> Replies
        {
            get { return _replies; }
        }
        #endregion

        #region Factories
        public static Comment Create(Guid id, Guid authorId, string message, DateTime? dateCreated = null,
            DateTime? lastModified = null, IEnumerable<Guid> replies = null)
        {
            var comment = new Comment(id);
            comment.AuthorProfileId = authorId;
            comment.Message = message;
            comment.DateCreated = dateCreated ?? DateTime.UtcNow;
            comment.LastModified = lastModified ?? DateTime.UtcNow;
            comment._replies = replies != null ? replies.ToList() : new List<Guid>();

            return comment;
        }
        #endregion

        #region Public methods
        public void EditComment(string updatedMessage)
        {
            Message = updatedMessage;
            LastModified = DateTime.UtcNow;
        }

        public void AddReply(Guid commentId)
        {
            _replies.Add(commentId);
        }

        public void DeleteReply (Guid commentId)
        {
            var comment = _replies.FirstOrDefault(r => r == commentId);
            if (comment == null)
                throw new ArgumentException("Comment not found");

            _replies.Remove(comment);
        }
        #endregion
    }
}
