using System;
using System.Linq;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcRawSheetList : ControlObject
    {
        protected override Search SearchPattern => Search.ByControlName( "RawSheetListe" );

        public int Count => Node.Cast<IObjectTreeNode>().Children.Count; // there's ChildCount, but it often doesn't work

        public TcRawSheet GetRawSheet( int index )
        {
            return Find<TcRawSheet>( Search.ByIndex( index ) );
        }

        public TcRawSheet FindRawSheet( Func<TcRawSheet, bool> predicate )
        {
            return FindAll<TcRawSheet>().Where( predicate ).FirstOrDefault();
        }
    }
}
