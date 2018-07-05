using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects.Grid
{
    internal class TcHierarchyPanel : ControlObject
    {
        protected override Search SearchPattern => Search.By(new WPFPattern()
        {
            ClrFullClassName = "DevExpress.Xpf.Grid.Hierarchy.HierarchyPanel"
        });
    }
}
