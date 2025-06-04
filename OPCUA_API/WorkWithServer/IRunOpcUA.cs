using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCUA_API.WorkWithServer
{
    public interface IRunOpcUA
    {

        Task StartWindowsFormsApp();
        void StopWindowsFormsApp();
        
    }
}
