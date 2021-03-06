# OneSix
ポケットモンスター　ダイヤモンド/パールバージョンの任意スクリプト実行(ASE)に必要なポケモンの準備を補助するツールです。
ASEの準備として、ボックス内にあずけたときにデータ末尾が0x16で終わるようなポケモンが必要となります。
このプログラムは、与えられたポケモンがそのようになるようなニックネームを出力します。

![window](https://i.imgur.com/3THzhUo.png)

## インストール
Releseのページから最新版のzipファイルをダウンロードし、適当な場所に展開してください。

## 使い方
PK4ファイルをOneSix.exeにドラッグ＆ドロップしてください。
コンソールが立ち上がり数秒で結果が表示されます。

PK4ファイルは第4世代のポケモンのデータファイルで、[PKHeX](https://projectpokemon.org/home/files/file/1-pkhex/)を使って書き出すことができます。

### PKHeXでPK4ファイルを書き出すときの注意
* "ニックネーム"にチェックをつけておいてください。
* なつき度が最大(255)のポケモンを使うことをおすすめします。(持ち運び中に変化することがあるので)

![Imgur](https://i.imgur.com/gQVdjwY.png)

* PK4ファイルを出力するには[ファイル]→[保存PKM]を選びます。ファイルの種類は "Decrypted PKM File (*.pk4)" を選択してください。

![img](https://i.imgur.com/SgaomOA.png[/img)

## 依存関係
OneSixは[PKHeX](https://github.com/kwsch/PKHeX)を利用しています。
