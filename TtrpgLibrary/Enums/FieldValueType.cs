using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtrpgLibrary.Enums
{
    public enum FieldValueType : int
    {
        Readonly = 0,
        Text = 1,
        Integer = 2,
        List = 3,
        Modal = 4
            // TODO - Add Hidden type
    }
}
