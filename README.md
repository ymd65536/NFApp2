
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

## シリアルポートの指定

`--serialport` オプションでシリアルポートを指定します。Windows では COM ポート番号を指定しますが、macOS で
使うのは USB 接続のデバイス名で、macOS では通常 cu.* を指定します。

USB デバイスの一覧を表示するには、以下のコマンドを実行します。usbserial などの名前が付いたデバイスを探してください。

```bash
ls /dev/cu.*
```

