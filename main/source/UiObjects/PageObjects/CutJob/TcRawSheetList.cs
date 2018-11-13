using System.Windows.Controls;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.Utilities;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcRawSheetList : TiRawSheetList
    {
        private readonly IControlObject mControlObject;

        public TcRawSheetList( IControlObject controlObject )
        {
            mControlObject = controlObject;
        }

        public int Count => mControlObject.Node.Cast<IObjectTreeNode>().Children.Count; // there's ChildCount, but it often doesn't work

        public TiRawSheet GetRawSheet( int index )
        {
            return new TcRawSheet( mControlObject.FindGeneric( Search.By<ContentPresenter>().AndByIndex( index ) ) );
        }
    }
}
