using System;
using System.Collections.Generic;
using System.Net;
using RestSharp.Portable;
using RestSharp.Portable.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;
using RestSharp.Portable;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    /// <summary>
    /// For http://developer.runkeeper.com/healthgraph/strength-training
    /// </summary>
    public class StrengthTrainingActivitiesEndpoint : IStrengthTrainingActivitiesEndpoint
    {
        #region Fields and Properties

        public static readonly List<string> ValidExerciseType = new List<string> { "Barbell Curl", "Dumbbell Curl", "Barbell Tricep Press", "Dumbbell Tricep Press", "Overhead Press", "Wrist Curl", "Tricep Kickback", "Bench Press", "Cable Crossover", "Dumbbell Fly", "Incline Bench", "Dips", "Pushup", "Pullup", "Back Raise", "Bent-Over Row", "Seated Row", "Chinup", "Lat Pulldown", "Seated Reverse Fly", "Military Press", "Upright Row", "Front Raise", "Side Lateral Raise", "Snatch", "Push Press", "Shrug", "Crunch Machine", "Crunch", "Ab Twist", "Bicycle Kick", "Hanging Leg Raise", "Hanging Knee Raise", "Reverse Crunch", "V Up", "Situp", "Squat", "Lunge", "Dead Lift", "Hamstring Curl", "Good Morning", "Clean", "Leg Press", "Leg Extension", "Other" };
        public static readonly List<string> ValidMuscleGroup = new List<string> { "Arms", "Chest", "Back", "Shoulders", "Abs", "Legs" };

        private AccessTokenManagerBase _tokenManager;
        private UsersModel _user;

        #endregion

        #region Constructors

        public StrengthTrainingActivitiesEndpoint(AccessTokenManagerBase tokenManager, UsersModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region IStrengthTrainingActivitiesEndpoint

        public async Task<FeedModel<StrengthTrainingActivitiesFeedItemModel>> GetFeedPage(int? pageIndex = null, int? pageSize = null, DateTime? noEarlierThan = null, DateTime? noLaterThan = null, DateTime? modifiedNoEarlierThan = null, DateTime? modifiedNoLaterThan = null)
        {
            var request = ExtensionHelpers.CreateFeedPageRequest(_user.StrengthTrainingActivities, pageIndex, pageSize, noEarlierThan, noLaterThan, modifiedNoEarlierThan, modifiedNoLaterThan);
            return await _tokenManager.Execute<FeedModel<StrengthTrainingActivitiesFeedItemModel>>(request);
        }

        public Task<StrengthTrainingActivitiesPastModel> GetActivity(string uri)
        {
            if (uri.Contains(_user.StrengthTrainingActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.StrengthTrainingActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.GET);
            return _tokenManager.Execute<StrengthTrainingActivitiesPastModel>(request);
        }

        public async Task<StrengthTrainingActivitiesPastModel> UpdateActivity(StrengthTrainingActivitiesPastModel activityToUpdate)
        {
            var request = PrepareActivitiesUpdateRequest(activityToUpdate);
            return await _tokenManager.Execute<StrengthTrainingActivitiesPastModel>(request);
        }

        public async Task<string> CreateActivity(StrengthTrainingActivitiesNewModel activityToCreate)
        {
            var request = PrepareActivitiesCreateRequest(activityToCreate);
            return await _tokenManager.ExecuteCreate(request);
        }

        public async Task DeleteActivity(string uri)
        {
            if (uri.Contains(_user.StrengthTrainingActivities) == false)
            {
                throw new ArgumentException("The uri must identify a resource on or below the " + _user.StrengthTrainingActivities + " endpoint.");
            }
            var request = new RestRequest(uri, Method.DELETE);
            await _tokenManager.Execute(request, expectedStatusCode: HttpStatusCode.NoContent);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Performs validation logic prior to an update or create.
        /// </summary>
        /// <param name="activityToValidate"></param>
        private void ValidateModel(IStrengthTrainingActivitiesModel activityToValidate)
        {
            //Validate the activityToValidate properties
            ValidateHelper.IsValidLength(activityToValidate.Notes, 1024);
            if ((activityToValidate.Exercises == null) || ((activityToValidate.Exercises != null) && (activityToValidate.Exercises.Count == 0)))
            {
                throw new ArgumentException("The Exercises collection must contain one or more elements.");
            }
            else
            {
                foreach (var exercise in activityToValidate.Exercises)
                {
                    ValidateHelper.IsValueValid<string>(exercise.PrimaryType, ValidExerciseType, "Primary Type");
                    ValidateHelper.IsValueValid<string>(exercise.PrimaryMuscleGroup, ValidMuscleGroup, "Primary Muscle Group");
                    if (exercise.SecondaryMuscleGroup != null)
                    {
                        ValidateHelper.IsValueValid<string>(exercise.SecondaryMuscleGroup, ValidMuscleGroup, "Secondary Muscle Group");
                    }
                    ValidateHelper.IsValidLength(exercise.Routine, 32);
                    ValidateHelper.IsValidLength(exercise.Notes, 1024);
                    if ((exercise.Sets == null) || ((exercise.Sets != null) && (exercise.Sets.Count == 0)))
                    {
                        throw new ArgumentException("The Sets collection must contain one or more elements.");
                    }
                    else
                    {
                        foreach (var set in exercise.Sets)
                        {
                            ValidateHelper.IsValidLength(set.Notes, 1024);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Prepares the request object to create a new model.
        /// </summary>
        /// <param name="activitiesToCreate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivitiesCreateRequest(StrengthTrainingActivitiesNewModel activitiesToCreate)
        {
            var request = new RestRequest(_user.StrengthTrainingActivities, Method.POST);
            ValidateModel(activitiesToCreate);

            //Add body to the request
            request.AddParameter(StrengthTrainingActivitiesNewModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                start_time = activitiesToCreate.StartTime,
                notes = activitiesToCreate.Notes,
                total_calories = activitiesToCreate.TotalCalories,
                exercises = activitiesToCreate.Exercises,
                post_to_facebook = activitiesToCreate.PostToFacebook,
                post_to_twitter = activitiesToCreate.PostToTwitter
            }), ParameterType.RequestBody);
            return request;
        }

        /// <summary>
        /// Prepares the request object to update an existing model.
        /// </summary>
        /// <param name="activityToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareActivitiesUpdateRequest(StrengthTrainingActivitiesPastModel activityToUpdate)
        {
            var request = new RestRequest(activityToUpdate.Uri, Method.PUT);
            ValidateModel(activityToUpdate);

            //Add body to the request
            request.AddParameter(StrengthTrainingActivitiesPastModel.ContentType, _tokenManager.DefaultJsonSerializer.Serialize(new
            {
                start_time = activityToUpdate.StartTime,
                notes = activityToUpdate.Notes,
                total_calories = activityToUpdate.TotalCalories,
                exercises = activityToUpdate.Exercises
            }), ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}