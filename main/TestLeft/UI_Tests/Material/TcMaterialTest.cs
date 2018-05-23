using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Material;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;

namespace TestLeft.UI_Tests.Material
{
    /// <summary>
    /// This test class contains material specific tests.
    /// These test methods are mainly used for module and PageObject tests.
    /// It is not secured that the methods are cleaning up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcMaterialTest : TcBaseTestClass
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize( TestContext context )
        {
            InitializeClass( context );
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            FinalizeClass();
        }
        #endregion

        /// <summary>
        /// Creates a new material, saves it and waits until the overlay disappears.
        /// </summary>
        [TestMethod]
        public void NewMaterialTest()
        {
            var materials = HomeZoneApp.On<TcMaterials>();

            materials.Goto();

            materials.NewMaterial();

            var guid = Convert.ToBase64String( Guid.NewGuid().ToByteArray() ).Substring( 0, 22 );
            var name = TcSettings.NamePrefix + guid;
            materials.Detail.Id = name;
            materials.Detail.Name = name;
            materials.Detail.EModulus = @"210000";
            materials.Detail.SpecificWeight = @"7,42";
            materials.Detail.TensileStrengthMax = @"542";
            materials.Detail.TensileStrength = @"442";
            materials.Detail.TensileStrengthMin = @"342";

            materials.SaveMaterial();
            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );
        }

        /// <summary>
        /// Creates a new material and deletes it.
        /// </summary>
        [TestMethod]
        public void DeleteMaterialTest()
        {
            var materials = HomeZoneApp.On<TcMaterials>();

            materials.Goto();

            materials.NewMaterial();

            materials.DeleteMaterial();
        }

        /// <summary>
        /// Duplicates material 1.0038, renames and saves it, waits until the overlay disappears and deletes the new material.
        /// </summary>
        [TestMethod]
        public void DuplicateMaterialTest()
        {
            var materials = HomeZoneApp.On<TcMaterials>();

            materials.Goto();

            materials.SelectMaterial( "1.0038" );

            materials.DuplicateMaterial();

            var name = TcSettings.NamePrefix + materials.Detail.Id;
            materials.Detail.Id = name;
            materials.Detail.Name = name;

            materials.SaveMaterial();
            materials.WaitForDetailOverlayAppear( TcSettings.MaterialSaveOverlayAppearTimeout );
            materials.WaitForDetailOverlayDisappear( TcSettings.MaterialSaveOverlayDisappearTimeout );

            materials.DeleteMaterial();
        }
    }
}
