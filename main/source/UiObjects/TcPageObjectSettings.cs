﻿using System;

namespace HomeZone.UiObjects
{
    /// <summary>
    /// Contains default timeout values for certain wait operations.
    /// </summary>
    public class TcPageObjectSettings
    {
        private TcPageObjectSettings()
        {
        }

        public static TcPageObjectSettings Instance { get; } = new TcPageObjectSettings();

        public TimeSpan MachineFirstImportTimeout { get; set; } = TimeSpan.FromSeconds( 120 );

        public TimeSpan MaterialOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 20 );

        public TimeSpan MaterialOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan CutJobOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 20 );

        public TimeSpan CutJobOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan MachineOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 20 );

        public TimeSpan MachineOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        public TimeSpan PartOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 10 );

        public TimeSpan PartOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 120 );

        public TimeSpan TabOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 120 );

        public TimeSpan NestingTemplateOverlayAppearTimeout { get; set; } = TimeSpan.FromSeconds( 10 );

        public TimeSpan NestingTemplateOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        /// <summary>
        /// Get the timeout for selecting all parts until one can use the selection
        /// </summary>
        /// <value>
        /// The part select all timeout.
        /// </value>
        public TimeSpan PartSelectAllTimeout => TimeSpan.FromSeconds( 10 );

        public TimeSpan ExportOverlayDisappearTimeout { get; set; } = TimeSpan.FromSeconds( 60 );

        /// <summary>
        /// Timeout for Dropwdowns, Message Boxes
        /// </summary>
        public TimeSpan FluxUITimeouts { get; set; } = TimeSpan.FromSeconds( 60 );
    }
}
