﻿using Trumpf.Coparoo.Desktop.WPF;
using HomeZone.UiObjectInterfaces.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeZone.UiObjects.ControlObjects
{
    internal class TcButton : TcControl, TiButton
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TcButton"/> class.
        /// </summary>
        /// <param name="controlObject">The control object.</param>
        public TcButton( IControlObject controlObject ) : base( controlObject )
        {
        }

        /// <summary>
        /// Gets the label of the button.
        /// </summary>
        /// <value>
        /// The label of the button.
        /// </value>
        public string Label
        {
            get
            {
                var label = ControlObject.Node.GetWpfControlText();

                if( string.IsNullOrEmpty( label ) )
                {
                    // if the button is a link, extract the text from the contained TextBlock
                    label = ControlObject.Node.GetProperty<string>( "Content.WPFControlText" );
                }

                return label;
            }
        }

        /// <summary>
        /// Checks if the button is enabled and clicks the button.
        /// </summary>
        public void Click()
        {
            ShouldBeEnabled();
            ControlObject.Click();
        }

        /// <summary>
        /// Asserts that the button is enabled.
        /// </summary>
        public void ShouldBeEnabled()
        {
            Assert.IsTrue( ControlObject.Enabled, $"Button {ControlObject.Node.GetProperty<string>( "Uid" )} is not enabled" );
        }

        /// <summary>
        /// Asserts that the button is disabled.
        /// </summary>
        public void ShouldBeDisabled()
        {
            Assert.IsFalse( ControlObject.Enabled, $"Button {ControlObject.Node.GetProperty<string>( "Uid" )} is not disabled" );
        }
    }
}
