using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.CutJob;
using UiObjectInterfaces.Dialogs;
using UiObjects.ControlObjects;
using UiObjects.PageObjects.Dialogs;
using UiObjects.PageObjects.Shell;
using UiObjects.Utilities;

namespace UiObjects.PageObjects.CutJob
{
    public class TcCutJobSolution : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobSheetProgram
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        public TiValueControl<string> Note => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.Comment" );
        public TiRawSheetList RawSheets => new TcRawSheetList( this.FindGeneric( Search.ByControlName( "RawSheetListe" ) ) );

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

                var dialog = On<TiMessageBox, TcMessageBox>();
                if( dialog.MessageBoxExists() )
                {
                    dialog.Yes();
                }
            }
        }

        public bool CanBoost => BoostButton.Enabled;

        public void Boost()
        {
            if( BoostButton.Enabled )
            {
                BoostButton.Click();
            }
        }

        public TiRawSheet AddRawSheet()
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
