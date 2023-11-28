# Node-RED Setup and Flow Import Guide

## Installation of Node-RED

To install Node-RED, you must have Node.js and npm (Node Package Manager) installed on your system. You can download Node.js from the official website which will include npm. Here's how to install Node-RED:

1. **Install Node.js and npm**:
   - Go to the [Node.js website](https://nodejs.org/) and download the latest LTS version for your operating system.
   - Follow the installation prompts, making sure to include npm.

2. **Install Node-RED**:
   - Open your command line interface (CLI), such as Command Prompt on Windows, Terminal on macOS, or a shell on Linux.
   - Run the following command to install Node-RED globally:
     ```
     npm install -g --unsafe-perm node-red
     ```

3. **Start Node-RED**:
   - In your CLI, start Node-RED by running:
     ```
     node-red
     ```
   - You should see a message indicating that Node-RED is running, usually on `http://127.0.0.1:1880`.

## Importing the Node-RED Flow

After setting up Node-RED, you can import the provided JSON script to load the pre-configured flow.

1. **Access Node-RED**:
   - Open your web browser and navigate to `http://127.0.0.1:1880`.

2. **Import JSON**:
   - In the Node-RED interface, click on the menu button at the top right (three horizontal lines).
   - Select `Import` > `Clipboard`.
   - Paste the JSON script into the text field.
   - Click `Import`.

## Setting Up Directory for CSV Output

To save the CSV output, you'll need to specify a directory where Node-RED has write permissions.

1. **Choose Directory**:
   - Decide on a directory where you want the CSV files to be saved. It can be any location where your user account has write permissions.

2. **Configure File Node**:
   - In your Node-RED flow, double-click the `file` node that handles the CSV output.
   - Set the 'Filename' to the absolute path of the desired output file within your chosen directory, for example:
     ```
     C:/path/to/your/directory/output.csv
     ```
     Make sure to replace the path with your actual directory path.
   - Select 'Append to file' as the file mode.
   - Set the character encoding to `UTF-8`.

3. **Deploy the Flow**:
   - Click `Deploy` to save the changes.

## Usage Instructions

Once everything is set up, you can simulate data generation:

1. **Click on an Injector Node**: Find the injector nodes on your flow canvas and click on one to simulate data. This should append a new entry to the CSV file.
2. **Check the CSV File**: Navigate to the directory you set up in the file node to view the generated CSV file. Each click on an injector should add a new line to this file.

---
