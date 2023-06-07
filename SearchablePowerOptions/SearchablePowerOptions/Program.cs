using IWshRuntimeLibrary;
using System.Runtime.InteropServices;

void CreateShortcut(string name, string path, string args)
{
    string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + (@"\" + name + ".lnk");

    IWshShortcut shortcut = (IWshShortcut)new WshShell().CreateShortcut(shortcutAddress);
    shortcut.TargetPath = path;
    shortcut.Arguments = args;
    shortcut.Save();
}

string name, path, arg;

// Sleep function
name = "Sleep";
path = @"C:\Windows\System32\rundll32.exe";
arg = "powrprof.dll SetSuspendState 0,1,0";
CreateShortcut(name, path, arg);

// Restart function
name = "Restart";
path = @"C:\Windows\System32\shutdown.exe";
arg = "/r /t 00";
CreateShortcut(name, path, arg);

//Shutdown function
name = "Shutdown";
path = @"C:\Windows\System32\shutdown.exe";
arg = "/s /t 00";
CreateShortcut(name, path, arg);

Console.WriteLine("Start Menu entries created. You can now use the search bar to shutdown, restart, and sleep.");
Console.WriteLine("This window will close in 5 seconds");
Thread.Sleep(5000);