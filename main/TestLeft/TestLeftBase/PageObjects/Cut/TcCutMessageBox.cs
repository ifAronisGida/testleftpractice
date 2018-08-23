using System;
using SmartBear.TestLeft.TestObjects;
using SmartBear.TestLeft.TestObjects.UIAutomation;
using Trumpf.PageObjects;
using Trumpf.PageObjects.UIA;

namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    public class TcCutMessageBox : PageObject, IChildOf<TcCutApp>
    {
        protected override Search SearchPattern => Search.ByClassname( "TcMessageBox" );

        private readonly Lazy<IControl> mframeButtons;

        public TcCutMessageBox()
        {
            mframeButtons = new Lazy<IControl>( () => Node.Find<IControl>( new UIAPattern()
            {
                FrameworkId = "Qt",
                ClassName = "QWidget",
                ObjectIdentifier = "qt_ribbonMainWindow_TcMessageBox_container"
            } ).Find<IControl>( new UIAPattern()
            {
                FrameworkId = "Qt",
                ClassName = "QWidget",
                ObjectIdentifier = "qt_ribbonMainWindow_TcMessageBox_container_frame"
            } ).Find<IControl>( new UIAPattern()
            {
                FrameworkId = "Qt",
                ClassName = "QWidget",
                ObjectIdentifier = "qt_ribbonMainWindow_TcMessageBox_container_frame_content"
            } ).Find<IControl>( new UIAPattern()
            {
                FrameworkId = "Qt",
                ClassName = "QFrame",
                ObjectIdentifier = "qt_ribbonMainWindow_TcMessageBox_container_frame_content_frameButtons"
            } ) );
        }

        internal IControl YesButton => mframeButtons.Value.Find<IControl>( new UIAPattern()
        {
            FrameworkId = "Qt",
            ClassName = "QPushButton",
            ObjectIdentifier = "Ja"
        } );

        /// <summary>
        /// Closes the message box.
        /// </summary>
        public void Close()
        {
            Node.CallMethod( "Close" );
        }
    }
}
