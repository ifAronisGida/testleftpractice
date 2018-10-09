using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectInterfaces.CutJob
{
    public interface TiRawSheetList
    {
        int Count { get; }

        TiRawSheet GetRawSheet( int index );
    }
}
