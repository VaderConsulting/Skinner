# Skinner

Skinner is a VB.NET WinForms MDI editor for Centrafuse Auto car-PC skins. It loads `skin.xml` from `Program Files (x86)\Centrafuse\Centrafuse Auto\Skins` (default skin name Zed), maps IMAGES, ICONS, BUTTONIMAGES, and SECTIONS onto tab pages, and lays out labels, buttons, panels, and picture boxes from control bounds. The CFSkinner project (assembly title My Skinner, root namespace Centrafuse) models Skin, Section, Dialog, FontClass, and control types such as Slider, DynamicButton, and Visualisation; `ResizeableControl` adds drag-edge handles but is not yet wired into ParentForm. MenuPage is a stub MDI child, and File Open/Save As remain Visual Studio MDI template TODOs.

**Source last updated:** 2009-12-03 · **Language:** VB.NET · **Target:** .NET Framework 3.5 · **Output:** WinForms WinExe

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `Skinner` (`CFSkinner`) | VB.NET | WinForms WinExe | Loads a Centrafuse Auto `skin.xml` and shows sections as tabbed WinForms controls |
| `Backup/CFSkinner` | VB.NET | WinForms WinExe | Visual Studio backup of the same project (no `ResizeableControl.vb`) |

## How to open

Open `Centrafuse.sln` in Visual Studio 2008 (or later with .NET Framework 3.5 targeting). On load the app looks for `...\Centrafuse\Centrafuse Auto\Skins\Zed\skin.xml`; change `m_SkinName` in `ParentForm.vb` to point at another installed skin.

## Requirements

- Visual Studio 2008, .NET Framework 3.5

## Attribution and provenance

- **Assembly title / product:** My Skinner
- **Assembly company:** Microsoft (Visual Studio Windows Forms project template default)
- **Assembly copyright:** Copyright © Microsoft 2009
- **Root namespace / solution:** Centrafuse (`Centrafuse.sln`)
- **Centrafuse Auto:** third-party in-car entertainment software (Flux Media / Centrafuse). This tree is my working copy of a skin editor; it models the skin XML schema in VB.NET and does not include Centrafuse SDK binaries or a skin pack.
- Working copy from my Historical Dev folder `Skinner`

## License

MIT. Copyright (c) 2026 VaderConsulting, for Dave Robinson's code. See `LICENSE`. Centrafuse product names and the skin XML schema remain the original vendor's.
