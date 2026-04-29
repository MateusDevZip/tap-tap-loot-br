# Script para criar Release no GitHub
# Execute com: .\criar-release.ps1

param(
    [string]$GitHubToken = $env:GITHUB_TOKEN
)

Write-Host "╔════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
Write-Host "║  AutoTapTapLoot v1.1.0 - Criador de Release GitHub       ║" -ForegroundColor Cyan
Write-Host "╚════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
Write-Host ""

# Verificar token
if (-not $GitHubToken) {
    Write-Host "❌ Token do GitHub não encontrado!" -ForegroundColor Red
    Write-Host ""
    Write-Host "Para criar uma release, você precisa:" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "1️⃣  Gerar um token em: https://github.com/settings/tokens" -ForegroundColor White
    Write-Host "    - Clique em 'Generate new token (classic)'"
    Write-Host "    - Marque: 'repo' e 'public_repo'"
    Write-Host "    - Copie o token"
    Write-Host ""
    Write-Host "2️⃣  Execute este script assim:" -ForegroundColor White
    Write-Host "    `$env:GITHUB_TOKEN='seu_token_aqui'" -ForegroundColor Gray
    Write-Host "    .\criar-release.ps1" -ForegroundColor Gray
    Write-Host ""
    Write-Host "OU use a interface web do GitHub (mais fácil!):" -ForegroundColor Green
    Write-Host "    https://github.com/MateusDevZip/tap-tap-loot-br/releases/new" -ForegroundColor Gray
    Write-Host ""
    exit 1
}

$owner = "MateusDevZip"
$repo = "tap-tap-loot-br"
$tag = "v1.1.0"
$releaseTitle = "🎮 AutoTapTapLoot v1.1.0 - Bilingual Release"
$zipFile = "AutoTapTapLoot_v1.1.0.zip"

# Verificar se o arquivo ZIP existe
if (-not (Test-Path $zipFile)) {
    Write-Host "❌ Arquivo não encontrado: $zipFile" -ForegroundColor Red
    exit 1
}

$fileSize = (Get-Item $zipFile).Length / 1KB
Write-Host "✅ Arquivo encontrado: $zipFile (${fileSize}KB)" -ForegroundColor Green
Write-Host ""

# Body da release
$releaseBody = @"
## ✨ What's New

### 🌐 Bilingual Language Selector
- Switch between **Português (PT-BR)** and **English** in real-time
- No need to restart the application
- Language preference saved automatically

### 🎯 Features
- ⚡ **Auto Tap** — Configurable tap rate (1-30 packets/sec)
- 📊 **Stat Buffs** — 10 different stats with percentage multipliers
- 💾 **Settings Persistence** — Auto-saves configuration
- 🎨 **Dark Theme** — Built-in dark mode
- 🔗 **Game Integration** — Direct pipe communication

### 📦 Package Contents
- \`AutoTapTapLoot_v1.0.0.exe\` — Main application
- \`LEIA-ME.txt\` — Quick start guide (Portuguese)
- Required .NET dependencies included

## 🚀 How to Use

1. **Download** \`AutoTapTapLoot_v1.1.0.zip\`
2. **Extract** to any folder
3. **Double-click** \`AutoTapTapLoot_v1.0.0.exe\`
4. **Select your language** (Português or English)
5. **Enjoy!**

## ⚠️ Important Notes

- Tap Tap Loot must be **running**
- Bongo Cat and The Farmer Was Replaced must **NOT** be running
- Extreme buff values may break the game — backup your save!
- Requires .NET 8.0 Runtime

## 📋 System Requirements

- Windows 10 or later
- Tap Tap Loot (Steam)
- .NET 8.0 Runtime

## 🐛 Troubleshooting

**Pipes not connecting?**
- Ensure Tap Tap Loot is running
- Close Bongo Cat or The Farmer Was Replaced
- Restart the game

**.NET Runtime not found?**
- Download: https://dotnet.microsoft.com/download

**Need Help?**
- GitHub: https://github.com/MateusDevZip/tap-tap-loot-br

---

**Enjoy!** 🎮
"@

# Criar a release
Write-Host "📤 Criando release no GitHub..." -ForegroundColor Cyan

$uri = "https://api.github.com/repos/$owner/$repo/releases"
$headers = @{
    "Authorization" = "token $GitHubToken"
    "Accept" = "application/vnd.github.v3+json"
}

$body = @{
    tag_name = $tag
    name = $releaseTitle
    body = $releaseBody
    draft = $false
    prerelease = $false
} | ConvertTo-Json

try {
    $response = Invoke-RestMethod -Uri $uri -Method Post -Headers $headers -Body $body -ErrorAction Stop
    $uploadUrl = $response.upload_url -replace '\{.*?\}',''
    Write-Host "✅ Release criada com sucesso!" -ForegroundColor Green
    Write-Host ""
    Write-Host "📤 Fazendo upload do arquivo..." -ForegroundColor Cyan

    # Upload do arquivo ZIP
    $fileContent = [System.IO.File]::ReadAllBytes((Resolve-Path $zipFile))
    $uploadHeaders = @{
        "Authorization" = "token $GitHubToken"
        "Content-Type" = "application/zip"
    }

    $uploadUri = $uploadUrl + "?name=$(Split-Path $zipFile -Leaf)"
    $uploadResponse = Invoke-RestMethod -Uri $uploadUri -Method Post -Headers $uploadHeaders -Body $fileContent -ErrorAction Stop

    Write-Host "✅ Arquivo enviado com sucesso!" -ForegroundColor Green
    Write-Host ""
    Write-Host "╔════════════════════════════════════════════════════════════╗" -ForegroundColor Green
    Write-Host "║  ✅ Release criada e publicada com sucesso!              ║" -ForegroundColor Green
    Write-Host "╚════════════════════════════════════════════════════════════╝" -ForegroundColor Green
    Write-Host ""
    Write-Host "🎉 Link da release:" -ForegroundColor Green
    Write-Host "   https://github.com/$owner/$repo/releases/tag/$tag" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "📥 Download direto:" -ForegroundColor Green
    Write-Host "   https://github.com/$owner/$repo/releases/download/$tag/$zipFile" -ForegroundColor Cyan
    Write-Host ""
}
catch {
    Write-Host "❌ Erro ao criar release: $_" -ForegroundColor Red
    Write-Host ""
    Write-Host "Dicas:" -ForegroundColor Yellow
    Write-Host "- Verifique se o token é válido" -ForegroundColor White
    Write-Host "- Certifique-se de estar no diretório correto" -ForegroundColor White
    Write-Host "- Use a interface web como alternativa" -ForegroundColor White
    exit 1
}
