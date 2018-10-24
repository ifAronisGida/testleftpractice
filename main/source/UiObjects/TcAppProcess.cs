using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;
using Trumpf.Coparoo.Desktop;


namespace UiObjects
{
    internal class TcAppProcess : ProcessObject
    {
        public TcAppProcess( IProcess process, IDriver driver ) : base( process )
        {
            this.Driver = driver;
        }
    }
}