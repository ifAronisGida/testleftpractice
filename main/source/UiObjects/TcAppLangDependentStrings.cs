using System.Collections.Generic;

namespace HomeZone.UiObjects
{
    public enum TeAppLanguage
    {
        English, German, Hungarian
    }

    public enum TeStringKey
    {
        Missing,
        Incomplete,
        CuttingProgram,
        TechnologyTableSelection,
        ReleaseMissing
    }

    public static class TcAppLangDependentStrings
    {
        private static readonly IReadOnlyDictionary<TeStringKey, Label> labels = new Dictionary<TeStringKey, Label>()
        {
            [TeStringKey.Missing] = new Label( "Missing", "Fehlt", null ),
            [TeStringKey.Incomplete] = new Label( "Incomplete", "Unvollständig", null ),
            [TeStringKey.CuttingProgram] = new Label( "Cutting Program", "Schneidprogramm", null ),
            [TeStringKey.TechnologyTableSelection] = new Label( "Technology table selection", "Technologietabellen Auswahl", "Technológiatáblázatok kiválasztása" ),
            [TeStringKey.ReleaseMissing] = new Label( "Release missing", "Freigabe fehlt", null )
        };

        public static TeAppLanguage CurrentLanguage { get; set; } = TeAppLanguage.German;

        public static string Get( TeStringKey key )
        {
            var label = labels[ key ];

            switch( CurrentLanguage )
            {
                case TeAppLanguage.English:
                    return label.English ?? throw new System.Exception( "Label not set for this language." );
                case TeAppLanguage.German:
                    return label.German ?? throw new System.Exception( "Label not set for this language." );
                case TeAppLanguage.Hungarian:
                    return label.Hungarian ?? throw new System.Exception( "Label not set for this language." );
                default:
                    throw new System.Exception( "Unsupported language" );
            }
        }

        private class Label
        {
            public Label( string english, string german, string hungarian )
            {
                English = english;
                German = german;
                Hungarian = hungarian;
            }

            public string English { get; }

            public string German { get; }

            public string Hungarian { get; }
        }
    }
}
