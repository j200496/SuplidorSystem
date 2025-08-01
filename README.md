# 🧾 C# Windows Forms App for Supplier Management

This is a **desktop application** built with **C# and Windows Forms** for managing suppliers in a local business environment. The application includes features such as CRUD operations, input validations, interface-based architecture, and database integration using **SQL Server LocalDB**.

---

## 🛠️ Features

- Add, edit, delete, and search supplier records.
- Field-level input validations (required fields, email format, numeric constraints, etc.).
- Uses **interfaces** to separate logic from implementation, promoting clean code and testability.
- Connected to a **local SQL Server database** for data persistence.
- Responsive form design with clear user feedback messages.

---

## ⚙️ Technologies Used

| Technology          | Purpose                          |
|---------------------|----------------------------------|
| C# (.NET Framework) | Core language and app logic      |
| Windows Forms       | GUI for desktop environment      |
| SQL Server LocalDB  | Local database for persistence   |
| ADO.NET             | Database connection and queries  |
| Interfaces (C#)     | Abstraction and clean architecture |
| ErrorProvider       | UI feedback for validation errors |

---

## 📁 Project Structure

```text
SupplierApp/
├── Interfaces/
│   └── ISupplierService.cs
├── Models/
│   └── Supplier.cs
├── Services/
│   └── SupplierService.cs
├── Forms/
│   ├── MainForm.cs
│   ├── AddEditSupplierForm.cs
├── Data/
│   └── DbConnection.cs
├── Program.cs
├── App.config
---
## Deveopment
Created by Joel Diaz
