using System;
using System.Collections.Generic;
using TestLeft.TestLeftBase.ControlObjects;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.Utilities
{
    internal static class TcControlMapper
    {
        private static readonly Dictionary<string, Func<IControlObject, object>> mappings = new Dictionary<string, Func<IControlObject, object>>
        {
            ["DevExpress.Xpf.Editors.SpinEdit"] = controlObject => new TcSpinEdit( controlObject ),
            ["DevExpress.Xpf.Editors.TextEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["DevExpress.Xpf.Grid.LookUp.LookUpEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["System.Windows.Controls.Button"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.CheckBox"] = controlObject => new TcCheckBox( controlObject ),
            ["System.Windows.Controls.Menu"] = controlObject => new TcButton( controlObject ),
            ["System.Windows.Controls.TextBox"] = controlObject => new TcTextEdit( controlObject ),
            ["Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcTruComboBox"] = controlObject => new TcTruComboBox( controlObject ),
            ["Trumpf.TruTops.Common.Infrastructure.TruCustomControls.TcTruIconButton"] = controlObject => new TcButton( controlObject ),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcLookUpEdit"] = controlObject => new TcTextEdit( controlObject ),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcNullableTextEdit"] = controlObject => new TcTextEdit( controlObject ),
        };

        public static TInterface Map<TInterface>( IControlObject controlObject ) where TInterface : class
        {
            var fqClassName = controlObject.Node.GetClrFullClassName();

            try
            {
                var factoryFunc = mappings[fqClassName];
                return ( TInterface )factoryFunc( controlObject );
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
                Console.WriteLine( fqClassName + " not found" );
                throw;
            }
        }
    }
}
