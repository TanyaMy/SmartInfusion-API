namespace BusinessLayer.Models.ViewModels.Patient
{
    public class PatientViewModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public double Weight { get; set; }
    }
}
