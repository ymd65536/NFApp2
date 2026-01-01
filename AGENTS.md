
## M5StackをnanoFrameworkで使うための指示

- ターゲットを確認する
- デプロイ

### ターゲットを認識する

nanoff利用できるターゲットの一覧を表示するには、以下のコマンドを実行します。

```
nanoff --listtargets
```

## デプロイ

M5Stackのデプロイには、nanoffコマンドを使用します。以下のコマンド例では、M5Stack Core2に対して、指定したバイナリイメージをデプロイしています。

serialportオプションには、接続されているM5Stackデバイスのシリアルポートを指定します。macOSでは通常、/dev/cu.*の形式で指定します。
Windowsの場合はCOMポート番号を指定します。

ポート番号がわからない場合は、以下のコマンドで接続されているシリアルデバイスの一覧を表示できます。

macOSの場合:

```bash
ls /dev/cu.*
```

`--target`で指定するものがわからない場合はデプロイを行う前に聞いてください。

macOSでM5Stack Core2にデプロイする例:

```bash
nanoff --target M5Core --serialport /dev/cu.usbserial-5A490990381 --baud 115200 --masserase --deploy --image /Users/ymd65536/Desktop/NFApp2/bin/Debug/NFApp2.bin
```

Fireにデプロイする場合は、`--target M5Core2`で良いです。
