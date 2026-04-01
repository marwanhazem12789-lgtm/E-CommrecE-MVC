namespace Clinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialiy { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
