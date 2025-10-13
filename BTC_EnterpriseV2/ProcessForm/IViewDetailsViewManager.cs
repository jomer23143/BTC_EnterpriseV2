namespace BTC_EnterpriseV2.ProcessForm
{
    internal interface IViewDetailsViewManager
    {
        void Expand(object record);
        bool IsExpanded(object record);
    }
}