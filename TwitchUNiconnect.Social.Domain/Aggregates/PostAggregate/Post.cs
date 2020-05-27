using System;
using System.Collections.Generic;
using System.Text;
using TwitchUNiconnect.Social.Domain.Aggregates.UserAggregate;
using Twtich.Uniconnect.SharedKernel.Interfaces;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class Post : Entity<Guid>, IAggregateRoot
    {
        #region Constructors and properties

        private readonly List<Uri> _mediaUrls;
        private readonly List<Comment> _comments;
        private readonly List<Interaction> _interactions;
        private Post(Guid id) : base(id)
        {

        }

        public PostType Type { get; private set; }
        public string Text { get; private set; }
        public Guid Author { get; private set; }
        public IEnumerable<Uri> MediaUrl 
        {
            get { return _mediaUrls; } 
        }
        public DateTime? DateCreated { get; private set; }
        public DateTime? LastModified { get; private set; }
        public IEnumerable<Comment> Comments
        {
            get { return _comments; }
        }

        public IEnumerable<Interaction> Interactions
        {
            get { return _interactions; }
        }

        public int NumberOfComments
        {
            get { return _comments.Count; }
        }

        public int NumberOfInteractions
        {
            get { return _interactions.Count; }
        }
        #endregion
    }
}
