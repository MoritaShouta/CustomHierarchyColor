# CustomHierarchyColor

## 概要
Hierarchy上を見やすくするために作成しました。
どっかで見たことあったのですが、カスタイマイズできるように自作しました。
![Summary Image](IMG/summary.png)
## インストール
PackageManagerのURLで追加する
`https://github.com/MoritaShouta/CustomHierarchyColor.git`で追加できます。
![UMP Image](IMG/UMP-URL.png)
![UMP Image 2](IMG/UMP-InputURL.png)

それ以外に、`"com.figse.customhierarchycolor":"https://github.com/MoritaShouta/CustomHierarchyColor.git"`を直接`Packages/manifest.json`に追加しても大丈夫です。

## 使用方法
最初はこのようなエラーが出ます、これは設定ファイルが存在しないためエラーが発生します。
正常です。
![Start Image](IMG/start.png)

設定ファイルを追加します,`Create HierarchyColorSettings Asset`をクリックするとファイルが生成されます。
![Window Image](IMG/Window.png)
![Window Image2](IMG/Window2.png)

試しに`/// `の文字列が存在する名前を対象にします。この時`FontColor`のalpha値の変更を忘れないで下さい。
![Window Setting](IMG/WindowSetting.png)

このようになります
![Window Setting 2](IMG/WindowSetting2.png)

増やしてみます
![Window Setting 3](IMG/WindowSetting3.png)
![Window Setting 4](IMG/WindowSetting4.png)

## うまくいかない場合
上から優先度が決まります、なので一番上が優先度一番高いです。優先度をチェックしてください。
![Error Image](IMG/Error.png)

文字列検索で作成されているため、指定した文字列がどこに入ったとしても反応してしまいます。これは修正予定です。
![Error Image 2](IMG/Error2.png)