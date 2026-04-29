# 📥 Como Publicar a Release v1.1.0

## 🎯 Arquivos para Upload

A release deve conter **3 arquivos**:

```
AutoTapTapLoot_v1.0.0.exe ........... 140 KB ← EXECUTÁVEL PRINCIPAL
Newtonsoft.Json.dll ................. 707 KB ← DEPENDÊNCIA NECESSÁRIA
LEIA-ME.txt .......................... 3 KB ← INSTRUÇÕES
```

**Total: ~850 KB**

---

## ✨ Passo a Passo: Criar a Release

### 1️⃣ Abrir a página de novas releases

Acesse: **https://github.com/MateusDevZip/tap-tap-loot-br/releases/new**

### 2️⃣ Preencher as informações

#### **Tag version:**
```
v1.1.0
```

#### **Release title:**
```
🎮 AutoTapTapLoot v1.1.0 - Bilingual Release
```

#### **Description:** (Copie e cole)
```markdown
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

## 📥 How to Use

1. Download both files:
   - `AutoTapTapLoot_v1.0.0.exe`
   - `Newtonsoft.Json.dll`

2. Place them in the **same folder**

3. Double-click `AutoTapTapLoot_v1.0.0.exe`

4. Select your language (Português or English)

5. Enjoy! 🎮

## ⚠️ Important Requirements

- **Tap Tap Loot must be running**
- **Bongo Cat** and **The Farmer Was Replaced** must NOT be running
- Windows 10 or later
- .NET 8.0 Runtime (usually pre-installed)

## 🐛 Troubleshooting

**"Failed to connect to pipes"**
- Ensure Tap Tap Loot is running
- Close other mods (Bongo Cat, The Farmer Was Replaced)
- Restart the game

**.NET Runtime not found**
- Download: https://dotnet.microsoft.com/download

**Files don't run**
- Make sure both `.exe` and `.dll` are in the same folder!

## 📝 Notes

- Read `LEIA-ME.txt` for Portuguese instructions
- Your settings are saved in `settings.json`
- Backup your game save before using extreme buffs!

---

**Enjoy modifying Tap Tap Loot!** 🚀
```

### 3️⃣ Upload dos arquivos

Na seção **"Attach binaries by dropping them here or selecting them"**:

1. Clique e selecione: `AutoTapTapLoot_v1.0.0.exe`
2. Clique novamente e selecione: `Newtonsoft.Json.dll`
3. Clique novamente e selecione: `LEIA-ME.txt`

**Ou arraste os arquivos** da pasta `app-release/` diretamente para a área de upload.

### 4️⃣ Publicar

Clique em **"Publish release"** 🚀

---

## 📦 Estrutura dos Arquivos

```
Após download da release:
│
└─ Pasta (qualquer nome, ex: "AutoTapTapLoot")
   ├─ AutoTapTapLoot_v1.0.0.exe ← CLIQUE AQUI para executar
   ├─ Newtonsoft.Json.dll ← DEIXE NA MESMA PASTA
   └─ LEIA-ME.txt ← Instruções em português
```

### ⚠️ IMPORTANTE
Os **3 arquivos DEVEM estar na mesma pasta!** O `.exe` precisa do `.dll` para funcionar.

---

## ✅ Verificação Final

Antes de clicar "Publish release", verifique:

- [ ] Tag: `v1.1.0`
- [ ] Title: `🎮 AutoTapTapLoot v1.1.0 - Bilingual Release`
- [ ] Description com instruções
- [ ] 3 arquivos fazendo upload:
  - [ ] `AutoTapTapLoot_v1.0.0.exe` (140 KB)
  - [ ] `Newtonsoft.Json.dll` (707 KB)
  - [ ] `LEIA-ME.txt` (3 KB)

---

## 🎉 Resultado Final

Após publicar, qualquer pessoa pode:

```
1. Ir em: https://github.com/MateusDevZip/tap-tap-loot-br/releases
2. Ver a release v1.1.0 como "Latest"
3. Baixar os 3 arquivos
4. Executar o .exe
5. Aproveitar! 🎮
```

---

## 📊 Como Ficará na Release

```
Assets (3)

📄 AutoTapTapLoot_v1.0.0.exe (140 KB)
   └─ Click to download

📄 Newtonsoft.Json.dll (707 KB)
   └─ Click to download

📄 LEIA-ME.txt (3 KB)
   └─ Click to download
```

---

## 🆘 Dúvidas?

**"Preciso baixar os 3 arquivos?"**
> Sim! Coloque todos os 3 na mesma pasta.

**"E se eu tiver o arquivo antigo?"**
> Delete a pasta antiga e baixe os novos arquivos.

**"Posso alterar o nome dos arquivos?"**
> Não! O .exe precisa que o .dll tenha esse nome exato.

**"Funciona sem o .dll?"**
> Não. O .dll é uma dependência obrigatória.

---

**Está pronto para publicar!** ✨

Depois que publicar, a release aparecerá aqui:
👉 https://github.com/MateusDevZip/tap-tap-loot-br/releases

