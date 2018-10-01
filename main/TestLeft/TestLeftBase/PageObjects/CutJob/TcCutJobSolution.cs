using System;
using PageObjectInterfaces.Controls;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Settings;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobSolution : TcPageObjectBase, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        public TiValueControl<string> Note => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.Comment" );
        public TcRawSheetList RawSheets => new TcRawSheetList( this.FindGeneric( Search.ByControlName( "RawSheetListe" ) ) );

        private TiButton AddPresetRawSheetButton => Find<TiButton>( "CutJob.Detail.JobSolution.AddPresetRawSheet" );
        private TiButton DeleteButton => Find<TiButton>( "CutJob.Detail.JobSolution.Delete" );
        private TiButton BoostButton => Find<TiButton>( "Part.Detail.JobSolution.ButtonBar.Calculate" );
        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public void DeleteProgram()
        {
            var deleteBtn = DeleteButton;

            if( deleteBtn.Enabled )
            {
                deleteBtn.Click();

                var dialog = On<TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }

        public void Boost()
        {
            if( BoostButton.Enabled )
            {
                BoostButton.Click();

                WaitForDetailOverlayAppear( TcSettings.SavingTimeout );
                WaitForDetailOverlayDisappear( TcSettings.SavingTimeout );
            }
        }

        public TcRawSheet AddRawSheet()
        {
            AddPresetRawSheetButton.Click();

            return RawSheets.GetRawSheet( RawSheets.Count - 1 );
        }

        public bool WaitForDetailOverlayAppear( TimeSpan timeout )
        {
            return TryWait.For( () => DetailOverlay.VisibleOnScreen, timeout );
        }

        public bool WaitForDetailOverlayDisappear( TimeSpan timeout )
        {
            return TryWait.For( () => !DetailOverlay.VisibleOnScreen, timeout );
        }
    }
}
