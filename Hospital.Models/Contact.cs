namespace Hospital.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public HospitalInfo Hospital { get; set; }

        public String Email { get; set; }
        public String Phone { get; set; }


    }

}