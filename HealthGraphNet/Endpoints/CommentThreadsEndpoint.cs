using System;
using System.Collections.Generic;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// For http://developer.runkeeper.com/healthgraph/comments
    /// </summary>
    public class CommentThreadsEndpoint : ICommentThreadsEndpoint
    {
        #region Fields and Properties

        private AccessTokenManagerBase _tokenManager;

        #endregion

        #region Constructors

        public CommentThreadsEndpoint(AccessTokenManagerBase tokenManager)
        {
            _tokenManager = tokenManager;
        }

        #endregion

        #region ICommentThreadsEndpoint

        public async Task<CommentThreadsModel> GetCommentThread(string uri)
        {
            var request = new RestRequest(uri, Method.GET);
            request.Resource = uri;
            return await _tokenManager.Execute<CommentThreadsModel>(request);
        }

        public async Task CreateComment(CommentsNewModel commentToCreate, string uri)
        {
            var request = PrepareCommentCreateRequest(commentToCreate, uri);
            await _tokenManager.Execute(request);
        }

        public Task CreateComment(string commentToCreate, string uri)
        {
            return CreateComment(new CommentsNewModel { Comment = commentToCreate }, uri);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="commentToCreate"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        private IRestRequest PrepareCommentCreateRequest(CommentsNewModel commentToCreate, string uri)
        {
            var request = new RestRequest(uri, Method.POST);

            //Add body to the request
            request.AddParameter(CommentsNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                comment = commentToCreate.Comment
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}