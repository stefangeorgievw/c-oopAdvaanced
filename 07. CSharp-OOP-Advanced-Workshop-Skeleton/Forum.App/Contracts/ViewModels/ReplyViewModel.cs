using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
    class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string content, string author) : base(content)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
