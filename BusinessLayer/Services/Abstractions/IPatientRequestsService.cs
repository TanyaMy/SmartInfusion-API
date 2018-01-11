using Common.Entities.OrganRequests;
using System.Collections.Generic;
using Common.Models;

namespace BusinessLayer.Services.Abstractions
{
    public interface IPatientRequestsService
    {
        IList<PatientRequest> GetPatientRequests();

        IList<PatientRequest> GetPatientRequestsByUsername(string userName);

        PatientRequest GetById(int patientOrganRequestId);

        PatientRequest GetDetailedById(int id);

        void UpdatePatientRequestWithPatient(EditPatientRequestModel model);
    }
}
