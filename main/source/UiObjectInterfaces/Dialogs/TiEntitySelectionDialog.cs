namespace HomeZone.UiObjectInterfaces.Dialogs
{
    public interface TiEntitySelectionDialog
    {
        void Cancel();

        void Ok();

        bool SelectClose( string entityId );
    }
}
