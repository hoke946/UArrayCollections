# UList 
Listの機能を提供するクラスです。  
引数の`array`にはListとして運用する配列変数を設定してください。

## 操作メソッド

### UList.Initialize(ref T[] `array`)
配列`array`を初期化し、要素数ゼロの配列とする。

### UList.Add<T>(ref T[] `array`, T `value`)
配列`array`の末尾に要素`value`を追加する。

### UList.AddRange<T>(ref T[] `array`, T[] `values`)
配列`array`の末尾に別の配列`values`の要素を追加する。

### UList.Insert<T>(ref T[] `array`, int `index`, T `value`)
配列`array`の`index`の位置に要素`value`を挿入する。
- 必要条件：`index`が0以上、かつ現要素数以下

### UList.InsertRange<T>(ref T[] `array`, int `index`, T[] `values`)
配列`array`の`index`の位置に別の配列`values`の要素を挿入する。
- 必要条件：`index`が0以上、かつ現要素数未満

### UList.RemoveAt<T>(ref T[] `array`, int `index`)
配列`array`の`index`の位置の要素を削除する。配列の要素数はその分減少する。
- 必要条件：`index`が0以上、かつ現要素数未満

### UList.Remove<T>(ref T[] `array`, T `value`)
配列`array`を検索し、`value`に一致する最初の要素を削除する。配列の要素数はその分減少する。

### UList.RemoveAll<T>(ref T[] `array`, T `value`)
配列`array`を検索し、`value`に一致する全ての要素を削除する。配列の要素数はその分減少する。

### UList.RemoveRange<T>(ref T[] `array`, int `index`, int `count`)
配列`array`の`index`の位置から`count`数の要素を削除する。配列の要素数はその分減少する。
- 必要条件①：`index`が0以上、かつ現要素数未満
- 必要条件②：`count`が0以上

### UList.Resize<T>(ref T[] `array`, int `length`)
配列`array`の要素数を`length`にする。
- 必要条件：`length`が0以上

### UList.Reverse<T>(ref T[] `array`)
配列`array`の要素を反転させる。

## 取得メソッド

### int UList.IndexOf<T>(T[] `array`, T `value`)
配列`array`を検索し、`value`に一致する最初の要素のインデックス番号を返す。一致する要素がない場合は-1を返す。

### int UList.IndexOf<T>(T[] `array`, T `value`, int `start`)
配列`array`を`start`の位置から検索し、`value`に一致する最初の要素のインデックス番号を返す。一致する要素がない場合は-1を返す。

### int UList.LastIndexOf<T>(T[] `array`, T `value`)
配列`array`を後方検索し、`value`に一致する最初の要素のインデックス番号を返す。一致する要素がない場合は-1を返す。

### int UList.LastIndexOf<T>(T[] `array`, T `value`, int `start`)
配列`array`を`start`の位置から後方検索し、`value`に一致する最初の要素のインデックス番号を返す。一致する要素がない場合は-1を返す。

### bool UList.Contains<T>(T[] array, T value)
配列`array`に`value`の要素を含んでいれば`true`、含んでいなければ`false`を返す。

### T[] GetRange<T>(T[] `array`, int `index`, int `count`)
配列`array`の`index`の位置から`count`数の要素を取得する。
- 必要条件①：`index`が0以上、かつ現要素数未満
- 必要条件②：`count`が0以上


# UDict 
Dictionaryの機能を提供するクラスです。  
引数の`key`と`value`にはDictionaryとして運用する配列変数を設定してください。  
`key`と`value`は同じインデックス番号で対となり、要素数は必ず一致させる必要があります。  

## 操作メソッド

### UDict.Initialize<TKey, TValue>(ref TKey[] `keyArray`, ref TValue[] `valueArray`)
配列`keyArray`と`valueArray`を初期化し、要素数ゼロの配列とする。

### UDict.Add<TKey, TValue>(ref TKey[] `keyArray`, ref TValue[] `valueArray`, TKey `key`, TValue `value`)
配列`keyArray`と`valueArray`に、要素`key`と`value`を対で追加する。ただし、同じ`key`が既に存在する場合は追加されない。

### UDict.Remove<TKey, TValue>(ref TKey[] `keyArray`, ref TValue[] `valueArray`, TKey `key`)
配列`keyArray`の`key`の要素と、その対となる配列`valueArray`の要素を削除する。

## 取得メソッド

### TValue UDict.GetValue<TKey, TValue>(TKey[] `keyArray`, TValue[] `valueArray`, TKey `key`)
`keyArray`を検索し、`key`の対となる配列`valueArray`の要素を返す。


# UQueue
Queueの機能を提供するクラスです。  
引数の`array`にはQueueとして運用する配列変数を設定してください。

## 操作メソッド

### UQueue.Initialize(ref T[] `array`)
配列`array`を初期化し、要素数ゼロの配列とする。

### UQueue.Enqueue<T>(ref T[] `array`, T `value`)
配列`array`の末尾に要素`value`を追加する。

## 操作／取得メソッド

### T UQueue.Dequeue<T>(ref T[] `array`)
配列`array`の先頭の要素を削除し、返す。ただし、空の場合はその型のデフォルト値を返す。

## 取得メソッド

### T UQueue.Peek<T>(T[] `array`)
配列`array`の先頭の要素を返す。ただし、空の場合はその型のデフォルト値を返す。


# UStack
Stackの機能を提供するクラスです。  
引数の`array`にはStackとして運用する配列変数を設定してください。

## 操作メソッド

### UStack.Initialize(ref T[] `array`)
配列`array`を初期化し、要素数ゼロの配列とする。

### UStack.Push<T>(ref T[] `array`, T `value`)
配列`array`の先頭に要素`value`を追加する。

## 操作／取得メソッド

### T UStack.Pop<T>(ref T[] `array`)
配列`array`の先頭の要素を削除し、返す。ただし、空の場合はその型のデフォルト値を返す。

## 取得メソッド

### T UStack.Peek<T>(T[] `array`)
配列`array`の先頭の要素を返す。ただし、空の場合はその型のデフォルト値を返す。
