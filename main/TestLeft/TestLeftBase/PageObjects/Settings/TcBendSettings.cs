using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Settings
{
    public class TcBendSettings : PageObject, IChildOf<TcSettings>
    {
        protected override Search SearchPattern => Search.ByUid( "Settings.Bend" );

        private TcTruIconButton ToolsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.Tools.Open" ) );
        private TcTruIconButton ToolListsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.ToolLists.Open" ) );
        private TcTruIconButton BendDeductionOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.BendDeduction.Open" ) );
        private TcTruIconButton AppSettingsOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.AppSettings.Open" ) );
        private TcTruIconButton DataManagerBendOpenButton => Find<TcTruIconButton>( Search.ByUid( "Settings.Bend.DataManagerBend.Open" ) );

        public override void Goto()
        {
            if( !IsVisibleOnScreen )
            {
                Parent.Goto();
                ( ( TcSettings )Parent ).BendTab.Click();
            }
        }

        public void OpenDataManagerBend()
        {
            DataManagerBendOpenButton.Click();
        }
    }
}
