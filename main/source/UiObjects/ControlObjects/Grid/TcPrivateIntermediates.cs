using DevExpress.Xpf.Grid;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.ControlObjects.Grid
{
    internal class TcBandedViewContentSelector : ViewControlObject<BandedViewContentSelector>
    {
    }

    internal class TcGridCellContentPresenter : ViewControlObject<GridCellContentPresenter>
    {
    }

    internal class TcHierarchyPanel : ControlObject
    {
        protected override Search SearchPattern => Search.By(new WPFPattern()
        {
            ClrFullClassName = "DevExpress.Xpf.Grid.Hierarchy.HierarchyPanel"
        });
    }
}
