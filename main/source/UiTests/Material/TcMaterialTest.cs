using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiTests.Base;
using UiTests.Utilities;


namespace UiTests.Material
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
                    var materials = HomeZone.GotoMaterials();

                    materials.Toolbar.New();

                    var guid = Convert.ToBase64String( Guid.NewGuid().ToByteArray() ).Substring( 0, 22 );
                    var name = TestSettings.NamePrefix + guid;
                    materials.Detail.Id.Value = name;
                    materials.Detail.Name.Value = name;
                    materials.Detail.EModulus.Value = @"210000";
                    materials.Detail.SpecificWeight.Value = @"7,42";
                    materials.Detail.TensileStrengthMax.Value = @"542";
                    materials.Detail.TensileStrength.Value = @"442";
                    materials.Detail.TensileStrengthMin.Value = @"342";

                    Assert.IsTrue( materials.Toolbar.CanSave );
                    materials.Toolbar.Save();

                    materials.WaitForDetailOverlayAppear( TestSettings.MaterialOverlayAppearTimeout );
                    materials.WaitForDetailOverlayDisappear( TestSettings.MaterialOverlayDisappearTimeout );

                    Assert.IsFalse( materials.Toolbar.CanSave );

                    Assert.IsTrue( materials.Toolbar.CanDelete );
                    materials.Toolbar.Delete();
                    Assert.IsFalse( materials.Toolbar.CanDelete );
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
                var materials = HomeZone.GotoMaterials();

                materials.Goto();

                materials.ResultColumn.SelectItem( "1.0038" );

                materials.Toolbar.Duplicate();

                var name = TestSettings.NamePrefix + materials.Detail.Id;
                materials.Detail.Id.Value = name;
                materials.Detail.Name.Value = name;

                Assert.IsTrue( materials.Toolbar.CanSave );
                materials.Toolbar.Save();

                materials.WaitForDetailOverlayAppear( TestSettings.MaterialOverlayAppearTimeout );
                materials.WaitForDetailOverlayDisappear( TestSettings.MaterialOverlayDisappearTimeout );

                Assert.IsFalse( materials.Toolbar.CanSave );

                Assert.IsTrue( materials.Toolbar.CanDelete );
                materials.Toolbar.Delete();
                Assert.IsFalse( materials.Toolbar.CanDelete );
            } );
        }
    }
}
