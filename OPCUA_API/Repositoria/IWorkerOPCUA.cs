using OPCUA_API.ModelTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCUA_API.Repositoria
{
    public interface IWorkerOPCUA
    {
      public string JsonMessage { get; set; }
      
    }
}
