using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

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

        public CommentThreadsModel GetCommentThread(string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            return _tokenManager.Execute<CommentThreadsModel>(request);
        }

        public void GetCommentThreadAsync(Action<CommentThreadsModel> success, Action<HealthGraphException> failure, string uri)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = uri;
            _tokenManager.ExecuteAsync<CommentThreadsModel>(request, success, failure);
        }

        public void CreateComment(CommentsNewModel commentToCreate, string uri)
        {
            var request = PrepareCommentCreateRequest(commentToCreate, uri);
            _tokenManager.Execute(request);
        }

        public void CreateComment(string commentToCreate, string uri)
        {
            CreateComment(new CommentsNewModel { Comment = commentToCreate }, uri);
        }

        public void CreateCommentAsync(Action success, Action<HealthGraphException> failure, CommentsNewModel commentToCreate, string uri)
        {
            var request = PrepareCommentCreateRequest(commentToCreate, uri);
            _tokenManager.ExecuteAsync(request, success, failure);
        }

        public void CreateCommentAsync(Action success, Action<HealthGraphException> failure, string commentToCreate, string uri)
        {
            CreateCommentAsync(success, failure, new CommentsNewModel { Comment = commentToCreate }, uri);
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
            var request = new RestRequest(Method.POST);
            request.Resource = uri;

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