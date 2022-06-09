# Memoire

### Memoire is a Windows application designed to easily download your Snapchat Memories all at once.

Built with .NET Framework 4.8 using Newtonsoft.Json library

## About

I developed this software for my girlfriend, who needed
to be able to download large quantities of Snapchat data
without having to manually click through tens of thousands
of links. I created this software to recursively do this
instead, with some extra validation and error handling to
make the program friendly to anyone else who wants to try
it for themselves. This is open-source and free software
available on my GitHub page, LazySmurf.

I've commented the code as best as possible, so please
reference the code itself if you're curious about how
it all works. If you notice any issues, please feel free
to let me know on GitHub.


## How-To Use

Step 1:
Download your Snapchat data from the following URL:
https://accounts.snapchat.com
Once you've requested your data from Snapchat, it will take some time for them to process your request.
You will get an email from Snapchat when your data is ready to download. Once you get that email, download your data.

Step 2:
Once you've downloaded your Snapchat data, you can extract it from the archive that it comes in.
Inside the "json" folder, you will find a file called "memories_history.json"
Copy this file to the same folder as Memoire.exe

Step 3:
Open Memoire.exe and hit "Check For File"
Memoire will begin checking if the file is there, and if it is in the correct format.
If it all checks out, it will tell you how many Memories you have of each type and in total.

Step 4:
Click "Begin Download" to start the download process.
This will take some time usually. Please leave the application open and do not attempt to close it while it is downloading.
Once the download is complete, the progress bar will fill up and Memoire will let you know your downloads are complete.

Step 5:
Inside the folder where Memoire.exe is located, there should new be a folder called "Snap Memories"
Inside this new folder, you will find your memories organized into more folders by year, month, and day.


If you have any issues while using Memoire, please let me know on GitHub with a new issue/bug report.
Also be sure to check GitHub for new versions of Memoire before posting a bug report!
You can check your version of Memoire by running the 'Memoire (Version Info).exe' program in the same folder.

If you're a bit more tech savvy, please feel free to use the included Debug Mode to troubleshoot.
	Note: You can access Debug mode using the included Debug Mode executable, or by passing '-debug' to Memoire.exe via command line or Batch file.
I've also included the Version Info executable, which will give you assembly info about Memoire.exe, which can also be achieved by passing '-ver' to Memoire.exe via command line or Batch file.


## File Details

Memoire.exe - The main application file

Memoire (Debug Mode).exe - This is a batch file, converted to an executable, that contains only one line, which runs Memoire.exe inside this folder with the command line argument -debug

Memoire (Version Info).exe - This is the same as above, but for command line argument -ver instead. It's done this way so that it works universally across any Windows user/file directory, without displaying a console window, and giving it an icon and some version info.

Memoire.exe.config - This is a configuration file generated by Visual Studio when compiling the application. It's simply there to help the application run. Do not delete it, or any other files in this directory.

Memoire.xml - This is another configuration file generated by Visual Studio when compiling.

Newtonsoft.Json.dll - This is a library for JSON interaction in .NET framework. This allows Memoire to interact with the file type given to you, the user, by Snapchat.

Newtonsoft.Json.xml - This is a configuration file generated by the above mentioned Newtonsoft JSON library when Visual Studio compiles the application.

ReadMe.txt - This file

memories_history.json - This will be the file that you place into this folder once you've downloaded it from your Snapchat account. It contains JSON data which has information about the type of Memory, the date when it was saved, and the download URL, which are used by Memoire to automate downloading your Memories.
