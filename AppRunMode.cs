using System.Diagnostics;

class AppRunMode
{
    static void Main(string[] args)
    {
        Process usbtenki = new Process();
        usbtenki.StartInfo.FileName = "dracal-usb-get";
        usbtenki.StartInfo.Arguments = "-i 0,1,2 -I 1000 -L -";
        usbtenki.StartInfo.UseShellExecute = false;
        usbtenki.StartInfo.RedirectStandardOutput = true;

        try
        {
            usbtenki.Start();

            // skip inital 2 lines; to avoid log messages and capture only readouts
            usbtenki.StandardOutput.ReadLine();
            usbtenki.StandardOutput.ReadLine();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("could not run dracal-usb-get: " + e);
            return;
        }

        while (!usbtenki.HasExited)
        {
            String? output = usbtenki.StandardOutput.ReadLine();
            Console.WriteLine("\nUSbtenki output: " + output);
            //continue;
            if (output == null)
            {
                Console.Error.WriteLine("dracal-usb-get did not return data");
                return;
            }
            float[] fields = output.Split(',').Select(field => float.Parse(field)).ToArray();
            if (fields.Length != 3)
            {
                Console.Error.WriteLine("dracal-usb-get returned an incorrect number of fields");
            }
            else
            {
                Console.WriteLine("Temperature (C): " + fields[0]);
                Console.WriteLine("RH......... (%): " + fields[1]);
                Console.WriteLine("Pressure. (kPa): " + fields[2]);
                Console.WriteLine("Temperature (F): " + (fields[0] * 9 / 5 + 32));
            }
        }
        usbtenki.WaitForExit();
    }
}
