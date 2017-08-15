# Indeed Sample

This is a Windows Service written in C#.
It is a small sized service that will simply send an e-mail at a time interval.
The email authentication and other parameters are easily editable in a single class file.

## Getting Started

To install this

### Prerequisites

This program was written and tested from the Visual Studio 2015 version.
You will also need an email address that can be accessed from this program.

```
Give examples
```

### Installing

HOWTO install from Visual Studio.

  1. Go to File-> Open -> Open from Source Control
  2. In Team Explorer Window
    - Local Git Repositories
    - Click Clone
    - Enter the URL of this project
    - Click Clone
  The Project Solution should now open in your Visual Studios Window.

End with an example of getting some data out of the system or using it for a little demo

## Running Program

This program can be run directly from the Visual Studios window. And by installing it as a Windows Service.

### First

Open the SimpleParams.cs file
Here you can edit the parameters for this program. Like the Email authentication, time interval, and email message, etc..
Make sure to save and "Build Solution"
  -Build -> Build Solution

### Run from Visual Studio

At your Visual Studios toolbar, make sure the mode is set to "Debug" and then you can click start and the program will begin.

### To run and install this as a Windows Service

At your Visual Studios toolbar, make sure the mode is set to "Release"
Make sure to save and "Build Solution"
  -Build -> Build Solution
  
In your Solution Explorer window, Right Click on the "IndeedSample" solution name.
Then click "Open Folder in File Explorer"
In the newly opened File Explorer window you should see files and folders for this project.
Go to the "bin" folder
Then open the "Release" folder.
Copy the Link to this folder. (ex: C:\Users\User\Documents\visual studio 2015\Projects\IndeedSample\IndeedSample\bin\Release)
Open a Developer Command Propmt and make sure to "Run as Administrator"

From the Developer Command Prompt
type "cd " and then perform a "CTRL+V" to paste the Release folder link
Click enter

You can now check to make sure you are in the correct folder by typing in the command "dir"
  This should display all the files and folders in this directory. One of those files should be "IndeedSample.exe"

now type in this command "installutil IndeedSample.exe"
You should see a message that ends with "The transacted install has completed"

***You can uninstall this service by typing the command "installutil /u IndeedSample.exe"

To start this Service you must open the Task Manager on your computer.
In the Task Manager Window go to the Services tab
You should see a service names "IndeedSample" right click it and click on "Start", this will start your service

***You can stop this service by performing a right click on it and clicking on "Stop"


## Authors

* **Daniel Wallengren** 


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

