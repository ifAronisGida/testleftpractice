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
            ["System.Windows.Controls.TextBox"] = controlObject => new TcTextEdit(controlObject),
            ["DevExpress.Xpf.Editors.TextEdit"] = controlObject => new TcTextEdit(controlObject),
            ["DevExpress.Xpf.Grid.LookUp.LookUpEdit"] = controlObject => new TcLookUpEdit(controlObject),
            ["DevExpress.Xpf.Editors.SpinEdit"] = controlObject => new TcSpinEdit(controlObject),
            ["System.Windows.Controls.ComboBox"] = controlObject => new TcComboBox(),
            ["Trumpf.TruTops.Control.Infrastructure.ModuleBase.Controls.TcLookUpEdit"] = controlObject => new TcLookUpEdit(controlObject)
        };

        public static TInterface Map<TInterface>( IControlObject controlObject ) where TInterface : class
        {
            var fqClassName = controlObject.Node.GetClrFullClassName();

            try
            {
                var factoryFunc = mappings[ fqClassName ];
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
