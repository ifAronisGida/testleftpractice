using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.Customer
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
        [Tag( "Customer" )]
        public void NewCustomersAndDeleteTest()
        {
            Act( () =>
            {
                Trace.WriteLine( $"Starting {nameof( NewCustomersAndDeleteTest )}" );
                Trace.Indent();
                var name1 = TestSettings.NamePrefix + Guid.NewGuid();
                var name2 = TestSettings.NamePrefix + Guid.NewGuid();

                var customers = HomeZone.GotoCustomers();
                var customersCount = customers.Count();
                if( string.IsNullOrEmpty( customers.Name.Value ) )
                {
                    customersCount--;       // do not count empty entry
                }

                Trace.WriteLine( $"Customers count is {customersCount} when starting" );

                Trace.WriteLine( $"Creating first customer: {name1}" );
                customers.NewCustomer(
                                      name1,
                                      "C" + Guid.NewGuid(),
                                      "TRUMPF Allee 1",
                                      "71254",
                                      "Ditzingen",
                                      "Deutschland",
                                      "kein Kommentar" );

                Trace.WriteLine( $"Creating second customer: {name2}" );
                customers.NewCustomer(
                                      name2,
                                      null,
                                      "TRUMPF Allee 2",
                                      "71254",
                                      "Ditzingen",
                                      "Deutschland",
                                      "hier auch nicht" );

                customers.Apply();
                customers.Cancel();

                Trace.Unindent();
                Trace.WriteLine( "Customer dialog closed." );

                customers.Goto();
                Assert.AreEqual( customersCount + 2, customers.Count() );

                var amount = customers.DeleteCustomersWithNameContaining( name1 );
                amount += customers.DeleteCustomersWithNameContaining( name2 );
                if( amount > 0 )
                {
                    customers.Apply();
                }

                Assert.AreEqual( customersCount, customers.Count() );

                customers.Cancel();
            } );
        }
    }
}
