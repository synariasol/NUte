# NUte

Pronounced 'Newt', this library is a set of utility and helper methods for common coding tasks. This includes runtime validations, enum metadata extensions, string formatting and primitive object serialization.

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

Nested properties are supported, but will resolve to the property name instead of the argument name. Furthermore, an ```Argument.Verify()``` method has been implemented where boolean checks can be performed.

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

Alternatively, if you need to throw a specific exception there are some generic methods available. To use these, an object is required that defines the parameter values for the exception constructor.

```
public void Add(string name)
{
  ...
  
  Verify.NotNull<CustomException>(() => dictionary, new { message = "No dictionary available", name = name });
  
  ...
}
```

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

pubilc string GetQueryValue(Filter filter)
{
  return typeof(Filter).GetEnumData(filter);
}
```

An enum value can also be resolved using it's associated data value.

```
pubilc Filter? GetFilter(string queryValue)
{
  return typeof(Filter).GetEnumFromData<Filter>(queryValue);
}
```

## Object Dictionary

For times when you need a list of properties contained in an object, the ```.ToDictionary()``` object extension method can be used. As the name suggests, this method will return the object property names and values as a dictionary.

```
public IDictionary<string, object> GetProperties(string name)
{
  var data = new
  {
    id = 100,
    name = name
  };

  return data.ToDictionary();
}
```

## String Formatting

A set of extension methods are available that build upon string formatting so named tokens can be used as placeholders. The values for these placeholders can be defined either using an object or an ```IDictionary<string, string>```.

```
public string GetRoute(int id, SortOptions sort)
{
  var routePattern = "/users/{id}/{sort}";
  
  return routePattern.Format(new
  {
    id = id,
    sort = sort
  });
}
```

## Others

For convenience, some additional helper methods are available. These include:

* String equality validation.
* Lower case conversion for boolean values.

## Installation

You can either get the source code here on GitHub and build the assemblies yourself, or download them from [NuGet](https://www.nuget.org/packages/NUte/).


