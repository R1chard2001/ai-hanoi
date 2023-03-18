# Nem módosítható gráfkereső algoritmusok

## Próba-hiba módszer (TrialAndError.cs)
A próba hiba módszer az egyik legegyszerűbb gráfkereső algoritmus. Az adatbázisban (memóriában) csak a jelenlegi állapot található meg. (Példánkban pluszban le van mentve a kezdőállapot a könnyú újraindítás miatt) A ciklus lényege, hogy a jelenlegi állapothoz keresünk egy alkalmazható operátort, ezt alkalmazva a következő állapotot lementjük a jelenlegibe, majd újraindul a ciklus. 

### Restartos próba-hiba módszer (TrialAndErrorWithRestart.cs)
A próba-hiba módszer alfajtája. Ha nem talál alkalmazható operátort a jelenlegi állapotunkhoz, azaz zsákutcába jutunk, akkor újraindítja a keresést. Persze ennek megadzunk egy max limitet is.

Megjegyzés: Hanoinál nem érdemes alkalmazni, nem találkozunk zsákutcával

## Hegymászó algoritmus
Az operátorokat mindig egy bizonyos sorrendbe nézi, hogy alkalmazható-e. Könnyen körbe juthatunk az algoritmus alkalmazásakor. Szintén van egy restartos alfajtája *Random walks* néven.
