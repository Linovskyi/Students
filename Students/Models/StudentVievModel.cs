using System.ComponentModel;

namespace Students.Models
{
    public class StudentVievModel
    {
        public int Id { get; set; }

        [DisplayName("Student name")]
        public string FirsName { get; set; }

        public string LastName { get; set; }

        public DateOnly Birthday { get; set; }

        public string RecordBook { get; set; }
    }
}
