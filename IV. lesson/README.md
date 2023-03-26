# Backtrack
A backtrack lényege az, ha zsákutcába érünk, akkor visszalépünk az előző állapotunkra. Itt is kell egy csomópot osztály, melyben letároljuk az operátorindexet.
Ez tartalmazza, hogy mely operátorokat néztük már meg. A backtrack nem találja meg az optimális megoldást, viszont felismeri, ha nincs megoldás. Ezalól kivétel az
ágkorlátos, ahol a negatív és a pozitív kilépési feltétel egyaránt az, hogy a jelenlegi csúcs az *null*. Viszont lassab algoritmust kapunk, mert bejárja az egész
állapot-átmenet gráfot.

A hanoinál sajna az alap backtrack folyamatosan körbe futna (hasonlóan a hegymászónál), de kisebb módosításokkal elkerülhetjük ezt.

## Mélységi korlátos backtrack
Ha elértük a mélységi korlátot visszalépünk. Ha véletlenül körbe kerülnénk, akkor bizonyos mélység után visszalépünk, ezáltal kilépünk a körből.

## Körfigyeléses backtrack
Kicsit bonyolultabb és időigényesebb, mint a mélységi korlátos, viszont itt már azt se engedjük, hogy belépjen a körbe. A csomópont szülőin visszafele végigmenve megnézzük,
hogy találtunk-e azonos állapottal rendelkezőt, ha igen visszalépünk.

## Ágkorlátos backtrack
A backtrack egy különleges fajtája, bejárja az egész gráfot, viszont emiatt is lassú algoritmus. Alapból mélységi korlátos, ha találtunk egy megoldást, lementi, és a
mélységi korlátját beállítja a megoldás mélységére. Így ha találunk egy újabb megoldást, az csak kisebb mélységű lehet, mígnem az optimálisat is megtaláljuk. Ha már
kiléptünk a ciklusból, az útvonalat vizsgáljuk, ha *null*, akkor nincs megoldás, ellenkező esetben pedig az optimálisat kapjuk vissza.
