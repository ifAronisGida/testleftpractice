using System;
using System.Collections.Generic;
using System.Linq;
using SmartBear.TestLeft.TestObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.Waiting;
using Trumpf.PageObjects.WPF;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.PageObjects.Dialogs;
using TestLeft.TestLeftBase.PageObjects.Shell;
using TestLeft.TestLeftBase.Settings;
using TestLeft.TestLeftBase.Utilities;

namespace TestLeft.TestLeftBase.PageObjects.CutJob
{
    public class TcCutJobSolution : PageObject, IChildOf<TcDetailContent>
    {
        protected override Search SearchPattern => Search.ByUid( "CutJob.Detail.JobSolution" );

        #region Private controls
        private TcTruIconButton ReleaseButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Release" ) );
        private TcTruIconButton OpenButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Open" ) );
        private TcTruIconButton DeleteButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.Delete" ) );
        private TcComboBox MachineCombo => Find<TcComboBox>( Search.ByUid( "CutJob.Detail.JobSolution.Machine" ) );
        private TcLookUpEdit TechnoProfile => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "CutJob.Detail.JobSolution.TechnologyProfile" ) ));
        private TcTruIconButton AddPresetRawSheetButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.AddPresetRawSheet" ) );
        private TcLookUpEdit NestingModeEdit => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "CutJob.Detail.JobSolution.NestingMode" ) ));
        private TcLookUpEdit LaserTechnologyTableEdit => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "CutJob.Detail.JobSolution.LaserTechnologyTable" ) ));
        private TcLookUpEdit LaserProcessRule => TcControlMapper.Map<TcLookUpEdit>( this.FindGeneric( Search.ByUid( "CutJob.Detail.JobSolution.LaserProcessRule" ) ));
        public TiValueControl<string> Note => TcControlMapper.Map<TiValueControl<string>>( this.FindGeneric( Search.ByUid( "CutJob.Detail.JobSolution.Comment" ) ));
        private TcTruIconButton OpenSetupPlanButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenSetupPlan" ) );
        private TcTruIconButton OpenReleaseFolderButton => Find<TcTruIconButton>( Search.ByUid( "CutJob.Detail.JobSolution.OpenReleaseFolder" ) );
        private TcOverlay DetailOverlay => Find<TcOverlay>( Search.ByUid( "DetailContent.Overlay" ) );
        private TcTruIconButton BoostButton => Find<TcTruIconButton>( Search.ByUid( "Part.Detail.JobSolution.ButtonBar.Calculate" ) );
        #endregion

        public TcRawSheetList RawSheets => Find<TcRawSheetList>();

        public void DeleteProgram()
        {
            if( DeleteButton.Enabled )
            {
                DeleteButton.Click();

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

        public IReadOnlyCollection<string> GetAvailableMachines()
        {
            var displayMember = MachineCombo.Node.GetProperty<string>( "DisplayMember" );
            var items = MachineCombo.Node.GetProperty<IObject>( "ItemsSource" );

            return ( from item in items.AsEnumerable<IObject>()
                     select item.GetProperty<string>( displayMember ) )
                   .ToList();
        }

        public void SelectMachine( int index )
        {
            MachineCombo.ClickItem( index );
        }

        public void SelectMachine( string displayName )
        {
            MachineCombo.ClickItem( displayName );
        }

        public void ClearMachine()
        {
            MachineCombo.Clear();
        }

        public IReadOnlyCollection<string> GetAvailableTechnologyProfiles()
        {
            var displayMember = TechnoProfile.GetDisplayMember();

            return ( from item in TechnoProfile.GetItemsSource()
                     select item.GetProperty<string>( displayMember ) )
                    .ToList();
        }

        public void SelectTechnologyProfile( string name )
        {
            TechnoProfile.Text = name;
        }

        public void ClearTechnologyProfile()
        {
            TechnoProfile.Clear();
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
