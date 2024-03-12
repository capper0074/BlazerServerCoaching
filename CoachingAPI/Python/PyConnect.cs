using Python.Runtime;
namespace CoachingAPI.Python
{
    public class PyConnect
    {

        public static void RunScript(string scriptName)
        {
            Runtime.PythonDLL = @"C:\\Users\\cappe\\AppData\\Local\\Programs\\Python\\Python312.dll";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                var pythonScript = Py.Import(scriptName);
                pythonScript.InvokeMethod("Hello");
            }
        }

        RunScript("Data");


    }
}
