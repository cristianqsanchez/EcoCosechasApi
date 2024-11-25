namespace EcoCosechas.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage= 50;
        private readonly int maxRecordsPerPage= 50;

        public int RecordsPerPage
        {
            get
            {
                return recordsPerPage;
            }
            set
            {
                recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
            }
        }
    }
}