# BookingSystem

## Beskrivning
Detta projekt är en individuell C#-implementation av **US-03 – Bevara befintliga bokningar** inom kursen Objektorienterad analys och design.

Syftet är att befintliga bokningar ska bevaras när ett utrustningsexemplar markeras som otillgängligt, exempelvis på grund av skada eller service.

## Funktionalitet
- Markera ett utrustningsexemplar som otillgängligt och ange en anledning.
- Hantera situationer där exemplaret inte finns eller redan är otillgängligt.
- Bevara befintliga bokningar utan att ändra deras uppgifter.

## Projektstruktur
- **Models:** EquipmentItem och Booking.
- **Repositories:** EquipmentRepository och BookingRepository.
- **Services:** EquipmentService.
- **Program.cs:** Konsoldemonstration av US-03.
- **BookingSystem.Tests:** Enhetstester med xUnit.

Projektet använder datalagring i minnet.

## Tester
Tre automatiserade enhetstester har implementerats med xUnit:

1. Kontroll av att befintliga bokningar bevaras när ett exemplar markeras som otillgängligt.
2. Kontroll av att en redan otillgänglig maskin behåller sin ursprungliga anledning.
3. Kontroll av att ett inventarienummer som saknas hanteras utan undantag.

**Testresultat: 3 godkända, 0 misslyckade.**

## Köra projektet
1. Öppna `BookingSystem.slnx` i Visual Studio.
2. Starta projektet `BookingSystem` för att se konsoldemonstrationen.
3. Öppna Test Explorer och välj **Run All Tests** för att köra enhetstesterna.

## Avgränsningar
Implementationen fokuserar på US-03 och acceptanskriteriet AK-05.

Projektet omfattar inte ett fullständigt bokningssystem, databaslagring eller funktionalitet för att skapa nya bokningar via användargränssnittet.
