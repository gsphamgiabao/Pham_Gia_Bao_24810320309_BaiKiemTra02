# Hospital Management System (MDI)

A Windows Forms application demonstrating a **Multiple Document Interface (MDI)** architecture for managing hospital data.

## Features

- **MDI Parent Form** (`frmHospitalMain`) with `IsMdiContainer = true`.
- Navigation via a **MenuStrip** (System, Management, Windows) and a **ToolStrip**.
- Child forms:
  - `frmPatientProfiles` – manage patient records.
  - `frmDoctorSchedule` – view and edit doctor duty schedules.
  - `frmDepartmentList` – manage department catalog.
- **Child form lifecycle management**: prevents duplicate instances; activates an existing form when its menu item is selected again.
- **Window layout commands**: Cascade, Tile Horizontal, Tile Vertical, Close All.
- **StatusStrip** displays the current duty officer and a progress bar during data reloads.
- Simple **in‑memory data store** (`HospitalDataStore`) with seed data for patients, doctors, and departments.
- Screenshots captured via the `/capture` command.

## Screenshots

![Main UI](file:///D:/Test/BaiKiemTra02/screenshots/HospitalManagementSystem.PNG)

![Cascading view with multiple child forms](file:///D:/Test/BaiKiemTra02/screenshots/HospitalManagementSystem1.PNG)

## Getting Started

1. Open the solution in Visual Studio or run from the command line:
   ```
   cd D:\Test\BaiKiemTra02\HospitalManagementSystem\HospitalManagementSystem
   dotnet run
   ```
2. Use the **System** menu to log out, reload data, or exit.
3. Use the **Management** menu to open the Patient Profiles, Doctor Schedule, or Department list.
4. Use the **Windows** menu to arrange open child windows (Cascade, Tile Horizontal/Vertical) or close all.

## Extending the Application

- To add a new MDI child form, create the form, then add a menu item in `frmHospitalMain` and call `OpenChildForm<YourForm>()`.
- For persistent storage, replace the `HospitalDataStore` with a JSON or database implementation.
- Keyboard shortcuts can be added to menu items (e.g., `Ctrl+Shift+C` for Cascade) by setting the `ShortcutKeys` property.

## License

This project is provided for educational purposes.
