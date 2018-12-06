using System;
using System.Collections;
using System.Collections.Generic;
using SmartBear.TestLeft.TestObjects;

namespace HomeZone.UiObjects.Utilities
{
    internal class TcEnumerableProxy<T> : IEnumerable<T>
    {
        private IObject mRemoteEnumerable;

        public TcEnumerableProxy( IObject remoteEnumerable )
        {
            mRemoteEnumerable = remoteEnumerable;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorProxy( mRemoteEnumerable.CallMethod<IObject>( "GetEnumerator" ) );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class EnumeratorProxy : IEnumerator<T>
        {
            private IObject mRemoteEnumerator;

            public EnumeratorProxy( IObject remoteEnumerator )
            {
                mRemoteEnumerator = remoteEnumerator;
            }

            public T Current => mRemoteEnumerator.GetProperty<T>( "Current" );

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                try
                {
                    mRemoteEnumerator.CallMethod( "Dispose" );
                }
                catch( InvocationException )
                {
                    // No Dispose? Not a problem!
                }
            }

            public bool MoveNext()
            {
                return mRemoteEnumerator.CallMethod<bool>( "MoveNext" );
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
