using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    public class TcWelcomeScreen : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "WelcomeScreen" );

        internal TcCheckBox ShowWelcomeScreenCheckBox => Find<TcCheckBox>( Search.ByUid( "ShowWelcomeScreen" ), depth: 3 );

        public bool ShowWelcomeScreen
        {
            get => ShowWelcomeScreenCheckBox.Checked;
            set => ShowWelcomeScreenCheckBox.Checked = value;
        }
    }
}
