using HomeZone.UiCommonFunctions.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trumpf.AutoTest.Facts;
using UiCommonFunctions.Utilities;

namespace HomeZone.UiObjectsTests.NestingTemplate
{
    [TestClass]
    public class TcNestingTemplateTest : TcBaseTestClass
    {
        [TestMethod, UniqueName( "EA507C38-9763-4156-AE10-C5CF8E202BD2" )]
        [Tag( "NestingTemplate" )]
        public void ImportTest()
        {
            Act( () =>
            {
                var nestingTemplates = HomeZone.GotoNestingTemplates();

                nestingTemplates.Toolbar.Import( @"C:\junk\N2_1.tmt" );
                nestingTemplates.WaitForDetailOverlayDisappear( TimeSpan.FromMinutes( 1 ) );

                nestingTemplates.BaseInfo.Name.Value = "NestingTemplate2";
                nestingTemplates.BaseInfo.RawMaterial.Value = "NestingTemplate2";
                nestingTemplates.BaseInfo.ID.Value = "NestingTemplate2";
            } );
        }

        [TestMethod]
        public void CreateJobFromTemplate()
        {
            var nestingTemplates = HomeZone.GotoNestingTemplates();

            nestingTemplates.ResultColumn.SelectItem( "JT1", useId: false );
            nestingTemplates.BaseInfo.Name.Enabled.WaitFor();
            nestingTemplates.Toolbar.CreateJob();
        }
    }
}
