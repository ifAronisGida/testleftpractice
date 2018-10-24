using SmartBear.TestLeft.TestObjects.Qt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trumpf.PageObjects;
using Trumpf.PageObjects.Qt;
using Trumpf.PageObjects;
using TestLeft.TestLeftBase.ControlObjects;


namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    public class TcStartCutToolbar : PageObject, IChildOf<TcCutMainWindow>
    {
        protected override Search SearchPattern => Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonPage",
            QtIndex = 1
        });

        //public TcTruIconButton PalettIzing_Button => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_66F318C9_79DA_4E07_8F0B_FF7B4F27DFA4"));
        //public TcTruIconButton BoostButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_BC09C701_3786_45f2_9C7A_7E3D35B77737"));

    }

    public class TcCutStartEditToolbar :PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_9309aa8b-24dc-495f-a346-7c9f899ceb10");

        public TcTruIconButton BoostButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_BC09C701-3786-45f2-9C7A-7E3D35B77737"));
        public TcTruIconButton SelectButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_CF425559-C37C-48a6-AEE8-4B06BF51815B"));
        public TcTruIconButton SheetLayoutButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_36BE2782-5852-4fa6-A9F8-7284D5FF78B4"));
        public TcTruIconButton TechnologyButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_1244F9F6-65B4-4faf-9FD6-059767392D72"));

    }

    public class TcCutStartTechnologyToolbar :PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_3a11084f-12c5-48b8-9ce5-e45bc9d1c233");

        public TcTruIconButton ProcessAllButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_f089f417-3d64-449b-b9eb-cffa3e7561c8"));
        public TcTruIconButton TwinLineButton => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_391ce96d-3ff3-401d-bbcc-9b0fbb9e9bbb"));
        public TcTruIconButton ProcessingParametersButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonGroupOption",
            QtIndex = 1
        }));
    }

    public class TcCutStartSheetLayoutToolbar : PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_2bc3f6f5-7dc6-44e6-8262-ef8ba2ee016e");

        public TcTruIconButton AlignButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonButtonControl",
            QtIndex = 1
        }));
        public TcTruIconButton NestingParametersButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonGroupOption",
            QtIndex = 1
        }));
        public TcTruIconButton ImportPartButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_EAE95059-D8C8-4E1B-AAB0-D3E409137547"));
        public TcTruIconButton CreateSheetLayoutButton => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_A93B161C-FA65-4A36-A5F4-36DAA617CA05"));
    }

    public class TcCutStartSimulationToolbar : PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_d91c6b32-924b-4a30-a66b-83121d6f5892");

        public TcTruIconButton StartButtonButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonButtonControl",
            QtIndex = 1
        }));
        public TcTruIconButton PlayButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonButtonControl",
            QtIndex = 2
        }));
        public TcTruIconButton StopButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonButtonControl",
            QtIndex = 3
        }));
    }

    public class TcCutStarHelpToolbar : PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_1985824c-b1d4-43fe-93aa-cda1bfe6b3a6");

        public TcTruIconButton QuestionMarkButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_805a4928-47dc-41ed-96a5-6209041f6bb9"));
        public TcTruIconButton CreateAnalysisPackageButton => Find<TcTruIconButton>(Search.ByObjectName("qt_button_8A3681D2-9D03-40E5-BFDB-DD1293F99EC0"));
    }

    public class TcCutStarFinishToolbar : PageObject, IChildOf<TcStartCutToolbar>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonGroup_01CF7079-21AA-41D1-8536-899030C37BB0");

        public TcTruIconButton NcParametersButton => Find<TcTruIconButton>(Search.By(new QtPattern()
        {
            QtClassName = "Qtitan::RibbonGroupOption",
            QtIndex = 1
        }));
        public TcTruIconButton PalettizingBySheetButton => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_66F318C9-79DA-4E07-8F0B-FF7B4F27DFA4"));
        public TcTruIconButton CreateNcButton => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_1C16C3EC-631C-4C6A-BA0F-9CBAD471CC9B"));
        public TcTruIconButton ReleaseProductionPackageButton => Find<TcTruIconButton>(Search.ByObjectName("qt_splitButton_EC8FC2E4-4185-43F8-94F7-13290D86BE5A"));
    }

    }
