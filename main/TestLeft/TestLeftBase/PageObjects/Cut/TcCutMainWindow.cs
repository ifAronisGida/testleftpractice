using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trumpf.PageObjects;
using Trumpf.PageObjects.Qt;
using TestLeft.TestLeftBase.ControlObjects;
using TestLeft.TestLeftBase.PageObjects.Shell;

namespace TestLeft.TestLeftBase.PageObjects.Cut
{
    public class TcCutMainWindow : PageObject, IChildOf<TcCutApp>
    {
        protected override Search SearchPattern => Search.ByObjectName("qt_ribbonMainWindow");
    }
}
