using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface ICommentThreadsEndpoint
    {
        //Get Comment Thread
        CommentThreadsModel GetCommentThread(string uri);
        void GetCommentThreadAsync(Action<CommentThreadsModel> success, Action<HealthGraphException> failure, string uri);
        //Create Comment
        void CreateComment(CommentsNewModel commentToCreate, string uri);
        void CreateCommentAsync(Action success, Action<HealthGraphException> failure, CommentsNewModel commentToCreate, string uri); 
    }
}