# How to Compile the Launcher Executable (.exe)

This guide explains how to compile the C# source code (`launcher.cs`) into the standalone Windows executable (`D-Mart-Billing.exe`) using the built-in Windows C# compiler.

## Prerequisites

- You must be running on a **Windows** operating system.
- The C# compiler (`csc.exe`) is pre-installed with the .NET Framework on Windows.

## Step-by-Step Instructions

1. **Open Command Prompt or PowerShell:**
   - Navigate to the project root directory (`dmart-billing`).
   - Click on the address bar of the File Explorer, type `cmd`, and press **Enter**. Or, hold **Shift** and right-click inside the folder, then select **Open PowerShell window here**.

2. **Run the Compile Command:**
   - Copy and paste the following command into your terminal and press **Enter**:

   ```powershell
   C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /target:winexe /out:D-Mart-Billing.exe /r:System.Windows.Forms.dll /r:System.Drawing.dll launcher.cs
   ```

3. **Verify the Executable:**
   - The compiler will print the version and copyright details. If there are no errors, a new file named `D-Mart-Billing.exe` will appear in your project folder.

---

## How It Works

- **`D-Mart-Billing.exe`**: Double-clicking this file starts the backend server and MySQL database silently in the background.
- **Auto-Browser Open**: After launching, it automatically opens your default browser at `http://localhost:8080`.
- **Server Controller**: A small window will appear on your screen. **Closing this window (X) will automatically terminate the backend server and database processes.**
