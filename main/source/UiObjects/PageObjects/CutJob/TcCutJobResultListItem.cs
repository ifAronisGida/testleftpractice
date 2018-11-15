using System;
using System.Windows.Controls;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.Utilities;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobResultListItem : TiCutJobResultListItem
    {
        //public long Id;
        //public string Name;
        //public string Material;
        //public string Machine;
        //public bool Archived;
        //public bool IsTemplate;
        //public DateTime FinishDate;

        private readonly IControlObject mRoot;

        public TcCutJobResultListItem( IControlObject listViewItem )
        {
            mRoot = listViewItem.FindGeneric( Search.ByControlName( "TemplateRoot" ), depth: 2 );
        }

        public string Id => mRoot.Find<TcReadOnlyText>( Search.ByControlName( "ColorSampleForIcon" ), depth: 2 ).Text;

        public string RawMaterialMachine => mRoot.Find<TcReadOnlyText>( Search.By<TextBlock>().AndByIndex( 0 ), depth: 1 ).Text;

        public DateTime? FinishDate
        {
            get
            {
                var textBlock = mRoot.Find<TcReadOnlyText>( Search.By<TextBlock>().AndByIndex( 1 ), depth: 1 );

                return textBlock.Text != string.Empty ? mRoot.Node.GetDataContextProperty<DateTime>( "FinishDate" ) : (DateTime?)null;
            }
        }
    }
}
