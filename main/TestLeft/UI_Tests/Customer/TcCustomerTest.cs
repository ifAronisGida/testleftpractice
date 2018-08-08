﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLeft.TestLeftBase.PageObjects.Customer;
using TestLeft.TestLeftBase.Settings;
using TestLeft.UI_Tests.Base;
using Trumpf.AutoTest.Facts;

namespace TestLeft.UI_Tests.Customer
{
    /// <summary>
    /// This test class contains customer specific tests.
    /// </summary>
    /// <seealso cref="TcBaseTestClass" />
    [TestClass]
    public class TcCustomerTest : TcBaseTestClass
    {
        /// <summary>
        /// Creates new customers, saves and then deletes them.
        /// </summary>
        [TestMethod, UniqueName( "D54BAF5F-F41B-4CEF-9F6B-6907D642507E" )]
        public void NewCustomersAndDeleteTest()
        {
            Act( () =>
            {
                var name1 = TcSettings.NamePrefix + Guid.NewGuid();
                var name2 = TcSettings.NamePrefix + Guid.NewGuid();

                var customers = HomeZoneApp.Goto<TcCustomers>();

                var customersCount = customers.Count();

                customers.NewCustomer(
                                      name1,
                                      "C" + Guid.NewGuid(),
                                      "TRUMPF Allee 1",
                                      "71254",
                                      "Ditzingen",
                                      "Deutschland",
                                      "kein Kommentar" );

                customers.NewCustomer(
                                      name2,
                                      null,
                                      "TRUMPF Allee 2",
                                      "71254",
                                      "Ditzingen",
                                      "Deutschland",
                                      "hier auch nicht" );

                customers.ApplyClick();
                customers.CancelClick();

                customers.Goto();
                Assert.AreEqual( customersCount + 2, customers.Count() );

                customers.DeleteCustomersWithNameContaining( name1 );
                customers.DeleteCustomersWithNameContaining( name2 );
                customers.ApplyClick();
                Assert.AreEqual( customersCount, customers.Count() );

                customers.CancelClick();
            } );
        }
    }
}
