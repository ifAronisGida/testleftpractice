using TestLeft.TestLeftBase.ControlObjects.Interfaces;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
{
    public class TcWelcomeScreen : PageObject, IChildOf<TcMainTabControl>
    {
        protected override Search SearchPattern => Search.ByUid( "WelcomeScreen" );

        internal TiValueControl<bool> ShowWelcomeScreenCheckBox => TcControlMapper.Map<TiValueControl<bool>>( this.FindGeneric( Search.ByUid( "ShowWelcomeScreen" ), depth: 3 ) );

        public bool ShowWelcomeScreen
        {
            get => ShowWelcomeScreenCheckBox.Value;
            set => ShowWelcomeScreenCheckBox.Value = value;
        }
    }
}
