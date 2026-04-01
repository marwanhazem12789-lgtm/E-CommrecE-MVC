namespace Clinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateOnly Date { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }  
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
    }
}
