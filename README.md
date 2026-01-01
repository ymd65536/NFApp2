
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

## ビルド

```bash
msbuild NFApp2.sln -p:platform="Any CPU" /p:NanoFrameworkProjectSystemPath=/Users/ymd65536/.vscode/extensions/nanoframework.vscode-nanoframework-1.0.185/dist/utils/nanoFramework/v1.0/ -p:NFMDP_PE_Verbose=false -p:NFMDP_PE_VerboseMinimize=false /p:OutDir=OutputDir/ /p:Configuration=Debug /p:GenerateDeploymentImage=true /v:m
```

## デプロイ

```bash
nanoff --target M5Core2 --serialport /dev/cu.usbserial-5A490990381 --update --deploy --image /Users/ymd65536/Desktop/NFApp2/bin/Debug/NFApp2.bin
```
