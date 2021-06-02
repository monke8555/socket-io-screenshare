# Screen sharing with Socket.IO
This is a little project I made, in C# and JS, which demonstrates screen sharing with [Socket.IO](https://github.com/socketio/socket.io). The screen is first converted to Base64 and then sent to the server, which then transmits it to all connected clients which convert it back to an image and show the output.

## Parts

### Client

A client to see the screen being transmitted by website. It is possible to run an unlimited amount of clients as the server transmits to all connected clients. Written in [Avalonia](https://github.com/AvaloniaUI/Avalonia).

### Webpage

The webpage to share the screen. To avoid glitches, please run only once.

### Server

The server to receive and re-transmit the screen.

## Usage

First make sure you have [node.js](https://github.com/nodejs/node) installed

Download the client for your OS, Linux, macOS, Windows, or Android (Coming soon).  
Next, open your terminal in the Server directory and run `npm start`  
Don't close the terminal until you finish using the programs, as closing it will make you unable to share.  
Now, open the Webpage directory, and open index.html in your browser and click the "Share Screen" button. Choose what you want to share in the dialog that opens.  
After doing that, keep the webpage open, and start the client you downloaded, and run the binary for your OS. It's name will start with ScreenShareClient and end with your OS's executable format (exe, app, dmg, or nothing for linux).  
If you use linux you might need to do `chmod +x ScreenShareClient` or give it executable permissions by using the context menu first.  
And there you go!  
Please star this repo if you liked it.  

## License

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org/>