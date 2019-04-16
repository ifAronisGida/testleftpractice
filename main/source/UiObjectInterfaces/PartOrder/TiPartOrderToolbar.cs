using HomeZone.UiObjectInterfaces.Common;

namespace HomeZone.UiObjectInterfaces.PartOrder
{
    public interface TiPartOrderToolbar : TiToolbar
    {
        void New();

        void Import();
        void Import( string fileName );
    }
}
