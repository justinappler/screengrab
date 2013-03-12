ScreenGrab
Screen Grabbing Tool for Windows
============================================================

This program replaces the following common procedure:

    * Copying a Screenshot to the Clipboard
    * Cutting out a section of the image
    * Saving that image to a file
    * Uploading it to a web server
    * Building a hyperlink to the file
    * Copying that link to the clipboard
    * Paste the link

with this:

    * Press Ctrl-Alt-PrintScrn and then Drag to select a portion of the screen
    * Paste the Link
    
============================================================

Change Log

    * 1.4
          o Bug Fix: ScreenGrab no longer appears in Alt-Tab Window
          o Bug Fix: FTP Operations no longer stall UI
          o Bug Fix: FTP Textboxes are white while test is in progress
          o Code Maintenance: Settings moved to own class
    * 1.3
          o Feature: Added Upload Progress Bar
          o Feature: Added Hotkeys
          o Bug Fix: FTP Upload no longer stalls UI
    * 1.2
          o Feature: Click-and-Drag to Select
    * Initial Release
    
============================================================
How To Use

Shortcuts:
    Ctrl+Alt+PrintScrn: Take Screenshot and begin selection
    Ctrl+Shift+PrintScrn: Take Screenshot and submit (full screen image)
    Double-click Tray Icon: Begin Selection (you must first hit PrintScreen)

Selection:
    When screen turns gray, click and drag to select a portion of the image to submit.
    The selected portion will return to color.
    Settings (Right-click tray > Settings)

Save to File: Sets a location to save the selected image to.

FTP Upload: Sets an FTP URI to upload the selected image to.

FTP Host: This value must be valid FTP host and can include the directory to save to.
    For example: ftp.mywebsite.com or ftp.mywebsite.com/html/images/upload

Copy Link to Clipboard: Sets the location to copy the to the clipboard after uploading to FTP.
    For example: http://www.mywebsite.com/images/upload/

============================================================

Developement Details
    ScreenGrab was written in C# using Microsoft Visual Studio 2008 Professional

Developers
    Justin Appler
    Nick Hebner

Contributors
    Ido Samuelson (HotKey Component)
    Iconaholic (Clipboard Icon)