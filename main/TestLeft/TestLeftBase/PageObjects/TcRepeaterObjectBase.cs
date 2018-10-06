using Trumpf.PageObjects;

namespace TestLeft.TestLeftBase.PageObjects
{
    public abstract class TcRepeaterObjectBase : RepeaterObject
    {
        public TInterface On<TInterface, TPageObject>() where TInterface : class where TPageObject : class, IPageObject
        {
            return On<TPageObject>() as TInterface;
        }
    }
}
