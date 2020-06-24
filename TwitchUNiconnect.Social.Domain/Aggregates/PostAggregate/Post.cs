using System;
using System.Collections.Generic;
using System.Linq;
using Twtich.Uniconnect.SharedKernel.Interfaces;
using Twtich.Uniconnect.SharedKernel.Types;

namespace TwitchUNiconnect.Social.Domain.Aggregates.PostAggregate
{
    public class Post : Entity<Guid>, IAggregateRoot
    {
        #region Constructors and properties

        private List<Uri> _mediaUrls;
        private List<Comment> _comments;
        private List<Interaction> _interactions;
        private Post(Guid id) : base(id)
        {
        }

        public PostType Type { get; private set; }
        public string Text { get; private set; }
        public Guid AuthorProfileId { get; private set; }
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

        #region Factories
        public static Post Create(Guid id, PostType type, string text, Guid authorProfileId,
            DateTime? dateCreated = null, DateTime? lastModified = null,
            List<Uri> mediaUrls = null, List<Comment> comments = null,
            List<Interaction> interactions = null)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("The identifier can't be a defauilt value");

            // TO DO: Implement validation for inputs
            var post = new Post(id);
            post.Type = type;
            post.Text = text;
            post.AuthorProfileId = authorProfileId;
            post.DateCreated = dateCreated == null ? DateTime.UtcNow : dateCreated;
            post.LastModified = lastModified == null ? DateTime.UtcNow : lastModified;

            post._mediaUrls = mediaUrls ?? new List<Uri>();
            post._interactions = interactions ?? new List<Interaction>();
            post._comments = comments ?? new List<Comment>();

            return post;

        }
        #endregion

        #region Public methods
        public void AddMediaUrl(Uri url)
        {
            // TO DO: Perform validation
            _mediaUrls.Add(url);
            LastModified = DateTime.UtcNow;
            // TO DO: Fire media added event
        }

        public void RemoveMediaUrl(Uri url)
        {
            var toRemove = _mediaUrls.FirstOrDefault( u => u == url);

            if (toRemove != null)
            {
                _mediaUrls.Remove(toRemove);
                LastModified = DateTime.UtcNow;
                // TO DO: fire event
            }
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
            LastModified = DateTime.UtcNow;
        }

        public void RemoveComment(Guid commentId)
        {
            var toRemove = _comments.FirstOrDefault(c => c.Id == commentId);

            if (!(toRemove is null))
            {
                _comments.Remove(toRemove);
                LastModified = DateTime.UtcNow;
                // TO DO: Fire comment remeoved event
            }
        }

        public void AddInteraction(Interaction interaction)
        {
            _interactions.Add(interaction);
            LastModified = DateTime.UtcNow;
            // TO DO: Fire interaction added event
        }

        public void RemoveInteraction(Interaction interaction)
        {
            var toRemove = _interactions.FirstOrDefault(i => i == interaction);
            if (toRemove != null)
            {
                _interactions.Remove(toRemove);
                LastModified = DateTime.UtcNow;
                // TO Do: Fire interaction removed event
            }
        }

        private void EditPostText(string newText)
        {
            Text = newText;
            LastModified = DateTime.UtcNow;

            // TO DO: Fire post edited event
        }
        #endregion
    }
}
