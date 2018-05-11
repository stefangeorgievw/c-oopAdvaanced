using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyContent = args[0];
            if (string.IsNullOrWhiteSpace(replyContent))
            {
                throw new ArgumentException("Cannot add empty reply");
            }

            int postId = int.Parse(args[1]);
            int userId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyContent, userId);
            return this.session.Back();
        }
    }
}
