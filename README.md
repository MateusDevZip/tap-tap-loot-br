![Windows](https://img.shields.io/badge/platform-windows-lightgrey)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Linguagem](https://img.shields.io/badge/linguagem-PT%2FEN-brightgreen)

# AutoTapTapLoot 🎮

**English** | [Português](#português)

## Overview
A Windows Forms application that provides auto-tap and stat buff features for [Tap Tap Loot](https://store.steampowered.com/app/3959890/Tap_Tap_Loot/) via the same pipe interface used by **The Farmer Was Replaced** and **Bongo Cat**.

### Features
- ⚡ **Auto Tap** — Sends tap packets to the game at a configurable rate
- 📊 **Stat Buffs** — Percentage-based multipliers for all in-game stats
- 🌐 **Bilingual UI** — Switch between Portuguese (PT-BR) and English in real-time without restart
- 💾 **Persistent Settings** — All preferences saved to `settings.json`
- 🎨 **Dark Theme** — Built-in dark mode for comfortable use

### System Requirements
- Windows 10 or later
- Tap Tap Loot running
- .NET 8.0 Runtime (or higher)
- **Bongo Cat** and **The Farmer Was Replaced** must NOT be running (they share the same pipes)

### Installation
1. Download the latest version from [Releases](../../releases)
2. Extract the files
3. Run `AutoTapTapLoot_v1.0.0.exe`
4. Both pipes should show as **Connected** (check requirements if not)

### Configuration
| Setting | Description |
|---------|-------------|
| **Packets Per Second** | How many tap packets to send per second (default: 15, recommended ≤11) |
| **Taps Per Packet** | Number of taps each packet represents (adjust this to increase taps) |
| **Language** | Select between Português (PT-BR) or English |
| **Buff Settings** | Percentage multiplier added to game stats (1 = +100%, effectively 2x) |

> ⚠️ **Warning**: Extreme buff values may break the game. Consider backing up your save file.

### Development
Built with:
- C# / .NET 8.0
- Windows Forms
- Newtonsoft.Json for configuration

**Build:**
```bash
dotnet build
dotnet publish -c Release
```

### Attribution
- Original concept and pipes interface from **The Farmer Was Replaced**
- Stat buff feature inspired by **Bongo Cat**
- Portuguese translation and bilingual UI by the community

### License
This project is provided as-is for educational and personal use.

---

## Português

## Visão Geral
Uma aplicação Windows Forms que fornece recursos de auto-tap e amplificadores de atributos para [Tap Tap Loot](https://store.steampowered.com/app/3959890/Tap_Tap_Loot/) através da mesma interface de pipes usada por **The Farmer Was Replaced** e **Bongo Cat**.

### Funcionalidades
- ⚡ **Auto Tap** — Envia pacotes de tap para o jogo em uma taxa configurável
- 📊 **Amplificadores de Atributos** — Multiplicadores percentuais para todos os atributos do jogo
- 🌐 **Interface Bilíngue** — Alterne entre Português (PT-BR) e Inglês em tempo real sem reiniciar
- 💾 **Configurações Persistentes** — Todas as preferências salvas em `settings.json`
- 🎨 **Tema Escuro** — Modo escuro integrado para uso confortável

### Requisitos do Sistema
- Windows 10 ou superior
- Tap Tap Loot em execução
- .NET 8.0 Runtime (ou superior)
- **Bongo Cat** e **The Farmer Was Replaced** NÃO podem estar em execução (compartilham os mesmos pipes)

### Instalação
1. Baixe a versão mais recente em [Releases](../../releases)
2. Extraia os arquivos
3. Execute `AutoTapTapLoot_v1.0.0.exe`
4. Ambos os pipes devem mostrar como **Conectado** (verifique os requisitos se não)

### Configuração
| Configuração | Descrição |
|---|---|
| **Pacotes Por Segundo** | Quantos pacotes de tap enviar por segundo (padrão: 15, recomendado ≤11) |
| **Taps Por Pacote** | Quantidade de taps que cada pacote representa (ajuste para aumentar taps) |
| **Linguagem** | Selecione entre Português (PT-BR) ou English |
| **Amplificadores** | Multiplicador percentual adicionado aos atributos do jogo (1 = +100%, efetivamente 2x) |

> ⚠️ **Aviso**: Valores extremos de amplificadores podem quebrar o jogo. Considere fazer backup do seu save.

### Desenvolvimento
Construído com:
- C# / .NET 8.0
- Windows Forms
- Newtonsoft.Json para configuração

**Compilar:**
```bash
dotnet build
dotnet publish -c Release
```

### Créditos
- Conceito original e interface de pipes de **The Farmer Was Replaced**
- Funcionalidade de amplificadores inspirada em **Bongo Cat**
- Tradução para português e interface bilíngue pela comunidade

### Licença
Este projeto é fornecido como está para uso educacional e pessoal.

---

**Made with ❤️ by the community**
