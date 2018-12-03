using System.Collections.Generic;

namespace HomeZone.UiObjects
{
    public enum TeAppLanguage
    {
        English
    }

    public enum TeStringKey
    {
        Missing,
        CuttingProgram
    }

    public static class TcAppLangDependentStrings
    {
        private static IReadOnlyDictionary<TeStringKey, Label> labels = new Dictionary<TeStringKey, Label>()
        {
            [TeStringKey.Missing] = new Label( "Missing" ),
            [TeStringKey.CuttingProgram] = new Label( "Cutting Program" )
        };

        public static TeAppLanguage CurrentLanguage { get; set; } = TeAppLanguage.English;

        public static string Get( TeStringKey key )
        {
            var label = labels[key];

            switch( CurrentLanguage )
            {
                case TeAppLanguage.English:
                    return label.English ?? throw new System.Exception( "Label not set for this language." );
                default:
                    throw new System.Exception( "Unsupported language" );
            }
        }

        private class Label
        {
            public Label( string english )
            {
                English = english;
            }

            public string English { get; }
        }
    }
}
