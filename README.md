## Game Updater
This is a simple game updater that checks for updates on a server and downloads and installs them if necessary. It uses a JSON file to store the list of files on the server, and checks the local files against the server files to determine which files need to be updated.

## Features
- Check for updates by comparing the local version number with the version number on the server
- Download the latest version of the game and extract it to the appropriate directory
- Support for password-protected archives
- Integration with a hash file to verify the integrity of the downloaded files
- Progress bar for download and extraction

## Getting Started
To use the game updater, simply download the source code and build the solution in Visual Studio. You can then run the executable file to check for updates and download them if necessary.

# Prerequisites
- Visual Studio 2017 or later
- .NET Framework 4.6.1 or later

# Installing
To install the game updater, simply build the solution in Visual Studio and run the executable file.

## Usage
When you run the game updater, it will check for updates on the server and compare them to the local files. If an update is available, you will be prompted to download and install it. If you choose to install the update, the game updater will download the update archive, extract it, and replace the local files with the updated files.

## Built With
- C#
- .NET Framework

## Contributing
Contributions to the project are welcome. If you find a bug or have a feature request, please open an issue or submit a pull request.

## Version JSON File
The version JSON file should contain the latest version number of your game and the URL to download the updated game archive. Here's an example of what it might look like:

```json
{
    "latestVersion": "1.2.3"
}
```
## HashFiles JSON File
Integration with a file_hashes.json file to verify the integrity of the downloaded files. Here's an example of what it might look like:

```json
  {
    "Path": "file_hashes.json",
    "Hash": "87608cb6c42f063f45490fd46600e2d6ec6d16265868d85a20d3ffb85b9f1d65"
  }
```

## License
This project is licensed under the MIT License - see the LICENSE file for details.
