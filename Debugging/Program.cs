// See https://aka.ms/new-console-template for more information
using static System.Console;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
internal class Program
{
    private static void Main(string[] args)
    {
        ConfigurationBuilder builder = new();
        builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json", optional:true, reloadOnChange:true);
        IConfigurationRoot configurations = builder.Build();
        TraceSwitch ts = new(displayName: "PacktSwitch", description: "This traces switch is set via a json configuration file");
        configurations.GetSection("PacktSwitch").Bind(ts);
        Trace.WriteLineIf(ts.TraceError, "Trace error");
        Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
        Trace.WriteLineIf(ts.TraceInfo, "Trace information");
        Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");

        static double Add(double a, double b)
        {
            return a + b;
        }

        double a = 4.5;
        double b = 2.5;
        double answer = Add(a, b);
        WriteLine($"{a} + {b} = {answer}");
        Debug.WriteLine("Debug says. I am watching");
        Trace.WriteLine("Traces says... I am watching");
        Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
        Trace.AutoFlush = true;
        WriteLine("Hello, World!");
    }
}