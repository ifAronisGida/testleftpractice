using System;
using PageObjectInterfaces.Controls;

namespace PageObjectInterfaces.CutJob
{
    public interface TiCutJobSheetProgram
    {
        TiValueControl<string> Note { get; }
        TiRawSheetList RawSheets { get; }

        TiRawSheet AddRawSheet();
        void Boost();
        void DeleteProgram();
        bool WaitForDetailOverlayAppear( TimeSpan timeout );
        bool WaitForDetailOverlayDisappear( TimeSpan timeout );
    }
}
