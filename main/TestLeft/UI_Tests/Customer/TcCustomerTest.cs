using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;

namespace TestLeft.UI_Tests.Customer
{
    /// <summary>
    /// This test class contains customer specific tests.
    /// These test methods are mainly used for module and PageObject tests.
    /// It is not secured that the methods are cleaning up at the end.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcCustomerTest : TcBaseTestClass
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
        /// Creates 2 new customers:
        /// TcSettings.NamePrefix + "Kunde 1"
        /// TcSettings.NamePrefix + "Kunde 2"
        /// </summary>
        [TestMethod]
        public void NewCustomerTest()
        {
            var customers = HomeZoneApp.On<TcCustomers>();

            customers.NewCustomer(
                                  TcSettings.NamePrefix + "Kunde 1",
                                  "C" + Guid.NewGuid(),
                                  "TRUMPF Allee 1",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "kein Kommentar" );

            customers.NewCustomer(
                                  TcSettings.NamePrefix + "Kunde 2",
                                  null,
                                  "TRUMPF Allee 2",
                                  "71254",
                                  "Ditzingen",
                                  "Deutschland",
                                  "hier auch nicht" );

            customers.ApplyClick();
            customers.CancelClick();
        }

        /// <summary>
        /// Deletes a specific customer (TcSettings.NamePrefix + "Kunde 2").
        /// </summary>
        [TestMethod]
        public void DeleteCustomerTest()
        {
            var customers = HomeZoneApp.On<TcCustomers>();
            customers.Goto();

            customers.DeleteCustomersWithNameContaining( TcSettings.NamePrefix + "Kunde 2" );
        }
    }
}
