using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCUA_API
{
    public enum DataTypes
    {
        Real, // Предполагаем, что System.Real соответствует float (Single)
        Bool,
        String,
        Int,
        Time,
        Byte,
        Double
    }
}
