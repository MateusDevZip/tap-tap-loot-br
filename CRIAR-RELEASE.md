# 🚀 Como Criar a Release no GitHub

Existem **2 formas** de criar a release:

---

## ✨ Opção 1: Interface Web do GitHub (Recomendada - Mais Fácil)

### Passo 1: Ir para Releases
1. Abra: https://github.com/MateusDevZip/tap-tap-loot-br/releases
2. Clique em **"Create a new release"** (botão verde)

### Passo 2: Preencher informações

**Tag version:**
```
v1.1.0
```

**Release title:**
```
🎮 AutoTapTapLoot v1.1.0 - Bilingual Release
```

**Description:** (Copie e cole)
```
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
- `AutoTapTapLoot_v1.0.0.exe` — Main application
- `LEIA-ME.txt` — Quick start guide (Portuguese)
- Required .NET dependencies included

## 🚀 How to Use

1. **Download** `AutoTapTapLoot_v1.1.0.zip`
2. **Extract** to any folder
3. **Double-click** `AutoTapTapLoot_v1.0.0.exe`
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
```

### Passo 3: Fazer upload do arquivo

1. Procure por: **"Attach binaries by dropping them here or selecting them"**
2. Clique e selecione: `AutoTapTapLoot_v1.1.0.zip`
   - O arquivo está em: `C:\Users\Pc Mateus\Desktop\AutoTapTapLoot\`

### Passo 4: Publicar
1. Clique em **"Publish release"**
2. Pronto! 🎉

---

## 🔧 Opção 2: Script PowerShell (Automático)

Se preferir automatizar, use o script `criar-release.ps1`:

### Pré-requisito: Gerar Token do GitHub

1. Acesse: https://github.com/settings/tokens
2. Clique em **"Generate new token (classic)"**
3. No campo **"Note"**, digite: `GitHub Release Creator`
4. Marque apenas:
   - ✅ `repo` (acesso completo a repositórios)
   - ✅ `public_repo` (acesso a repositórios públicos)
5. Clique em **"Generate token"**
6. **Copie o token** (aparece apenas uma vez!)

### Executar Script

Abra PowerShell no diretório do projeto e execute:

```powershell
# Defina o token como variável de ambiente
$env:GITHUB_TOKEN='seu_token_aqui'

# Execute o script
.\criar-release.ps1
```

Ou em uma única linha:

```powershell
$env:GITHUB_TOKEN='seu_token_aqui'; .\criar-release.ps1
```

### Resultado

Se tudo funcionar, você verá:

```
✅ Release criada com sucesso!
✅ Arquivo enviado com sucesso!

🎉 Link da release:
   https://github.com/MateusDevZip/tap-tap-loot-br/releases/tag/v1.1.0
```

---

## 📦 Arquivo de Release

O arquivo `AutoTapTapLoot_v1.1.0.zip` contém:

```
AutoTapTapLoot_v1.1.0/
├── AutoTapTapLoot_v1.0.0.exe ← EXECUTÁVEL
├── AutoTapTapLoot_v1.0.0.dll
├── Newtonsoft.Json.dll
├── LEIA-ME.txt
├── *.json (configurações do .NET)
└── *.pdb (símbolos de debug, opcional)
```

**Tamanho:** ~354 KB (comprimido)

---

## ✅ Checklist

Antes de publicar, verifique:

- [ ] Arquivo ZIP existe: `AutoTapTapLoot_v1.1.0.zip`
- [ ] Tag é: `v1.1.0`
- [ ] Título é: `🎮 AutoTapTapLoot v1.1.0 - Bilingual Release`
- [ ] Descrição tem informações sobre PT/EN
- [ ] ZIP está marcado para download
- [ ] Versão anterior (se houver) está como "Latest Release"

---

## 🎯 Resultado Final

Após publicar, o repositório terá:

```
📌 Latest Release
   ↓
   🎮 AutoTapTapLoot v1.1.0
   └─ 📥 AutoTapTapLoot_v1.1.0.zip (354 KB)
```

Usuários podem clicar em **"Download ZIP"** e começar a usar! 🚀

---

**Qualquer dúvida, consulte:** 
- GitHub Web: https://docs.github.com/en/repositories/releasing-projects-on-github/managing-releases
- PowerShell API: https://docs.github.com/en/rest/releases/releases

