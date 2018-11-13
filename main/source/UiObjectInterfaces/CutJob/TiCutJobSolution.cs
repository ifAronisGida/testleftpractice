using System;
using HomeZone.UiObjectInterfaces.Controls;

namespace HomeZone.UiObjectInterfaces.CutJob
{
    public interface TiCutJobSolution
    {
        bool CanBoost { get; }
        void Boost();
        void DeleteSolution();

        TiValueControl<string> Machine { get; }
        TiValueControl<string> TechnologyProfile { get; }
        void SetTechnologyProfileFavorite();

        TiRawSheetList RawSheets { get; }
        TiRawSheet AddRawSheet();

        TiValueControl<string> NestingMode { get; }

        TiValueControl<string> LaserTechnologyTable { get; }
        TiValueControl<string> LaserProcessRule { get; }
        void SetLttRwFavorite();
        
        TiValueControl<string> Note { get; }

        bool WaitForDetailOverlayAppear( TimeSpan timeout );
        bool WaitForDetailOverlayDisappear( TimeSpan timeout );
    }
}
