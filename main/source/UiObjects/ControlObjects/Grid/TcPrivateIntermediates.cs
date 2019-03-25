using HomeZone.UiObjects.Utilities;
using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.ControlObjects.Grid
{
    internal class TcBandedViewContentSelector : ControlObject
    {
        protected override Search SearchPattern => SearchEx.ByClass( DevExpress.BandedViewContentSelector );
    }

    internal class TcGridCellContentPresenter : ControlObject
    {
        protected override Search SearchPattern => SearchEx.ByClass( DevExpress.GridCellContentPresenter );
    }

    internal class TcHierarchyPanel : ControlObject
    {
        protected override Search SearchPattern => Search.By(new WPFPattern()
        {
            ClrFullClassName = "DevExpress.Xpf.Grid.Hierarchy.HierarchyPanel"
        });
    }
}
