using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface ICommentThreadsEndpoint
    {
        //Get Comment Thread
        Task<CommentThreadsModel> GetCommentThread(string uri);
        //Create Comment
        Task CreateComment(CommentsNewModel commentToCreate, string uri);
        Task CreateComment(string commentToCreate, string uri);
    }
}