using System;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.Waiting;
using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using HomeZone.UiObjectInterfaces.CutJob;
using HomeZone.UiObjectInterfaces.Dialogs;
using HomeZone.UiObjects.ControlObjects;
using HomeZone.UiObjects.PageObjects.Dialogs;
using HomeZone.UiObjects.PageObjects.Shell;
using HomeZone.UiObjects.Utilities;
using System.Windows.Controls;

namespace HomeZone.UiObjects.PageObjects.CutJob
{
    public class TcCutJobSolution : TcPageObjectBase, IChildOf<TcDetailContent>, TiCutJobSolution
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        public string StateToolTip => StateIcon.ToolTip;

        // button bar
        private TcTooltipAccessor StateIcon => Find<TcTooltipAccessor>( Search.By<Border>().AndByIndex( 1 ) ); // missing uid
        private TiButton BoostButton => Find<TiButton>( "Part.Detail.JobSolution.ButtonBar.Calculate" );
        private TiButton ReleaseButton => Find<TiButton>( "Part.Detail.JobSolution.ButtonBar.Release" );
        private TiButton OpenButton => Find<TiButton>( "CutJob.Detail.JobSolution.Open" );
        private TiButton DeleteButton => Find<TiButton>( "CutJob.Detail.JobSolution.Delete" );

        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );

        public TiValueControl<string> Machine => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.Machine" );
        public TiValueControl<string> TechnologyProfile => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.TechnologyProfile" );
        private TiButton TechnologyProfileFavoriteButton => Find<TiButton>( "CutJob.Detail.JobSolution.TechnologyProfileFavorite" );

        // raw sheets
        public TiRawSheetList RawSheets => new TcRawSheetList( this.FindGeneric( Search.ByControlName( "RawSheetListe" ) ) );
        private TiButton AddPresetRawSheetButton => Find<TiButton>( "CutJob.Detail.JobSolution.AddPresetRawSheet" );

        // nesting mode
        public TiValueControl<string> NestingMode => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.NestingMode" );

        // LTT/RW
        public TiValueControl<string> LaserTechnologyTable => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.LaserTechnologyTable" );
        public TiValueControl<string> LaserProcessRule => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.LaserProcessRule" );
        private TiButton SetLttRwFavoriteButton => Find<TiButton>( "CutJob.Detail.JobSolution.SetLaserTechnologyRuleSetCombinationFavorite" );

        public TiValueControl<string> Note => Find<TiValueControl<string>>( "CutJob.Detail.JobSolution.Comment" );

        public bool CanBoost => BoostButton.Enabled;
        public void Boost()
        {
            if( BoostButton.Enabled )
            {
                BoostButton.Click();
            }
        }

        public bool CanRelease => ReleaseButton.Enabled;
        public void Release()
        {
            if( ReleaseButton.Enabled )
            {
                ReleaseButton.Click();
            }
        }

        public bool CanOpen => OpenButton.Enabled;
        public void Open()
        {
            if( OpenButton.Enabled )
            {
                OpenButton.Click();
            }
        }

        public void DeleteSolution()
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

        public void SetTechnologyProfileFavorite()
        {
            if( TechnologyProfileFavoriteButton.Enabled )
            {
                TechnologyProfileFavoriteButton.Click();
            }
        }

        public TiRawSheet AddRawSheet()
        {
            AddPresetRawSheetButton.Click();

            return RawSheets.GetRawSheet( RawSheets.Count - 1 );
        }

        public void SetLttRwFavorite()
        {
            if( SetLttRwFavoriteButton.Enabled )
            {
                SetLttRwFavoriteButton.Click();
            }
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
