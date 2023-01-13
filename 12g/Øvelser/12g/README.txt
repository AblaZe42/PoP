Alexander Husted
August Pallesen

Vigtigste beslutninger
----- Opgave A -----
class DoNothing
    kopieret fra opgave beskrivelsen.

class addConst
    Her defineres først en værdi value, som derefter bliver lagt til en given input.

class repeater
    For hvergang for-loopet i aplly køres igennem tilføjes der et element til den tomme liste lst.
    Dette element er inp og for-loopet køres igennem self.num gange.

class GeneralSum
    Her skal der ikke være nogle init værdi.
    vi skal lægge alle element af listen sammen, derfor køre vi et for-loop igennem så mange gange som listen er lang.
    X-værdien øges med en hvergang, derfor kan vi lægge den værdi på x'ende index til variablen n.

class ProductNum
    Denne klasse fungere ligesom GeneralSum, bare hvor man tager produktet af værdierne istedet for at addere dem.


----- Opgave B -----
class Map
    Vi har self.step som er det step vi gerne vil have gennemført på vores liste. f.eks. addConst(2).
    Derudover har vi en inp = [En list af tal].
    Ved brug af et for-loop går vi igennem hvert element in listen og anvender step.apply på hvert element.

----- Opgave C -----
class Pipeline
    Når Pipeline.apply(inp) kaldes gennems inp i variablen value.
    Pipeline fordres en liste af steps. Så for hvert element i listen tages det x'ende step.apply 
    og anvedes med værdien value.

----- Opgave D -----
class CsvReader
    CsvReader er næsten direkte kopieret fra aflevering 11i.

class critterStats
    critterStats er næsten direkte kopieret fra aflevering 11i.

class ShowAsciiBarchart
    Der oprettes et "hjælpeStep" kaldet maxLength, som gennemgår alle nøglerne i inp ved hjælp af et for loop.
    Længden på den længeste key gemmes i værdien n, og steppet returnere n.
    For apply oprettes der et n som gemmer en tom string. Derfra køres der et for-loop der,
    går igennem alle elementerne i biblioteket.
    for hvert tilføjes er en string og en newline til n.
    String'en står på formen |key  : ****|. kolonet bliver indekesteret således at de alle står på,
    maxLength + 1 plads. Efter kolonet ganges værdien value med "*"

----- Opgave E -----
class cal
    Her har vi valgt både at lave Cube og square som steps under klassen cal.

class average
    Vi anvender klasen GeneralSum på listen og dividere med Længden.