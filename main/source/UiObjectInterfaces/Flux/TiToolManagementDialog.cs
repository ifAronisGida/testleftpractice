namespace HomeZone.UiObjectInterfaces.Flux
{
    public interface TiToolManagementDialog
    {
        void NewToolList( string toolListName );

        void Close();

        void DeleteToolList( string toolListName );

        void RenameToolList( string toolListName );
    }
}
