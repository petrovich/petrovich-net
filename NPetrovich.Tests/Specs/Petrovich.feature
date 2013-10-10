Feature: Petrovich
	In order to have ability of case inflection
	Petrovich library
	Should inflect russian names correctly

Scenario: Inflect names
	Given I have list of names, genders and expected inflections
	| Name                 | Gender | Case          | Expected                   |
	| Иванов Иван Иванович | Male   | Genitive      | Иванова Ивана Ивановича    |
	| Иванов Иван Иванович | Male   | Dative        | Иванову Ивану Ивановичу    |
	| Иванов Иван Иванович | Male   | Accusative    | Иванова Ивана Ивановича    |
	| Иванов Иван Иванович | Male   | Instrumental  | Ивановым Иваном Ивановичем |
	| Иванов Иван Иванович | Male   | Prepositional | Иванове Иване Ивановиче    |
	When I try to inflect names
	Then the result should be correct
