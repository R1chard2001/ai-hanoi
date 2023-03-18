# Módosítható kereső algoritmusok
Kell egy új osztály (*Node*) mely letárolja az előző állapotokat is (szülőállapot), és egyéb információkat is.
E új osztály segítségével megalkothatjuk a bonyolultabb keresőket is.
## Szélességi keresés
Két halmazban tárolja el a csúcsokat (Node-okat):
- Nyílt csúcsok halmaza (azaz a még fel nem tárt csúcsok)
- Zárt csúcsok halmaza (a már feltárt csúcsok)
### Ciklus lényege
Kiválasztom a nyílt csúcsok közül azt, aminek a legkisebb a mélysége, majd ezt a csúcsot kiterjesztem (, azaz alkalmazom rajta az összes alkalmazható operátort).
A kiválasztott csúcsot a zárt csúcsok halmazába teszem, míg az új csúcsokat csak abban az esetben rakom a nyílt csúcsok közé, ha sem a zárt, sem a nyílt csúcsok halmazában
nem szerepel.
Ha egy csúcs tartalmazza a célállapotot, akkor megállok. Viszont akkor ha már nincs nyílt csúcs, akkor is megállok, ilyenkor megoldhatatlan a probléma.
### Megjegyzés
A csúcs kiválasztásának szemontjából alkalmazhatunk **sor** adatszerkezetet a nyílt csúcsok halmazához.

## Mélységi keresés
Két halmazban tárolja el a csúcsokat (Node-okat):
- Nyílt csúcsok halmaza
- Zárt csúcsok halmaza
### Ciklus lényege
Kiválasztom a nyílt csúcsok közül azt, aminek a legnagyobb a mélysége, majd ezt a csúcsot kiterjesztem.
A kiválasztott csúcsot a zárt csúcsok halmazába teszem, míg az új csúcsokat csak abban az esetben rakom a nyílt csúcsok közé, ha sem a zárt, sem a nyílt csúcsok halmazában
nem szerepel.
Ha egy csúcs tartalmazza a célállapotot, akkor megállok. Viszont akkor ha már nincs nyílt csúcs, akkor is megállok, ilyenkor megoldhatatlan a probléma.
### Megjegyzés
A csúcs kiválasztásának szemontjából alkalmazhatunk **verem** adatszerkezetet a nyílt csúcsok halmazához.
