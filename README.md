# NUte

Pronounced 'Newt', this library is a set of utility and helper methods for common coding tasks. This includes runtime validations, enum metadata extensions and string formatting.

## Validation

The validation aspects of the library provides runtime checks for both method arguments and object state.

### Arguments

With arguments, a lambda expression needs to be provided that returns the argument to be validated. The argument name is then resolved from the expression, therefore eliminating the need to pass any strings.

```
public User CreateUser(string username)
{
  Argument.NotNullOrWhiteSpace(() => username);
  
  ...
}
```

Due to the nature of method arguments, nested object properties are not supported. Instead, a ```Argument.Verify()``` method has been implemented where boolean checks can be performed.

```
public void UpdateUser(User user)
{
  Argument.Verify(() => user.Id > 0, "Invalid user ID");
  
  ...
}
```

For null checks an ```ArgumentNullException``` is thrown. For all others, such as whitespace validation, an ```ArgumentException``` is thrown.

### Object State

Much like argument validation, the verify methods can be used to confirm the state of a given object. In this case however, an ```InvalidOperationException``` is thrown.

```
public void Add(string name)
{
  ...
  
  Verify.NotNull(() => dictionary, "No dictionary available");
  
  ...
}
```

Similarly, ```Verify.IsTrue()``` and ```Verify.IsFalse()``` methods are provided for boolean checks.

## Enum Metadata

On occasions it can be useful to extend an enum definition to include something more descriptive or even an alternative value. A particular scenario might be the use of a string value in a URL query string and using ```.ToString()``` on the enum value just isn't enough.

```
public enum Filter
{
  [EnumData("name")]
  Name = 17,
  
  [EnumData("dob")]
  DateOfBirth = 29
}

pubilc string GetQueryFilters(Filter filter)
{
  var queryFilters = new List<string>();
  var filterValue = typeof(Filter).GetEnumData(filter);
  
  queryFilters.Add(filterValue);
  
  ...
}
```

An enum value can also be resolved using it's associated data value.

```
pubilc Filter? GetFilter(string queryValue)
{
  return typeof(Filter).GetEnumFromData(queryValue);
}
```

## Others

For convenience, some additional helper methods are available. These include:

* Lower case conversion for boolean values.
* String equality validation.
* String formatting using anonymous object properties and dictionary values.

