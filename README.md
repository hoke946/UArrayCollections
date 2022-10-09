# UArrayCollections

UdonSharpでは現状(ver1.1.1時点)で実装されていない、ListやDictionaryなどのコレクションのような操作を、通常の配列変数で実現するUdonSharpのユーティリティクラスです。  
ListやDictionaryの他に、QueueやStackも用意しています。  
  
## 使用条件

UdonSharp v1.1.1 以降

## ダウンロード
  
[Releasesページ](https://github.com/hoke946/UArrayCollections/releases)、または、[こちらのページ](https://hoke946.github.io/UArrayCollections/)から
zipファイル、またはUnityPackageをダウンロードしてください。 

## 使用方法

- `using UArrayCollections` を宣言します。
- 配列変数を定義します。
- 配列変数を引数とし、Initializeメソッドを呼び出します。（配列の初期化）
- 配列変数を引数とし、各機能のメソッドを実行します。（メソッド詳細は[こちら](https://github.com/hoke946/ArrayCollections/blob/main/Packages/com.t-hoke.uarraycollections/Methods.md)）
  
```
using UdonSharp;
using UArrayCollections;

public class UseArrayCollections : UdonSharpBehaviour
{
    string[] values;

    void AnyAction()
    {
        UList.Initialize(ref values);
        UList.Add(ref values, "abc");
    }
}
```
  
Dictionaryの場合、`Key`と`Value`のために2つの配列変数を使用します。  

```
    string[] keys;
    string[] values;

    void AnyAction()
    {
        UDict.Initialize(ref keys, ref values);
        UDict.Add(ref keys, ref values, "k1", "abc");
        UDict.Add(ref keys, ref values, "k2", "def");
        string k1val = UDict.GetValue(keys, values, "k1");  // k1val = "abc"
    }
```

## 注意

処理は一般的な配列コピーやループ検索が主です。  
処理効率は特別に優れているわけではありません。  
特に配列の要素数が多くなるに従い、重くなる傾向にあります。

## ライセンス

MIT Licenseで運用します。  
当パッケージを組み込み、再配布することを許可します。  
その際には当パッケージが組み込まれていることを記載しておくことをお勧めします。
