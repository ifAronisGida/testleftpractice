namespace UiObjectInterfaces.Controls
{
    public interface TiButton : TiControl
    {
        string Label { get; }

        void Click();
    }
}