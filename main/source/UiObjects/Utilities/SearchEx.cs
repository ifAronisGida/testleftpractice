using SmartBear.TestLeft.TestObjects.WPF;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.Utilities
{
    internal static class SearchEx
    {
        public static Search ByClass(string className)
        {
            return Search.By( new WPFPattern()
            {
                ClrFullClassName = className
            } );
        }
    }
}
