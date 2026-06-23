# D-Mart Billing System (MySQL Edition)

A frameworkless, high-performance Java web application for D-Mart billing, fully migrated to a MySQL database with portable execution capabilities.

---

## 🚀 How to Run (on Any Windows PC)

We have created a self-healing startup script that handles database initialization, schema loading, and starting the web server automatically.

### Step 1: Prerequisites
Make sure the target PC has:
1. **Java JDK 11 or higher** installed. 
   - 📥 If not installed, download from: [Adoptium Temurin JDK 17 (Recommended)](https://adoptium.net/temurin/releases/)
2. **MySQL Server** installed. 
   - 📥 If not installed, download from: [MySQL Community Installer](https://dev.mysql.com/downloads/installer/) (Select the MySQL Server option during installation).
   - (Note: If MySQL is installed but not running, our `start.bat` script will automatically attempt to launch it on port `3306` in the background).

### Step 2: Launch the App
1. Double-click the **`D-Mart-Billing.exe`** launcher (or double-click **`start.bat`**).
2. The launcher will:
   - Verify Java installation.
   - Detect if MySQL is running on port `3306`.
   - If MySQL is not running, start it using a local, self-contained `mysql-data` directory.
   - Create the `dmart` database and configure user passwords.
   - Compile all Java source files.
   - Launch the web server on http://localhost:8080.
   - 
#### Step 3: Admin
   1. Username : admin1 Password : admin123
   2. Username : cashier1 Password : cashier123
   3. Username : cashier2 Password : cashier123
---

## 🛠️ File Structure

- **`start.bat`**: Portable startup script for Windows.
- **`start.sh`**: Portable startup script for Linux/macOS.
- **`mysql-connector-j-8.4.0.jar`**: MySQL JDBC connection driver.
- **`schema.sql`**: The MySQL database schema and seed data.
- **`src/`**: Java source code.
- **`web/`**: Frontend files (HTML, CSS, JS).
