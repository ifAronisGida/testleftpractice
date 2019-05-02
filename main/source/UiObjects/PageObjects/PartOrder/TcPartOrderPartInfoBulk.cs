using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeZone.UiObjectInterfaces.Part;
using HomeZone.UiObjectInterfaces.PartOrder;
using Trumpf.Coparoo.Desktop;
using Trumpf.Coparoo.Desktop.WPF;


namespace HomeZone.UiObjects.PageObjects.PartOrder
{
    public class TcPartOrderPartInfoBulk : TcPageObjectBase, IChildOf<TcPartOrders>, TiPartOrderPartInfoBulk
    {
        protected override Search SearchPattern => Search.ByUid( "PartOrder.Detail.OrderedPart.Info" );
        public TiPartBulkDetailDesign Design => On<TcPartBulkDetailDesign>();

    }
}
