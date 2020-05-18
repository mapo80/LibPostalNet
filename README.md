# LibPostalNet

This library provides C# bindings for libpostal (https://github.com/openvenues/libpostal).

We've included a compiled version of libpostal (postal.dll) for use in the demo (LibPostalConsole), however, 
you are free to compile your own. However, you will need to download libpostal's data and models at 
https://github.com/openvenues/libpostal/tree/master/data if you have not already.

Once you have the files downloaded, compile and run LibPostalConsole on the command line with 1 argument - 
the path to the data directory.

```
.\LibPostalConsole.exe C:\LibPostalData
```

### Compiling libpostal on Windows

Follow the instructions here: https://github.com/openvenues/libpostal#installation-windows

Essentially, you are using some MSys2/MinGW to compile libpostal on a windows machine. Once you install
MSys, it will give you a number of shells to choose from (shortcuts), pick "MSYS2 MinGW 64-bit", in order
to ensure that the final DLL is built against msvcrt.dll and not msys-2.x.dll, otherwise C# / .NET will complain.

Credit to https://github.com/mapo80 and https://github.com/mapo80/LibPostalNet
