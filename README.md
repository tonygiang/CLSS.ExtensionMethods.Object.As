# CLSS.ExtensionMethods.Object.As

### Problem

In order to make a cast during a functional-style call chain, you can do it in 2 ways:

```csharp
using Newtonsoft.Json.Linq;

var targetProperties1 = ((JObject)((JArray)JToken.Parse(rawJSON)
  .SelectToken(jsonPath))
  .Last)
  .Properties();
var targetProperties2 = ((JToken.Parse(rawJSON)
  .SelectToken(jsonPath) as JArray)
  .Last as JObject)
  .Properties();
```

Both syntaxes break the flow of reading code from left to right and make logical errors from one missing or one extra parenthesis easy to miss. Typical C# programmers are not used to parse parenthesis pairs as Lisp programmers are.

### Solution

This package provides `As<T>` extension method as a functional equivalence to the `as` syntax to maintain consistent LTR reading flow and be friendly to the functional syntax. The above piece of code can be rewritten as follows:

```csharp
using CLSS.
using Newtonsoft.Json.Linq;

var targetProperties = JToken.Parse(rawJSON)
  .SelectToken(jsonPath).As<JArray>()
  .Last.As<JObject>()
  .Properties();
```

Due to the limitation in the type system of C#, `As<T>` is limited to using reference types. Passing a value type to the type parameter will cause a compilation error. Note that this limitation is strictly for the type parameter. You can still use value types as the caller of `As<T>`.

```csharp
using CLSS;

int number = 5;
var numberAsConvertible = number.As<IConvertible>();
```

`As<T>` has some boxing overhead. It should be used if said overhead is negligible in your code path and comprehensibility is your priority.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).