# Online Game Updater

The Online Game Updater is a tool for keeping your game up-to-date with the latest version available on a server. This is particularly useful for online games where updates may be released frequently to fix bugs, add new features, or improve performance.

## Features

- Checks for updates by comparing local version with latest version available on the server
- Downloads and extracts game archive containing updated files
- Automatic backup of old files
- Simple and intuitive user interface
- Lightweight and easy to integrate with existing games

## Getting Started

To use the Online Game Updater in your game, simply download the latest release from the [releases page](https://github.com/ludiam/LegionLauncher/releases) and extract it to your game directory.

Then, edit the `VersionUrl` constant in `Updater.cs` to point to the URL of your version JSON file on your server.

Finally, build and run the project. If there is an update available, the updater will prompt the user to download and install it.

## Version JSON File

The version JSON file should contain the latest version number of your game and the URL to download the updated game archive. Here's an example of what it might look like:

```json
{
    "latestVersion": "1.2.3"
}
```

## License
This project is licensed under the MIT License - see the LICENSE file for details.
