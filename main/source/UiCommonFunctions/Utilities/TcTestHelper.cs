using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Reflection;

namespace HomeZone.UiCommonFunctions.Utilities
{
    /// <summary>
    /// This class provides convenient functionalities that shall be used in tests.
    /// </summary>
    public class TcTestHelper
    {
        /// <summary>
        /// Waits until a condition is fulfilled, but not longer than the default timeout.
        /// The condition is periodically checked in a short time-intervall.
        /// </summary>
        /// <param name="condition">The function delegate that is used to check the condition.</param>
        /// <param name="maxTimeoutInMilliseconds">The maximum time until the method returns (regardless of the condition).</param>
        /// <returns>Returns if the condition was fulfilled.</returns>
        public static bool WaitUntilConditionFulfilledOrTimeout( Func<bool> condition, int maxTimeoutInMilliseconds = 20000 )
        {
            bool conditionFuncResult = condition();

            DateTime endTime = DateTime.Now.Add( TimeSpan.FromMilliseconds( maxTimeoutInMilliseconds ) );

            while( !conditionFuncResult && DateTime.Now < endTime )
            {
                System.Threading.Thread.Sleep( 250 );
                conditionFuncResult = condition();
            }

            return conditionFuncResult;
        }

        #region Get description-attribute value of a test method

        /// <summary>
        /// Gets the content of the "DescriptionAttribute" defined on a test method (a method that has the "TestMethodAttribute" set).
        /// Both conditions need to be fulfilled, otherwiese is a default text returnd.
        /// </summary>
        /// <returns>The content of the description attribute or a default text.</returns>
        public static string GetTestMethodDescription()
        {
            var testMethodDescription = "No description-attribute available on test method.";

            var testMethod = GetTestMethod();
            if( testMethod != null )
            {
                var descriptionAttribute = testMethod.GetCustomAttribute( typeof( DescriptionAttribute ) ) as DescriptionAttribute;

                if( descriptionAttribute != null )
                {
                    testMethodDescription = descriptionAttribute.Description;
                }
            }

            return testMethodDescription;
        }

        private static MethodBase GetTestMethod()
        {
            MethodBase currentMethod = MethodInfo.GetCurrentMethod();
            int currentStackDepth = 0;

            while( currentMethod != null && !HasTestAttribute( currentMethod ) )
            {
                var stackFrame = new StackTrace().GetFrame( currentStackDepth++ );
                if( stackFrame != null )
                {
                    currentMethod = stackFrame.GetMethod();
                }
                else
                {
                    currentMethod = null;
                }
            }

            return currentMethod;
        }

        private static bool HasTestAttribute( MethodBase currentMethod )
        {
            return currentMethod.GetCustomAttribute( typeof( TestMethodAttribute ) ) != null;
        }

        #endregion
    }
}