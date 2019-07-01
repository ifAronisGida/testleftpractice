using HomeZone.UiObjects.ControlObjects;
using System;
using System.Collections.Generic;
using Trumpf.Coparoo.Desktop.WPF;

namespace HomeZone.UiObjects.Utilities
{
    internal static class TcControlMapper
    {
        private static readonly Dictionary<string, Func<IControlObject, object>> mappings = new Dictionary<string, Func<IControlObject, object>>
        {
            ["DevExpress.Xpf.Core.DXTabItem"] = controlObject => new TcButton( controlObject ),
            ["DevExpress.Xpf.Editors.CheckEdit"] = controlObject => new TcCheckBox( controlObject ),
            ["DevExpress.Xpf.Editors.ComboBoxEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["DevExpress.Xpf.Editors.SpinEdit"] = controlObject => new TcSpinEdit( controlObject ),
            ["DevExpress.Xpf.Editors.TextEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["DevExpress.Xpf.Editors.DateEdit"] = controlObject => new TcDateEdit( controlObject ),
            ["DevExpress.Xpf.Grid.LookUp.LookUpEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["System.Windows.Controls.Button"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.CheckBox"] = controlObject => new TcCheckBox( controlObject ),
            ["System.Windows.Controls.Menu"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.MenuItem"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.TextBox"] = controlObject => new TcTextEdit( controlObject ),
            ["System.Windows.Controls.Image"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.Border"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.ComboBox"] = controlObject => new TcComboBox( controlObject ),
            ["System.Windows.Controls.TextBlock"] = controlObject => new TcTextBlock( controlObject ),
            ["Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcTruComboBox"] = controlObject => new TcTruComboBox( controlObject ),
            ["Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcTruIconButton"] = controlObject => new TcButton( controlObject ),
            ["Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcTruTextBlock"] = controlObject => new TcTextBlock( controlObject ),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcLookUpEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcNullableDateEdit"] = controlObject => new TcDateEdit( controlObject ),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcNullableTextEdit"] = controlObject => new TcTextEdit( controlObject ),
        };

        public static TInterface Map<TInterface>( IControlObject controlObject ) where TInterface : class
        {
            var fqClassName = controlObject.Node.GetClrFullClassName();

            if( mappings.TryGetValue( fqClassName, out var factoryFunc ) )
            {
                return ( TInterface )factoryFunc( controlObject );
            }
            else
            {
                return ( TInterface )( object )new TcUnmappedControl( controlObject );
            }
        }
    }
}
