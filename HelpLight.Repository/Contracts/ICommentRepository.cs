using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface ICommentRepository : IWorkUnit
    {
        void AddComment(Contracts.Comment comment);
    }
}
