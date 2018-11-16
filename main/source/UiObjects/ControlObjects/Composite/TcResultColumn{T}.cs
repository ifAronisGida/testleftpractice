using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjects.Utilities;
using System;
using System.Windows.Controls;

namespace HomeZone.UiObjects.ControlObjects.Composite
{
    /// <summary>
    /// The result column containing the search area with search text, clear and search buttons and the result list.
    /// </summary>
    internal class TcResultColumn<T> : TcResultColumn, TiResultColumn<T> where T : class
    {
        private readonly Func<IControlObject, T> mItemFactory;

        public TcResultColumn( IControlObject resultColumn, Func<IControlObject, T> itemFactory ) : base( resultColumn )
        {
            mItemFactory = itemFactory;
        }

        public T GetItem( int index )
        {
            var cnt = Count;

            if( cnt == 0 || index >= cnt )
            {
                return null;
            }

            var listItem = ResultListView.FindGeneric( Search.By<ListViewItem>().AndByIndex( index ), depth: 1 );

            return mItemFactory( listItem );
        }

        public T SelectedItem() => ResultListView.SelectedIndex != -1 ? GetItem( ResultListView.SelectedIndex ) : null;
    }
}
