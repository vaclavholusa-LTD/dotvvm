namespace DotVVM.Framework.Controls
{
    public interface IPageableGridViewDataSet
    {
        IPagingOptions PagingOptions { get; set; }
        void GoToFirstPage();
        void GoToLastPage();
        void GoToNextPage();
        void GoToPage(int index);
        void GoToPreviousPage();
    }
}