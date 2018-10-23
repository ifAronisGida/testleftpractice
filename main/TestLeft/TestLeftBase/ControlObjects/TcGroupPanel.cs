using Trumpf.Coparoo.Desktop.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for group panels.
    /// </summary>
    public class TcGroupPanel : ControlObject
    {
        protected override Search SearchPattern => Search.Any;

        /// <summary>
        /// Gets or sets a value indicating whether the more area is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the more area is expanded; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoreExpanded
        {
            get => Node.GetProperty<bool>( "IsMoreExpanded" );
            set => Node.SetProperty( "IsMoreExpanded", value );
        }
    }
}
