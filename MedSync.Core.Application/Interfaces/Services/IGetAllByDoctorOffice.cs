namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IGetAllByDoctorOffice<T> where T : class
    {
        Task<List<T>> GetAllByDoctorOfficeAsync(int doctorOfficeId);
    }
}
