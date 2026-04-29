# Contributing to AutoTapTapLoot 🎮

Thank you for your interest in contributing! We welcome contributions of all kinds.

## How to Contribute

### 1. Fork the Repository
```bash
git clone https://github.com/yourusername/tap-tap-loot-br.git
cd tap-tap-loot-br
```

### 2. Create a Feature Branch
```bash
git checkout -b feature/your-feature-name
```

### 3. Make Your Changes
- Follow the existing code style (C# conventions)
- Add comments for complex logic
- Test your changes thoroughly

### 4. Commit Your Changes
```bash
git commit -m "feat/fix: Clear description of your change"
```

### 5. Push to Your Fork
```bash
git push origin feature/your-feature-name
```

### 6. Create a Pull Request
Open a PR to the main repository with:
- Clear title describing the change
- Description of what was changed and why
- Any related issues

## Code Style Guidelines

### C# / .NET
- Use PascalCase for class and method names
- Use camelCase for private fields and local variables
- Add XML comments for public methods
- Keep lines under 120 characters when possible

Example:
```csharp
private Dictionary<string, string> _settings = [];

/// <summary>
/// Loads application settings from file.
/// </summary>
private void LoadSettings()
{
    // Implementation here
}
```

### Commits
- Use descriptive commit messages
- Reference issues when applicable: `fixes #123`
- Format: `type: description`
  - `feat`: New feature
  - `fix`: Bug fix
  - `docs`: Documentation
  - `style`: Code style changes
  - `refactor`: Code refactoring
  - `test`: Adding tests
  - `chore`: Maintenance tasks

## Translation Guidelines

If you're helping translate:
1. Add your language code to `Localization` class in `Form1.cs`
2. Create a new dictionary following the PT/EN pattern:
```csharp
public static readonly Dictionary<string, string> FR = new()
{
    ["PacketsPerSecond"] = "Paquets par seconde",
    // ... more translations
};
```
3. Update UI to include language selector for new language
4. Test all UI elements display correctly

## Bug Reports

Create an issue with:
- Clear title
- Steps to reproduce
- Expected vs actual behavior
- System information (.NET version, Windows version)
- Screenshots if applicable

## Feature Requests

Describe:
- Use case and motivation
- Proposed implementation (if you have ideas)
- Any related issues

## Testing

Before submitting:
- Test the auto-tap functionality works
- Verify language switching works properly
- Check settings are saved/loaded correctly
- Ensure no console errors

## Community

- Be respectful and constructive
- Ask questions if something is unclear
- Help review other PRs
- Share feedback on documentation

## Questions?

Open a GitHub issue with label `question` or start a discussion.

---

Thank you for making AutoTapTapLoot better! 🚀
