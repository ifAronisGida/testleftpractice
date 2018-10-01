using System;
using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobDetail : TcPageObjectBase, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail" );

        public TiValueControl<string> Id => this.FindGeneric<TiValueControl<string>>( "CutJob.Detail.Base.Name" );
        public TiValueControl<DateTime?> FinishDate => Find<TiValueControl<DateTime?>>( "CutJob.Detail.Base.FinishDate" );
        public TiValueControl<string> RawMaterial => Find<TiValueControl<string>>( "CutJob.Detail.Base.RawMaterial.ComboBoxEdit" );
    }
}
