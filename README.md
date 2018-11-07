# Confused [![Build Status](https://ci.appveyor.com/api/projects/status/tv0bc7ilr1ygqroh?svg=true)](https://ci.appveyor.com/project/simwak/confused)

Confused is a simple library that parses .conf files (ini-style) into a easy readable dictionary.

```ini
[Sample]
HelloMessage = Hello World!
ACoolNumber = 42
AnArray = 4, 12, 14
```

```csharp
var conf = Parse.File("Sample.conf");

string helloMessage = conf["Sample"]["HelloMessage"];
int aCoolNumber = Parse.Value<int>(conf["Sample"]["ACoolNumber"]);
int[] anArray = Parse.Array<int>(conf["Sample"]["AnArray"]);
```
