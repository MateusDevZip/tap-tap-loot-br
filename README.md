![Windows](https://img.shields.io/badge/platform-windows-lightgrey)
![Versão Mais Recente](https://img.shields.io/github/v/release/jordanxion/autotaptaploot)
![Downloads](https://img.shields.io/github/downloads/jordanxion/autotaptaploot/total)
![Estrelas](https://img.shields.io/github/stars/jordanxion/autotaptaploot)
# AutoTapTapLoot
Ferramenta para [Tap Tap Loot](https://store.steampowered.com/app/3959890/Tap_Tap_Loot/) que se conecta através da mesma interface de pipes utilizada por **The Farmer Was Replaced** e **Bongo Cat**, fornecendo auto-tap dentro do jogo (sem interferir em outros programas) e amplificadores de atributos.

![Imagem de pré-visualização](AutoTapTapLoot_v1.0.0.png)
## Funcionalidades
- **Auto Tap** — envia pacotes de tap para o jogo em uma taxa configurável (baseado em *The Farmer Was Replaced*)
- **Amplificadores de Atributos** — multiplicadores percentuais para todos os atributos do jogo (baseado em *Bongo Cat*)

## Observações
Os valores que você pode definir são efetivamente ilimitados, muito maiores do que o que outros jogos normalmente fornecem. Defina os valores como achar apropriado. Valores extremos podem quebrar o jogo! Considere fazer backup de seu save.

## Requisitos
- Tap Tap Loot em execução
- Bongo Cat e The Farmer Was Replaced ***não*** podem estar em execução. Isso usa os mesmos pipes e causará um conflito.

## Como Usar
1. Baixe a versão mais recente em [GitHub releases](../../releases)
2. Execute `AutoTapTapLoot.exe`
3. Ambos os pipes devem mostrar como **Conectado** (caso contrário, verifique os requisitos)
4. Ajuste as configurações e aproveite

## Configurações
| Configuração | Descrição |
|---|---|
| Pacotes Por Segundo | Quantos pacotes de tap enviar por segundo. O jogo só recebe pacotes de tempos em tempos, mais de 10-11 não faz nada, deixe o padrão (15) ou menor |
| Taps Por Pacote | Quantos taps cada pacote representa, este é o número principal que você deseja ajustar |
| Configurações de Amplificadores | O valor é um **multiplicador percentual** adicionado aos seus atributos do jogo, onde 1 = +100% (efetivamente 2x). Pressionar aplicar apenas atualiza os amplificadores que estão marcados. Pressionar padrão envia um valor de todos os zeros para o jogo, efetivamente resetando-os para sem amplificação. |

# Projeto Relacionado - Edite seus arquivos de save
Confira aqui: [JordanXion/TapTapLootDecryptSaves](https://github.com/JordanXion/TapTapLootDecryptSaves)
