
using AutoMapper;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Application.ViewModels.LapResults;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region Appoiment
            CreateMap<Appoiment, AppoimentViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());


            CreateMap<Appoiment, SaveAppoimentViewModel>()
                 .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore())
                .ForMember(dest => dest.Doctor, otp => otp.Ignore())
                .ForMember(dest => dest.Patient, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());

            #endregion

            #region Doctor
            CreateMap<Doctor, DoctorViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());


            CreateMap<Doctor, SaveDoctorViewModel>()
                 .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());

            #endregion

            #region DoctorOffice
            CreateMap<DoctorOffice, DoctorOfficeViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore());



            CreateMap<DoctorOffice, SaveDoctorOfficeViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());


            #endregion

            #region LabTest
            CreateMap<LabTest, LabTestViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());




            CreateMap<LabTest, SaveLabTestViewModel>()
                 .ReverseMap()
                .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
                .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
                .ForMember(dest => dest.LastModified, otp => otp.Ignore())
                .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
                .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore())
                .ForMember(dest => dest.Appoiment, otp => otp.Ignore())
                .ForMember(dest => dest.AppoimentId, otp => otp.Ignore())
                .ForMember(dest => dest.IsActive, otp => otp.Ignore());



            #endregion

            #region LabResult
            CreateMap<LabResult, LabResultViewModel>()
             .ReverseMap()
             .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
             .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
             .ForMember(dest => dest.LastModified, otp => otp.Ignore())
             .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
             .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
             .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore());

            CreateMap<LabResult, LabResultViewModel>()
               .ReverseMap()
               .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
               .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
               .ForMember(dest => dest.LastModified, otp => otp.Ignore())
               .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
               .ForMember(dest => dest.DoctorOfficeId, otp => otp.Ignore())
               .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore())
               .ForMember(dest => dest.Patient, otp => otp.Ignore())
               .ForMember(dest => dest.LabTest, otp => otp.Ignore());

            #endregion

            #region Patient
            CreateMap<Patient, PatientViewModel>()
              .ReverseMap()
             .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
             .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
             .ForMember(dest => dest.LastModified, otp => otp.Ignore())
             .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
             .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore());

            CreateMap<Patient, SavePatientViewModel>()
             .ReverseMap()
            .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
            .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
            .ForMember(dest => dest.LastModified, otp => otp.Ignore())
            .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
            .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore());
            #endregion

            #region User
            CreateMap<User, UserViewModel>()
             .ReverseMap()
            .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
            .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
            .ForMember(dest => dest.LastModified, otp => otp.Ignore())
            .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
            .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore());

            CreateMap<User, SaveUserViewModel>()
             .ForMember(dest => dest.ConfirmPassword, otp => otp.Ignore())
             .ForMember(dest => dest.DoctorOfficeName, otp => otp.Ignore())
             .ReverseMap()
            .ForMember(dest => dest.CreatedBy, otp => otp.Ignore())
            .ForMember(dest => dest.CreatedOn, otp => otp.Ignore())
            .ForMember(dest => dest.LastModified, otp => otp.Ignore())
            .ForMember(dest => dest.LastModifiedBy, otp => otp.Ignore())
            .ForMember(dest => dest.DoctorOffice, otp => otp.Ignore());
            #endregion

            #region Entity User (Domain Level)
            CreateMap<User, User>();
            #endregion
        }
    }
}
