# Changelog

Todas as mudanças notáveis neste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
e este projeto adere ao [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2026-04-28

### 🌐 Added
- **Bilingual Language Selector** — Switch between Portuguese (PT-BR) and English in real-time
- `Localization` class with complete string dictionaries for PT and EN
- `ComboBox` language selector in the Status panel
- Dynamic UI translation without application restart
- Language preference persistence in `settings.json`

### ✨ Improved
- Complete README translation to Portuguese and English
- Better documentation structure with badges and feature highlights
- Improved error messages with localization support
- Settings management with language persistence

### 🔧 Changed
- Updated .NET target framework from 10.0 to 8.0 for broader SDK compatibility
- Separated internal buff key names (English, stored in settings) from display names (translated UI)
- Refactored `BuffNames` to `BuffKeys` for better clarity
- Updated `AppSettings` class to include `Language` field

### 🐛 Fixed
- Buff names now properly update when language is changed
- Settings compatibility maintained across language changes

### 📝 Technical Details
- `Form1.cs`: Added `Localization` static class, `ApplyLanguage()` method, language event handler
- `Form1.Designer.cs`: Added `ComboBox` for language selection with event binding
- `Program.cs`: Updated documentation to Portuguese
- `AutoTapTapLoot.csproj`: Updated to net8.0-windows framework

---

## [1.0.0] - Original Release

### Features
- Auto Tap functionality
- Stat Buff system with percentage multipliers
- 10 different buffable stats (Health, Attack, Armor, etc.)
- Dark theme UI
- Settings persistence in JSON
- Named pipe communication with game

---

**Status**: All features working and tested ✅
