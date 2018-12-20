N. Voordat je begint
De applicatie doet niet aan autosaving, zodraje iets belankrijks hebt aangepast en hiermee tevreden bent, druk je op "Save project"
Hierdoor word jouw huidige werk opgeslagen in een text bestand zodat je er een andere keer mee verder kan.
Het is niet aan te raden om hieraan waardes te veranderen, maar als het moet zou ik wel eerst kijken hoe alles werkt


I. Introductie
De PotionCombinationPopulator tool is bedoeld om het team te assisteren in het creëeren van nieuwe 
potions met ieder zijn eigen stats. Door middel van deze tool hoop ik dat de workflow van dit
element hierdoor word versneld. - Luca


II. Bekend raken met de interface
De interface van deze tool is simpel ingericht in 3 stukken: de app-control, de combinatie control 
en de potion manipulator.


III. Ingrediënten maken
Het maken van een nieuw ingrediënt is opzich niet moeilijk. Om te beginnen druk je op de "Alter ingredient ID's"-knop.
Hierdoor word je door geleid naar een nieuw scherm met lege text vakken met ID 0 t/m 255.
Je kunt hier alle vakken (behalve 0) aanpassen om een ingredient te binden aan een ID,
alhoewel het wel aan te raden is om de ingredienten binnen bepaalde categoriën op te delen om
zo meer duidelijkheid te creëeren. De ingredienten worden in memory gebracht zodra dit venster
word weggeklikt doox op de [X] know te drukken.


IV. Elementen creëeren en vernietigen
Om een element toe te voegen moet je de lege textbox naas "Add element" invullen, zodra je
tevreden bent met jouw nieuwe element kan je hem toevoegen door op "Add element" te drukken.
Dit zal het nieuwe element aan het einde toevoegen. Om elementen te verwijderen moet je
eerst de elementen die je wilt verijderen aanvinken, eenmaal gedaan druk je op de knop "Remove",
Dit geeft een pop-up om er zeker van te zijn dat je niet per ongelukt op de knop hebt gedrukt.

!Let op, de volgorde van de elementen moeten hetzelfde zijn in het eindproject om niet tegen onverwachte
effecten aan te stoten. Ook is er een limiet van 32 elementen. 
Als je een element verijdert kan dit effect hebben op potions die gebruik maken van elementen, 
aangezien de volgorde verandert.


V. Een potion key maken
Zodra je ingrediënten hebt kan je aan de slag met het uitzoeken van de combinatie van jouw potion.
bijvoorbeeld: appel -> appel -> peer. Onder elk ingredient zal je vier nummers op een rij zien,
deze nummer representeren het ID van het geselecteerde ingredient. Aan de rechterkant van de pijl
zie je een nummer verschijnen, dit nummer is de "key" voor deze potion. Alhoewel het nummer willekeurig
lijkt te zijn, is dit niet het geval. Als je naar de 32 getallen eronder ziet zul je een patroon herkennen
die overeen komt met de ingrediënten.

!Let op, een potion mag NIET 0 als "key" hebben.


VI. Mijn eerste potion
Nu dat je een combinatie hebt gevonden voor jouw potion, moet je hem verschillende stats geven.
Iedere stat zal de gevolgen van de potion in de game bepalen. Ook mag jij jouw potion een leuke naam geven.
Health, AttackPower, AttackSpeed en Movement speed accepteren alleen decimale waardes binnen het berijk van een float.
Defence en Piercing accepteren alleen hele getallen binnen het berijk van een interger.
Potion Name accepteerd alles, zolang je maar iets hebt ingevult.
Tot slot heb je elementen om toe te voegen aan de potion, maar die zijn niet verplicht. Hiervoor
mag je meerdere elementen uitkiezen die op jouw potion zullen werken.
Eenmaal klaar met jouw potion? druk dan op "Save Potion" om hem in memory te bewaren.

!Let op, "Save Potion" zal potions niet tussen sessies bewaren.


VII. Het verwijderen van een potion
Om een potion te verwijderen hoef je niet veel te doen. Als eerst moet je de combinatie van jouw potion
invoeren. Daarna druk je op "Remove Potion" om hem uit de memory te halen.


IX. Het berijden van de potion dictionairy
Wanneer je vindt dat je voorlopig genoeg potions hebt, dan druk je simpelweg op "Bake Potion Dictionairy".
Als dit de eerste keer is dat je de dictionairy bakt, zal de applicatie de locatie van de output vragen.
Eenmaal gedaan zal de cs file worden klaargemaakt op die locatie en ben je klaar. :)
