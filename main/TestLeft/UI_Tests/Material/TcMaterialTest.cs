using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Material
{
    /// <summary>
    /// This test class contains material specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcMaterialTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates a new material, saves it and waits until the overlay disappears.
        /// </summary>
        [TestMethod, UniqueName( "398087D2-364F-41E3-B6B1-209112BCDEA9" )]
        public void NewMaterialAndDeleteTest()
        {
            Act( () =>
                {
                    var materials = HomeZoneApp.GotoMaterials();

                    materials.NewMaterial();

                    var guid = Convert.ToBase64String( Guid.NewGuid().ToByteArray() ).Substring( 0, 22 );
                    var name = TcSettings.NamePrefix + guid;
                    materials.Detail.Id.Value = name;
                    materials.Detail.Name.Value = name;
                    materials.Detail.EModulus.Value = @"210000";
                    materials.Detail.SpecificWeight.Value = @"7,42";
                    materials.Detail.TensileStrengthMax.Value = @"542";
                    materials.Detail.TensileStrength.Value = @"442";
                    materials.Detail.TensileStrengthMin.Value = @"342";

                    Assert.IsTrue( materials.Toolbar.SaveButton.Enabled );
                    materials.SaveMaterial();

                    materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
                    materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );

                    Assert.IsFalse( materials.Toolbar.SaveButton.Enabled );

                    Assert.IsTrue( materials.Toolbar.DeleteButton.Enabled );
                    materials.DeleteMaterial();
                    Assert.IsFalse( materials.Toolbar.DeleteButton.Enabled );
                } );
        }

        /// <summary>
        /// Duplicates material 1.0038, renames and saves it, waits until the overlay disappears and deletes the new material.
        /// </summary>
        [TestMethod, UniqueName( "6AD0682A-60D0-4A4D-9C29-4724701B431B" )]
        public void DuplicateMaterialAndDeleteTest()
        {
            Act( () =>
            {
                var materials = HomeZoneApp.GotoMaterials();

                materials.Goto();

                materials.SelectMaterial( "1.0038" );

                materials.DuplicateMaterial();

                var name = TcSettings.NamePrefix + materials.Detail.Id;
                materials.Detail.Id.Value = name;
                materials.Detail.Name.Value = name;

                Assert.IsTrue( materials.Toolbar.SaveButton.Enabled );
                materials.SaveMaterial();

                materials.WaitForDetailOverlayAppear( TcSettings.MaterialOverlayAppearTimeout );
                materials.WaitForDetailOverlayDisappear( TcSettings.MaterialOverlayDisappearTimeout );

                Assert.IsFalse( materials.Toolbar.SaveButton.Enabled );

                Assert.IsTrue( materials.Toolbar.DeleteButton.Enabled );
                materials.DeleteMaterial();
                Assert.IsFalse( materials.Toolbar.DeleteButton.Enabled );
            } );
        }
    }
}
