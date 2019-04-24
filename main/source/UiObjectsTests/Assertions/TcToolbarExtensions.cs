using HomeZone.UiObjectInterfaces.Common;
using HomeZone.UiObjectInterfaces.Part;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeZone.UiObjectTests.Assertions
{
    internal static class TcToolBarExtensions
    {
        public static void SaveShouldBeEnabled(this TiToolbar toolbar)
        {
            Assert.IsTrue( toolbar.CanSave, "Save is not enabled." );
        }

        public static void SaveShouldBeDisabled( this TiToolbar toolbar )
        {
            Assert.IsFalse( toolbar.CanSave, "Save is not disabled." );
        }

        public static void DeleteShouldBeEnabled( this TiToolbar toolbar )
        {
            Assert.IsTrue( toolbar.CanDelete, "Delete is not enabled." );
        }

        public static void DeleteShouldBeDisabled( this TiToolbar toolbar )
        {
            Assert.IsFalse( toolbar.CanDelete, "Delete is not disabled." );
        }

        public static void RevertShouldBeEnabled( this TiToolbar toolbar )
        {
            Assert.IsTrue( toolbar.CanRevert, "Revert is not enabled." );
        }

        public static void RevertShouldBeDisabled( this TiToolbar toolbar )
        {
            Assert.IsFalse( toolbar.CanRevert, "Revert is not disabled." );
        }

        public static void BoostShouldBeEnabled(this TiPartToolbar toolbar)
        {
            Assert.IsTrue( toolbar.CanBoost, "Boost is not enabled." );
        }

        public static void BoostShouldBeDisabled( this TiPartToolbar toolbar )
        {
            Assert.IsFalse( toolbar.CanBoost, "Boost is not disabled." );
        }
    }
}
