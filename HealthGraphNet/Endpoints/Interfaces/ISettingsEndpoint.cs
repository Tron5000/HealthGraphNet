using System;
using HealthGraphNet.Models;

namespace HealthGraphNet
{
    public interface ISettingsEndpoint
    {
        SettingsModel GetSettings();
        void GetSettingsAsync(Action<SettingsModel> success, Action<HealthGraphException> failure);
        SettingsModel UpdateSettings(SettingsModel settingsToUpdate);
        void UpdateSettingsAsync(Action<SettingsModel> success, Action<HealthGraphException> failure, SettingsModel settingsToUpdate);
    }
}