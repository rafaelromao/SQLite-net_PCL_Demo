# SQLite-net_PCL_Demo

Example of how to configure SQLite-net PCL on a Windows Phone app, accessing SQLite via a Portable Class Library.

## Important

When you download the project, it will not work.

The TestDatabaseInitialization test will not pass, saying the 'sqlite3.dll' could not be loaded.

To fix that, install and add a reference to the official SQLite for Windows Phone 8.1 extension, available at http://www.sqlite.org/2015/sqlite-wp81-winrt-3080900.vsix.

After that, the project will not compile anymore, saying there are duplicate references to the 'sqlite3.dll'.

Now, remove the reference to the official SQLite for Windows Phone 8.1 extension that you just added (yes, I know!).

Compile and now the test passes, and even after many clean/rebuild cicles it continues to work.

I got this solution after trying several guides available online, none of them fully working for me. That was the only way I could make "SQLite-net PCL" work.

I appreciate if you can point me to a better solution.

## How this solution was composed

The project "SQLite-net_PCL_Demo.Core" is a Portable Class Library (PCL) that accesses the SQLite database.

As a PCL, that project compiles agains a bait, available in the "SQLitePCL.raw_basic" project, acessed by the "SQLite-net PCL" package.

I first installed the "SQLitePCL.raw_basic" and only then the "SQLite-net PCL" to ensure I was using the most recent version.

The project "SQLite-net_PCL_Demo.Core.Tests" is a Unit Test App (Windows Phone 8.1 Test Project Template).

To avoid running the bait, this project references the package "SQLitePCL.raw", with contains the actual implementation that access the "sqlite3.dll", specific for the compiled platform.

For some reason I do not understand, the version of "sqlite3.dll" that comes with the "SQLitePCL.raw" package is not recognized by the runtime until the workaround involving the "SQLite for Windows Phone 8.1" extension is applied.