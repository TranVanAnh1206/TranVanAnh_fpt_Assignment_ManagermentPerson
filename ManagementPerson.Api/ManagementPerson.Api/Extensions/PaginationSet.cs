namespace ManagementPerson.Api.Extensions
{
    public class PaginationSet
    {
        public PaginationSet()
        {
        }

        public PaginationSet(int pageNumber, int pageSize, int totalCount, int totalPage, object datas)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPage = totalPage;
            Datas = datas;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public object Datas { get; set; }
    }
}
