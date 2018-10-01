using TestLeft.TestLeftBase.Utilities;
using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.PageObjects
{
    public abstract class TcPageObjectBase : PageObject
    {
        protected TInterface Find<TInterface>(string uid) where TInterface : class
        {
            return TcControlMapper.Map<TInterface>( this.FindGeneric( Search.ByUid( uid ) ) );
        }
    }
}
