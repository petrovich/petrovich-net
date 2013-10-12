NPetrovich
==========

NPetrovich is C#/.NET port of [Petrovich](https://github.com/rocsci/petrovich) ruby gem.

## Installation

Just reference NPetrovich dll to your project.
You also need to copy `rules.yml` to folder with NPetrovich dll.

PS. Nuget package coming soon

## Building

Use Visual Studio 2012 or newer to build solution.
`Allow Nuget to download missing packages` option should be turned on in package manager.

## Usage

Basic usage:

```csharp
var petrovich = new Petrovich()
	{
		FirstName = "Иван",
		LastName = "Иванов",
		MiddleName = "Иванович",
		Gender = Gender.Male
	};

// Inflect all properties
petrovich.InflectTo(Case.Dative);

System.Console.WriteLine(petrovich.FirstName); // Ивану
System.Console.WriteLine(petrovich.LastName); // Иванову
System.Console.WriteLine(petrovich.MiddleName); // Ивановичу

// Inflect each property
System.Console.WriteLine(petrovich.InflectFirstNameTo(Case.Genitive)) // Ивана
System.Console.WriteLine(petrovich.InflectLastNameTo(Case.Genitive)) // Иванова
System.Console.WriteLine(petrovich.InflectMiddleNameTo(Case.Genitive)) // Ивановича
```

You can use automatic gender detection based on middle name:

```csharp
var petrovich = new Petrovich()
    {
        FirstName = "Иван",
        LastName = "Иванов",
        MiddleName = "Иванович",
        AutoDetectGender = true
    };

petrovich.InflectTo(Case.Dative);
System.Console.WriteLine(petrovich.Gender); // Male
```

Also you can use `GenderUtils` to detect gender based on middle name:

```csharp
Gender gender = GenderUtils.Detect("Иванович");
System.Console.WriteLine(gender); // Male
```

## To be done

* Add documentation
* Add comments to the code
* Nuget package
* Add tests
* Add different rules format support
* Do some refactorings
