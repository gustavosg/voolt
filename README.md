# voolt

This is an assessment project for the position of C# .NET Developer at Voolt.

## Table of Contents

- [Description](#description)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)

## Description

This project uses a little of Dependency Injection, Repository and Service patterns. 

## Installation

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)

### Steps

1. Clone this repository:

   ```bash
   git clone https://github.com/gustavosg/voolt

   ```

2. Navigate to the project directory:

   ```bash
   cd voolt\App\Api\Voolt-Test-Project
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

## Usage

1. To Run the project, execute in the terminal: 

   ```bash
   dotnet run --urls=http://localhost:5001/
   ```

2. Open the Web Browser at http://localhost:5001/swagger/. It will open the Swagger Documentation.
The project will show up. 

3. Then, execute the Post Action to populate data, and Get To Retrieve the stored data. 

* The requirement 'Creating a data model of all partitions with default values as an array' is triggered by the Action Post;
* The requirement 'Entire Page Model' is triggered by the Action Get;
* The requirement 'Update data in one of the selected blocks' is triggered by the Action Put;
* The requirement 'Removing a section from the user's section list' is triggered by the Delete action;

## License

This project is licensed under the [MIT License](https://mit-license.org/).
