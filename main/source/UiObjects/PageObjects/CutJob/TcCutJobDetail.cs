using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.CutJob;
using UiObjects.PageObjects.Shell;


namespace UiObjects.PageObjects.CutJob
{
    public class TcCutJobDetail : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobBaseInfo
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        public TiValueControl<string> Id => Find<TiValueControl<string>>( "CutJob.Detail.Base.Name" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "CutJob.Detail.Base.FinishDate" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" );
    }
}
