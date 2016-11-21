![Petrovich](petrovich.png) ﻿NPetrovich
==========

NPetrovich is library which inflects Russian names to given grammatical case. It supports first names, last names and middle names inflections.

NPetrovich is C#/.NET implementation of [Petrovich](https://github.com/rocsci/petrovich) ruby gem.

[![Build status](https://ci.appveyor.com/api/projects/status/ieqcivsb3cxghx2a)](https://ci.appveyor.com/project/VitaliFokin/petrovich-net)

## Installation

NuGet

```
PM> Install-Package NPetrovich
```

Manual

Just reference NPetrovich dll to your project.

## Building

Run `psake.ps1` script with Powershell to build solution. You can find output binaries in the `bin` directory.

## Usage

### Basic usage

```csharp
var petrovich = new Petrovich()
	{
		FirstName = "Иван",
		LastName = "Иванов",
		MiddleName = "Иванович",
		Gender = Gender.Male
	};

// Inflect all properties
var inflected = petrovich.InflectTo(Case.Dative);

System.Console.WriteLine(inflected.FirstName); // Ивану
System.Console.WriteLine(inflected.LastName); // Иванову
System.Console.WriteLine(inflected.MiddleName); // Ивановичу

inflected = petrovich.InflectTo(Case.Instrumental);

System.Console.WriteLine(inflected.FirstName); // Иваном
System.Console.WriteLine(inflected.LastName); // Ивановым
System.Console.WriteLine(inflected.MiddleName); // Ивановичем

// Inflect each property
System.Console.WriteLine(petrovich.InflectFirstNameTo(Case.Genitive)); // Ивана
System.Console.WriteLine(petrovich.InflectLastNameTo(Case.Genitive)); // Иванова
System.Console.WriteLine(petrovich.InflectMiddleNameTo(Case.Genitive)); // Ивановича
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

### Advanced usage

You can use your own rules loader which implements IRulesLoader interface:

```csharp
IRulesLoader customLoader = new CustomRulesLoader();
var petrovich = new Petrovich(customLoader);
```

## Contributing

1. Fork it
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -am 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create new Pull Request

You can also support project by reporting issues or suggesting new features and improvements.

## To be done

* Add documentation
* Add comments to the code
