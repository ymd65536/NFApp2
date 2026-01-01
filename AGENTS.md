
## M5StackをnanoFrameworkで使うための指示

- 前提
- デバイス情報を確認する
- ターゲットを確認する
- ブートローダの書き込み
- デプロイ

## 前提

- 最初にデバイス情報を確認してください
  - ESP32_PSRAM_REV3というターゲット名が表示された場合は`M5Core2`として認識してください

## デバイス情報を確認する

`--serialport`は、接続されているM5Stackデバイスのシリアルポートを指定します。

```bash
nanoff --serialport COM6 --identifyfirmware
```

シリアルポート番号がわからない場合は、以下のコマンドで接続されているシリアルデバイスの一覧を表示できます。

```bash
nanoff --listports
```

## ターゲットを認識する

nanoff利用できるターゲットの一覧を表示するには、以下のコマンドを実行して確認してください。

```bash
nanoff --listtargets
```

## ブートローダの書き込み

M5Stackデバイスに対応したブートローダを書き込むには、以下のコマンドを使用します。
書き込みの際は、デバイスが接続されているシリアルポートを指定する必要があります。

デバイス情報を確認するセクションで確認したターゲット名を`--target`オプションに指定してください。

ターゲット名の一覧は`ターゲットを認識する`セクションを参照してください。

`[serialport]`には`nanoff --listports`で確認したシリアルポートを指定してください。

--fwversionはわからない場合は省略可能です。

```bash
nanoff --update --target M5Core2 --fwversion 1.14.0.179 --serialport [serialport] --baud 115200 --masserase
```

## ビルド

NanoFrameworkProjectSystemPathはextensionのパスに合わせて変更してください。

Windowsの場合は以下のコマンド例です。

```bash
$path = & "${env:ProgramFiles(x86)}\microsoft visual studio\installer\vswhere.exe" -products * -latest -prerelease -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\amd64\MSBuild.exe | select-object -first 1; nuget restore "c:/Users/Yamada/Desktop/NFApp2/NFApp2/NFApp2.sln"; & $path c:/Users/Yamada/Desktop/NFApp2/NFApp2/NFApp2.sln -p:platform="Any CPU" /p:NanoFrameworkProjectSystemPath=c:\Users\Yamada\.vscode\extensions\nanoframework.vscode-nanoframework-1.0.185/dist/utils\nanoFramework\v1.0\   -p:NFMDP_PE_Verbose=false -p:NFMDP_PE_VerboseMinimize=false -verbosity:minimal /p:OutDir=c:/Users/Yamada/Desktop/NFApp2/NFApp2/OutputDir/
```

以下のコマンドはmacOSでの例です。

```bash
msbuild NFApp2.sln -p:platform="Any CPU" /p:NanoFrameworkProjectSystemPath=/Users/ymd65536/.vscode/extensions/nanoframework.vscode-nanoframework-1.0.185/dist/utils/nanoFramework/v1.0/ -p:NFMDP_PE_Verbose=false -p:NFMDP_PE_VerboseMinimize=false /p:OutDir=OutputDir/ /p:Configuration=Debug /p:GenerateDeploymentImage=true /v:m
```

## デプロイ

M5Stackのデプロイには、nanoffコマンドを使用します。以下のコマンド例では、M5Stack Core2に対して、指定したバイナリイメージをデプロイしています。

serialportオプションには、接続されているM5Stackデバイスのシリアルポートを指定します。macOSでは通常、/dev/cu.*の形式で指定します。
Windowsの場合はCOMポート番号を指定します。

ポート番号がわからない場合は、以下のコマンドで接続されているシリアルデバイスの一覧を表示できます。

```bash
nanoff --listports
```

`--target`で指定するものがわからない場合はデバイス情報を確認するセクションを参照してください。

macOSでM5Stack Core2にデプロイする例:

```bash
nanoff --target M5Core --serialport /dev/cu.usbserial-5A490990381 --baud 115200 --masserase --deploy --image /Users/ymd65536/Desktop/NFApp2/bin/Debug/NFApp2.bin
```

WindowsでM5Stack Fireにデプロイする例:

```bash
nanoff --nanodevice --deploy --serialport COM6 --image c:/Users/Yamada/Desktop/NFApp2/NFApp2/bin/Debug/NFApp2.bin
```
