# Array Collections

UdonSharpでは現状(ver1.1.1時点)で実装されていない、ListやDictionaryなどのコレクションのような操作（一部を除く）を、通常の配列変数で実行するUdonSharpのユーティリティクラスです。  
ListやDictionaryの他に、QueueやStackも用意しています。  
  
## 使用条件

UdonSharp v1.1.1 以降

## 使用方法

- `using ArrayCollections` を宣言します。
- 配列変数を定義します。
- 配列変数をref引数とし、`UList` `UDict` `UQueue` `UStack`の目的の用途のInitializeメソッドを呼び出します。（配列の初期化）
- 配列変数をref引数とし、各機能のメソッドを実行します。（各機能の詳細は[こちら](https://github.com/hoke946/ArrayCollections/blob/main/Packages/com.t-hoke.arraycollections/README.md)）
  
```
using UdonSharp;
using ArrayCollections;

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
        UDict.Initialize(ref keys,ref values);
        UDict.Add(ref keys, ref values, "k1", "abc");
    }
```

## 注意

おそらく、処理効率はそれほど優れていません。  
特に要素数が多くなるに従い、重くなる傾向にあります。  
（処理は一般的な配列コピーやループ検索が主です。）

## ライセンス

MIT Licenseで運用します。
当パッケージを組み込み、再配布することを許可します。
その際には当パッケージが組み込まれていることを記載することをお勧めします。
