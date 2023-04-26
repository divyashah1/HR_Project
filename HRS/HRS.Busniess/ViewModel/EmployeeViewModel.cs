namespace HRS.Busniess.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public int Mobile { get; set; }

        public int dep_Id { get; set; }

        public int designation_Id { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string? UpdatedBy { get; set; }

    }
}
