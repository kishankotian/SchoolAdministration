using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RegistrationModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Teacher { get; set; }
        [Required]
        public IEnumerable<string> Students { get; set; }
    }

    public class SuspendModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Student { get; set; }
    }

    public class NotificationModel
    {
        [Required]
        public string Teacher { get; set; }
        [Required]
        public string Notification { get; set; }
    }

    public class StudentListModel
    {
        public IEnumerable<string> Students { get; set; }
    }
}
