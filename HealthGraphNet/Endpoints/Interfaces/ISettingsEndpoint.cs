using System;
using HealthGraphNet.Models;
using System.Threading.Tasks;

namespace HealthGraphNet
{
    public interface ISettingsEndpoint
    {
        Task<SettingsModel> GetSettings();
        Task<SettingsModel> UpdateSettings(SettingsModel settingsToUpdate);
    }
}