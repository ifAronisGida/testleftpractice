using Trumpf.Coparoo.Desktop;


namespace UiObjects.PageObjects
{
    public abstract class TcRepeaterObjectBase : RepeaterObject
    {
        public TInterface On<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return On<TPageObject>() as TInterface;
        }
    }
}
