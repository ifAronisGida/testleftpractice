using PageObjectInterfaces.Controls;
using PageObjectInterfaces.Shell;
using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects.Shell
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
