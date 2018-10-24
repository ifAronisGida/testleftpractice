namespace PageObjectInterfaces.Controls
{
    public interface TiButton : TiControl
    {
        string Label { get; }

        void Click();
    }
}
