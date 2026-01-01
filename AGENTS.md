
## M5StackをnanoFrameworkで使うための指示

- 前提
- ターゲットを確認する
- ブートローダの書き込み
- デプロイ

## 前提

- Fireにデプロイする場合は、`--target M5Core2`の指定が必要です

## ターゲットを認識する

nanoff利用できるターゲットの一覧を表示するには、以下のコマンドを実行して確認してください。

```bash
nanoff --listtargets
```

## ブートローダの書き込み

M5Stackデバイスに対応したブートローダを書き込むには、以下のコマンドを使用します。
書き込みの際は、デバイスが接続されているシリアルポートを指定する必要があります。
`ターゲットを認識する`セクションで確認したターゲット名を`--target`オプションに指定してください。

`[serialport]`には`nanoff --listports`で確認したシリアルポートを指定してください。

```bash
nanoff --update --target M5Core2 --fwversion 1.14.0.179 --serialport [serialport] --baud 115200 --masserase
```

## ビルド

```bash
msbuild NFApp2.sln -p:platform="Any CPU" /p:NanoFrameworkProjectSystemPath=/Users/ymd65536/.vscode/extensions/nanoframework.vscode-nanoframework-1.0.185/dist/utils/nanoFramework/v1.0/ -p:NFMDP_PE_Verbose=false -p:NFMDP_PE_VerboseMinimize=false /p:OutDir=OutputDir/ /p:Configuration=Debug /p:GenerateDeploymentImage=true /v:m
```

## デプロイ

M5Stackのデプロイには、nanoffコマンドを使用します。以下のコマンド例では、M5Stack Core2に対して、指定したバイナリイメージをデプロイしています。

serialportオプションには、接続されているM5Stackデバイスのシリアルポートを指定します。macOSでは通常、/dev/cu.*の形式で指定します。
Windowsの場合はCOMポート番号を指定します。

ポート番号がわからない場合は、以下のコマンドで接続されているシリアルデバイスの一覧を表示できます。

```bash
nanoff --listserialports
```

`--target`で指定するものがわからない場合はデプロイを行う前に聞いてください。

macOSでM5Stack Core2にデプロイする例:

```bash
nanoff --target M5Core --serialport /dev/cu.usbserial-5A490990381 --baud 115200 --masserase --deploy --image /Users/ymd65536/Desktop/NFApp2/bin/Debug/NFApp2.bin
```
