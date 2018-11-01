namespace DomainModel
{
    public class Args
    {
        public const int MaxPageSize = 50;
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string Tag { get; set; } = "";
    }
}