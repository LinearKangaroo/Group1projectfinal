# Copilot Instructions

## General Guidelines
- First general instruction
- Second general instruction

## Code Style
- Use specific formatting rules
- Follow naming conventions

## Project-Specific Rules
- When users run the app and click Dashboard, it should open FrmAdash. Ensure uiNavMenu1.AfterSelect is handled, and use UITabControl.AddPage when available. If the UI doesn't show on click, add the AfterSelect handler and attempt to use UITabControl.AddPage via reflection; fallback to TabPage.Add.
- Auto-open Dashboard on startup by selecting the first node.