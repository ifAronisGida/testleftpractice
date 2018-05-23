﻿using Trumpf.PageObjects.WPF;

namespace TestLeft.TestLeftBase.ControlObjects
{
    /// <summary>
    /// The ControlObject for buttons.
    /// </summary>
    /// <seealso cref="Trumpf.PageObjects.WPF.ControlObject" />
    public class TcTruIconButton : ControlObject
    {
        protected override Search SearchPattern => Search.Any;
    }
}
