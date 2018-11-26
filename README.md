# MatrixGenerator

This console application generates a matrix when provided with a text file containing floating point numbers with one on each line, a value for c and value for N.

## Getting Started

To run the application, please follow the steps below. 
1. Download and install .NET Framework 4.6.1 if it is not installed on the machine (https://www.microsoft.com/en-gb/download/details.aspx?id=49981).
2. Download the source code or clone the repository using git tools or Visual Studio. 

### Prerequisites

* .NET Framework 4.6.1
* Visual Studio 2015 or Above 

### Running the application

1. Once the source code is downloaded, open the solution file "MatrixGenerator.sln" inside the "MatrixGenerator" solution folder.
For example: C:\Repos\MatrixGenerator\MatrixGenerator\MatrixGenerator.sln
2. Set the "Solution Configuration" to "Debug" mode
3. Click "Build Solution" under the "Build" menu or press "F6"

### Running in Debug mode 
1. Once the solution is built in Visual Studio, go to "Solution Explorer" and right-click on the "MatrixGenerator.Console" project
2. Click "Properties" and navigate to the "Debug" tab
3. Under "Command line arguments", enter the fully qualified data file location, the value of "c" and the value of "N", respectively. 
For example: "C:\Users\Abc\Desktop\TrendControlSystems\Test\TEST.PRN" 4 300   
Each argument must have a space between them and in the above example c=4 and N=300   
Ensure the file path is surrounded by quotes (")
4. Set "MatrixGenerator.Console" as the StartUp Project
5. Click "Start Debugging" under the "Debug" menu or press "F5" 

### Running in Command Prompt
1. Once the solution is built in Visual Studio, navigate to the location of the "Debug" mode output folder of the "MatrixGenerator.Console" project. 
   For example: "C:\Repos\MatrixGenerator\MatrixGenerator\MatrixGenerator.Console\bin\Debug"
2. Open a new Command Prompt window and navigate to the above location
3. Run the "MatrixGenerator.Console.exe" with the three command line arguments; the fully qualified data file location, the value of "c" and the value of "N", respectively.  
For example: MatrixGenerator.Console.exe "C:\Users\Abc\Desktop\TrendControlSystems\Test\TEST.PRN" 4 300
Ensure the file path is sourrounded by quotes (")

### Expected Output 

The output of the application should be in a format similar to the following. 

Running... Please wait!

 [0.279525  0.276682  0.268098  0.254212  0.235722] 
 [0.276682  0.280218  0.277855  0.269717  0.256231] 
 [0.268098  0.277855  0.281864  0.279912  0.272113] 
 [0.254212  0.269717  0.279912  0.284270  0.282571] 
 [0.235722  0.256231  0.272113  0.282571  0.287076] 

Finished running!
Time taken: 8.0745ms

## Running the tests

1. Once the solution is built in Visual Studio, click "All Tests" under "Test" > "Run".
2. The "Test Explorer" window will display the output.

## Authors

* **Sumuditha Ranawaka**
