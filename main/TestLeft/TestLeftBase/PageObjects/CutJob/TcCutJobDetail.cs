using System;
using PageObjectInterfaces.Controls;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;
using PageObjectInterfaces.CutJob;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobDetail : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobBaseInfo
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        public TiValueControl<string> Id => Find<TiValueControl<string>>( "CutJob.Detail.Base.Name" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "CutJob.Detail.Base.FinishDate" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" );
    }
}
