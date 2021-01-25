# .NET Core Exercises

## Exercise 1 (LINQ)

Construction using class initializers:
```
var buddies = new List<Buddy> {
    new Buddy(1, "Sylvester", "UK"),
    new Buddy(7, "Bogdan", "Poland", 51000.00m),
    // ...
};
```

Select distinct countries:

```
var countries = buddies
    .Select(buddy => buddy.Country)
    .Distinct();
```

List materialization:

```
var countries = buddies
    .Select(buddy => buddy.Country)
    .ToList();
```

Aggregate (reduce structure)

```
var buddiesByCountry = buddies
    .Aggregate<Buddy, Dictionary<string, int>>(
        new Dictionary<string, int>(),
        (dict, buddy) =>
        {
            if (dict.ContainsKey(buddy.Country))
                dict[buddy.Country] += 1;
            else
                dict[buddy.Country] = 1;
            return dict;
        }
    );
```

Any:

```
var buddiesFromUK = buddiesAll.All(buddy => buddy.Country == "UK");
```
