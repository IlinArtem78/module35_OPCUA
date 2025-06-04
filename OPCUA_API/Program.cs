using Opc.Ua;
using OPCUA_API.Repositoria;

class Program
{
    public static void Main(string[] args)
    {
        OPCUARepositories oPCUARepositories = new OPCUARepositories();
        oPCUARepositories.ConverToClass();
        foreach (var format in oPCUARepositories._formatGet)
        { var t = oPCUARepositories.ConverType(format);
            var typeOfValue = oPCUARepositories.ConvertStringToType(format.Value, format); 
            Console.WriteLine(t); 
            Console.WriteLine(typeOfValue);
        }
    }
}