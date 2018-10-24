using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trumpf.AutoTest.Facts;
using UiTests.Base;
using UiTests.Utilities;


namespace UiTests.NestingTemplate
{
    [TestClass]
    public class TcNestingTemplateTest : TcBaseTestClass
    {
        [TestMethod, UniqueName( "EA507C38-9763-4156-AE10-C5CF8E202BD2" )]
        public void ImportTest()
        {
            Act( () =>
            {
                var nestingTemplates = HomeZone.GotoNestingTemplates();

                nestingTemplates.Toolbar.Import( @"C:\junk\N2_1.tmt" );
                nestingTemplates.WaitForOverlayDisappear( TimeSpan.FromMinutes( 1 ) );

                nestingTemplates.BaseInfo.Name.Value = "NestingTemplate2";
                nestingTemplates.BaseInfo.RawMaterial.Value = "NestingTemplate2";
                nestingTemplates.BaseInfo.ID.Value = "NestingTemplate2";
            } );
        }
    }
}