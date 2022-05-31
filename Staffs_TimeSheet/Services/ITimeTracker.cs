using System;
using System.Threading.Tasks;
using Staffs_TimeSheet.Models;

namespace Staffs_TimeSheet.Services
{
    public interface ITimeTracker
    {
        Task <ProfileViewModel> CheckIn(string userId);
        Task<ProfileViewModel> CheckOut(string userId);
        Task<ProfileViewModel> GetDetails(string userId);

    }
}