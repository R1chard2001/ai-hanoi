# Hanoi tornyai példa
## Állapottér
Az állapottér a **State.cs** fájlban található. Jelenlegi példánkban a korongok egy int típusú tömbben vannak eltárolva. A tömbben lévő helye a korong nagyságát mutatja, az értéke pedig, hogy melyik oszlopon található. 
Van egy kezdő állapot, ezt általában a konstruktorban létre is hozzuk. Továbbá van célállapot is, melyet egy metódus segítségével (*IsTargetState*) tudjuk leellenőrizni.
Magát az osztályt az *ICloneable* interface-ből örököltetjük, későbbi órákon ez hasznos lesz számunkra, de itt is alkalmazzuk.
## Operátorok
Az operátorok osztálya a *Operator.cs* fájlan található. Benne kell megvalósítani azt a műveletet, mely állapotot kér és állapotot ad vissza.
Jelenlegi példánkban az operátor két adat alapján létrehozható:
- honnan szeretnénk a korongot elvenni
- hová szeretnénk azt lerakni

### Alkalmazhatóság
Le kell ellenőriznunk, hogy egy operátor alkalmazható-e az adott állapotra, ezt az *IsAplicable* nevű függvénnyel érjük el.
Tehát le kell ellenőriznünk, hogy ahonnan szeretnénk átrakni, van-e egyáltalán ott korong. Másrészt azt is meg kell nézni, hogy a másik rúdon nincs-e kisebb korong, mint amit át szeretnénk rakni.

Ha kiderítettük, hogy alkalmazható a kiválasztott operátor, akkor alkalmazzuk is.

## Megjegyzés
Jelenleg ez csak egy példa az állapottérre és az operátorokra. Természetesen máshogy is nézhet ki egy állapot (pl.: 3 bool tömb, indexe a korong mérete, értéke, hogy a korong ott-e van), és más állapottér reprezentációhoz más operátor is jut.
