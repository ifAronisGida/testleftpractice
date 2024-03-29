using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjects.PageObjects.Shell;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobBaseInfo : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobBaseInfo
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        public TiValueControl<string> Id => Find<TiValueControl<string>>( "CutJob.Detail.Base.Name" );
        private TiValueControl<string> FinishDateControl => Find<TiValueControl<string>>( "CutJob.Detail.Base.FinishDate" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" );
        
        public DateTime? FinishDate => string.IsNullOrEmpty( FinishDateControl.Value ) ? ( DateTime? )null : Convert.ToDateTime( FinishDateControl.Value );
    }
}
