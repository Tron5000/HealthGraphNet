using System;
using System.Dynamic;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Serializers;
using HealthGraphNet.Models;
using HealthGraphNet.RestSharp;

namespace HealthGraphNet
{
    /// <summary>
    /// Endpoint for retrieving and updating a user's settings. http://developer.runkeeper.com/healthgraph/settings
    /// </summary>
    public class SettingsEndpoint : ISettingsEndpoint
    {
        #region Fields and Properties

        private const string ContentType = "application/vnd.com.runkeeper.Settings+json";
        public static readonly List<string> ValidVisibility = new List<string> { "Just Me", "Street Team", "Everyone" };
        public static readonly List<string> ValidDistanceUnit = new List<string> { "mi", "km" };
        public static readonly List<string> ValidWeightUnit = new List<string> { "lbs", "kg" };
        public static readonly List<string> ValidFirstDayOfWeek = new List<string> { "Sunday", "Monday" };

        private AccessTokenManagerBase _tokenManager;
        private UserModel _user;

        #endregion

        #region Constructors

        public SettingsEndpoint(AccessTokenManagerBase tokenManager, UserModel user)
        {
            _tokenManager = tokenManager;
            _user = user;
        }

        #endregion

        #region ISettingsEndpoint

        public SettingsModel GetSettings()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Settings;
            return _tokenManager.Execute<SettingsModel>(request);
        }

        public void GetSettingsAsync(Action<SettingsModel> success, Action<HealthGraphException> failure)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = _user.Settings;
            _tokenManager.ExecuteAsync<SettingsModel>(request, success, failure);
        }

        public SettingsModel UpdateSettings(SettingsModel settingsToUpdate)
        {
            var request = PrepareUpdateRequest(settingsToUpdate);
            return _tokenManager.Execute<SettingsModel>(request);
        }

        public void UpdateSettingsAsync(Action<SettingsModel> success, Action<HealthGraphException> failure, SettingsModel settingsToUpdate)
        {
            var request = PrepareUpdateRequest(settingsToUpdate);
            _tokenManager.ExecuteAsync<SettingsModel>(request, success, failure);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Prepares the request object to be updated.
        /// </summary>
        /// <param name="settingsToUpdate"></param>
        /// <returns></returns>
        private IRestRequest PrepareUpdateRequest(SettingsModel settingsToUpdate)
        {
            var request = new RestRequest(Method.PUT);
            request.Resource = _user.Settings;

            //Validate settingsToUpdate properties
            Validate.IsValueValid<string>(settingsToUpdate.ShareFitnessActivities, ValidVisibility, "ShareFitnessActivities");
            Validate.IsValueValid<string>(settingsToUpdate.ShareMap, ValidVisibility, "ShareMap");
            Validate.IsValueValid<string>(settingsToUpdate.ShareBackgroundActivities, ValidVisibility, "ShareBackgroundActivities");
            Validate.IsValueValid<string>(settingsToUpdate.ShareSleep, ValidVisibility, "ShareSleep");
            Validate.IsValueValid<string>(settingsToUpdate.ShareNutrition, ValidVisibility, "ShareNutrition");
            Validate.IsValueValid<string>(settingsToUpdate.ShareWeight, ValidVisibility, "ShareWeight");
            Validate.IsValueValid<string>(settingsToUpdate.ShareGeneralMeasurements, ValidVisibility, "ShareGeneralMeasurements");
            Validate.IsValueValid<string>(settingsToUpdate.ShareDiabetes, ValidVisibility, "ShareDiabetes");
            Validate.IsValueValid<string>(settingsToUpdate.DistanceUnits, ValidDistanceUnit, "DistanceUnits");
            Validate.IsValueValid<string>(settingsToUpdate.WeightUnits, ValidWeightUnit, "WeightUnits");
            Validate.IsValueValid<string>(settingsToUpdate.FirstDayOfWeek, ValidFirstDayOfWeek, "FirstDayOfWeek");

            //Add body to the request
            request.AddParameter(ContentType, new
            {
                share_fitness_activities = settingsToUpdate.ShareFitnessActivities,
                share_map = settingsToUpdate.ShareMap,
                post_fitness_activity_facebook = settingsToUpdate.PostFitnessActivityFacebook,
                post_fitness_activity_twitter = settingsToUpdate.PostFitnessActivityTwitter,
                post_live_fitness_activity_facebook = settingsToUpdate.PostLiveFitnessActivityFacebook,
                post_live_fitness_activity_twitter = settingsToUpdate.PostLiveFitnessActivityTwitter,
                share_background_activities = settingsToUpdate.ShareBackgroundActivities,
                post_background_activity_facebook = settingsToUpdate.PostBackgroundActivityFacebook,
                post_background_activity_twitter = settingsToUpdate.PostBackgroundActivityTwitter,
                share_sleep = settingsToUpdate.ShareSleep,
                post_sleep_facebook = settingsToUpdate.PostSleepFacebook,
                post_sleep_twitter = settingsToUpdate.PostSleepTwitter,
                share_nutrition = settingsToUpdate.ShareNutrition,
                post_nutrition_facebook = settingsToUpdate.PostNutritionFacebook,
                post_nutrition_twitter = settingsToUpdate.PostNutritionTwitter,
                share_weight = settingsToUpdate.ShareWeight,
                post_weight_facebook = settingsToUpdate.PostWeightFacebook,
                post_weight_twitter = settingsToUpdate.PostWeightTwitter,
                share_general_measurements = settingsToUpdate.ShareGeneralMeasurements,
                post_general_measurements_facebook = settingsToUpdate.PostGeneralMeasurementsFacebook,
                post_general_measurements_twitter = settingsToUpdate.PostGeneralMeasurementsTwitter,
                share_diabetes = settingsToUpdate.ShareDiabetes,
                post_diabetes_facebook = settingsToUpdate.PostDiabetesFacebook,
                post_diabetes_twitter = settingsToUpdate.PostDiabetesTwitter,
                distance_units = settingsToUpdate.DistanceUnits,
                weight_units = settingsToUpdate.WeightUnits,
                first_day_of_week = settingsToUpdate.FirstDayOfWeek
            }, ParameterType.RequestBody);
            return request;
        }

        #endregion
    }
}