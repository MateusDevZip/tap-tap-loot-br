# Como Compilar e Usar Localmente 🛠️

Este guia descreve como compilar o AutoTapTapLoot no seu computador.

## Pré-requisitos

- **Windows 10 ou superior**
- **.NET 8.0 SDK** ou superior
- **Git** (opcional, para clonar o repositório)
- Um editor de código (Visual Studio Code, Visual Studio, Rider, etc.)

### Instalando o .NET SDK

1. Visite https://dotnet.microsoft.com/download
2. Baixe o .NET 8.0 SDK (Windows)
3. Execute o instalador e siga as instruções
4. Verifique a instalação:
```bash
dotnet --version
```

## Clonando o Repositório

```bash
git clone https://github.com/MateusDevZip/tap-tap-loot-br.git
cd tap-tap-loot-br/AutoTapTapLoot
```

Ou baixe como ZIP:
1. Clique em `Code` → `Download ZIP`
2. Extraia o arquivo
3. Abra a pasta `AutoTapTapLoot`

## Compilando

### Opção 1: Via Terminal/Linha de Comando

```bash
# Restaurar dependências
dotnet restore

# Compilar (Debug)
dotnet build

# Compilar com otimizações (Release)
dotnet build -c Release
```

### Opção 2: Via Visual Studio Code

1. Abra a pasta do projeto
2. Instale a extensão "C#" (pela Microsoft)
3. Clique em "Run" ou pressione `F5`

### Opção 3: Via Visual Studio

1. Abra o arquivo `AutoTapTapLoot.sln`
2. Menu: `Build` → `Build Solution` (ou `Ctrl+Shift+B`)
3. Pressione `F5` para executar

## Executando

### Após Compilar (Debug)
```bash
dotnet run
```

### Usando o Executável Compilado
O executável estará em:
```
bin/Debug/net8.0-windows/AutoTapTapLoot_v1.0.0.exe
```
ou para Release:
```
bin/Release/net8.0-windows/AutoTapTapLoot_v1.0.0.exe
```

## Publicando (Distribuível)

Para criar uma versão standalone:

```bash
dotnet publish -c Release -o publish
```

Isto criará uma pasta `publish/` com todos os arquivos necessários. Você pode comprimir e distribuir.

## Solução de Problemas

### Erro: "SDK .NET 8.0 não encontrado"
```bash
dotnet --list-sdks
```
Se não aparecer 8.0, baixe em https://dotnet.microsoft.com/download

### Erro: "Arquivo de projeto não encontrado"
Certifique-se de estar no diretório correto:
```bash
cd AutoTapTapLoot  # Entre na pasta do projeto
dotnet build
```

### Erro de Compilação com Dependências
```bash
dotnet restore --no-cache
dotnet clean
dotnet build
```

### A aplicação não conecta aos pipes
- Certifique-se de que **Tap Tap Loot está rodando**
- Verifique se **Bongo Cat** ou **The Farmer Was Replaced** não estão rodando
- Tente reiniciar o jogo

## Desenvolvimento

### Estrutura do Projeto
```
AutoTapTapLoot/
├── Program.cs           # Entrada da aplicação
├── Form1.cs            # Lógica principal + Localization
├── Form1.Designer.cs   # Interface gráfica
├── Form1.resx          # Recursos do formulário
└── AutoTapTapLoot.csproj  # Configuração do projeto
```

### Estrutura de Classes Principais

**Form1.cs:**
- `Localization` — Classe estática com dicionários PT/EN
- `AppSettings` — Classe para serializar configurações
- `SetLabelStatus()` — Atualiza status com cor
- `ApplyLanguage()` — Aplica a linguagem selecionada
- `StartTapPipeWorker()` — Thread para comunicação com jogo
- `StartBuffPipeWorker()` — Thread para amplificadores

## Customizações Comuns

### Adicionar um Novo Idioma

1. Abra `Form1.cs`
2. Adicione um novo dicionário em `Localization`:
```csharp
public static readonly Dictionary<string, string> ES = new()
{
    ["PacketsPerSecond"] = "Paquetes por segundo",
    // ... mais traduções
};
```

3. Atualize a seleção no ComboBox do Designer
4. Modifique `ApplyLanguage()` para incluir o novo idioma

### Mudar a Taxa Padrão de Packets

No `Form1.Designer.cs`, procure por:
```csharp
numericUpDownPacketsPerSecond.Value = new decimal(new int[] { 15, 0, 0, 0 });
```
Altere o `15` para o valor desejado.

### Modificar a Cores do Tema Escuro

Em `Form1.cs`, procure por:
```csharp
private static readonly Color DarkBackground = Color.FromArgb(30, 30, 30);
private static readonly Color DarkControl    = Color.FromArgb(50, 50, 50);
```
Altere os valores RGB conforme desejado.

## Dúvidas?

Crie uma issue no GitHub ou consulte a documentação oficial do .NET:
https://docs.microsoft.com/dotnet/

---

**Happy coding!** 🚀
