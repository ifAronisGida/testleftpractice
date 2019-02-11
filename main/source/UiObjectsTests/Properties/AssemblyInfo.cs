using System.Reflection;
using System.Runtime.InteropServices;
using Trumpf.TruTops.UnitTestAttribute;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle( "UI_Tests" )]
[assembly: AssemblyDescription( "" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "" )]
[assembly: AssemblyProduct( "UI_Tests" )]
[assembly: AssemblyCopyright( "Copyright ©  2018" )]
[assembly: AssemblyTrademark( "" )]
[assembly: AssemblyCulture( "" )]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid( "8bf76eb4-cc36-49ea-931c-c6c3f1689ebb" )]

// This is a TRUMPF custom attribute to identify the unit test type.
// Custom attribute is used here to distinguish between integration test and normal unit test.
// Usage: attribute is used to identify the test type on assembly level.
// - integration test
//   or
// - normal unit test
[assembly: TcUnitTest( Description = "", TestType = TcUnitTestAttribute.TeTestType.INTEGRATION_TEST_UI )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion( "1.0.0.0" )]
[assembly: AssemblyFileVersion( "1.0.0.0" )]
