
```bash
nanoff --target M5Core2 --update --serialport COM4
```

## macOSでM5Stackを使用する

mono-mdkをインストールします。

```bash
brew install mono-mdk
```

```bash
brew install mono
```

## PATH 追加

`export PATH="/Library/Frameworks/Mono.framework/Commands:$PATH"`を ~/.zshrc に追記

```bash
export PATH="/Library/Frameworks/Mono.framework/Commands:$PATH"
```
