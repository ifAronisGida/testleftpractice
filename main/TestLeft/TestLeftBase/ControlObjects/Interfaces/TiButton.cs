namespace TestLeft.TestLeftBase.ControlObjects.Interfaces
{
    public interface TiButton : TiControl
    {
        string Label { get; }

        void Click();
    }
}
