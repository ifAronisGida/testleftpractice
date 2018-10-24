using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;
using UiObjectInterfaces.Controls;
using UiObjectInterfaces.Shell;
using UiObjects.Utilities;


namespace UiObjects.PageObjects.Shell
{
    public class TcWelcomeScreen : TcPageObjectBase, IChildOf<TcMainTabControl>, TiWelcomeScreen
    {
        protected override Search SearchPattern => Search.ByUid( "WelcomeScreen" );

        internal TiValueControl<bool> ShowWelcomeScreenCheckBox => this.FindMapped<TiValueControl<bool>>( "ShowWelcomeScreen", depth: 3 );

        public bool ShowWelcomeScreen
        {
            get => ShowWelcomeScreenCheckBox.Value;
            set => ShowWelcomeScreenCheckBox.Value = value;
        }
    }
}
