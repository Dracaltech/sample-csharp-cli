using System.Diagnostics;

class App
{
    static void Main(string[] args)
    {
        Process usbtenki = new Process();
        usbtenki.StartInfo.FileName = "dracal-usb-get";
        usbtenki.StartInfo.Arguments = "-i 0,1,2";
        usbtenki.StartInfo.UseShellExecute = false;
        usbtenki.StartInfo.RedirectStandardOutput = true;

        try
        {
            usbtenki.Start();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("could not run dracal-usb-get: " + e);
            return;
        }

        usbtenki.WaitForExit();

        string? output = usbtenki.StandardOutput.ReadLine();

        if (output == null)
        {
            Console.Error.WriteLine("dracal-usb-get did not return data");
            return;
        }

        float[] fields = output.Split(',').Select(field => float.Parse(field)).ToArray();

        if (fields.Length != 3)
        {
            Console.Error.WriteLine("dracal-usb-get returned an incorrect number of fields");
            return;
        }

        Console.WriteLine("Pressure. (kPa): " + fields[0]);
        Console.WriteLine("Temperature (C): " + fields[1]);
        Console.WriteLine("RH......... (%): " + fields[2]);
        Console.WriteLine("Temperature (F): " + (fields[1] * 9 / 5 + 32));
    }
}
