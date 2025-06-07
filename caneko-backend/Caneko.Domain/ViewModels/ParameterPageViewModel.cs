namespace Caneko.Domain.ViewModels
{
    public class ParameterPageViewModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int Total { get; set; }
        public int TotalPages => Total / PageSize + (Total % PageSize > 0 ? 1 : 0);
    }
}
