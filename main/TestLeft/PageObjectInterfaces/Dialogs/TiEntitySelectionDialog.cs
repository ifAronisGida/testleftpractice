namespace PageObjectInterfaces.Dialogs
{
    public interface TiEntitySelectionDialog
    {
        void Cancel();

        void Ok();

        bool SelectClose( string entityId );
    }
}
