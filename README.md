# Warehouse management system

## Team 7

- [Sijerčić Tarik](https://github.com/tsijercic1 "Github")
- [Smajević Irfan](https://github.com/smajevicirfan "Github")
- [Fejzić Rijad](https://github.com/rfejzic1 "Github")

## Opis teme

Upravljanje skladištima i procesima u njima je ključno u poslovanju mnogih organizacija kojima je u fokusu skladištenje i distribucija dobara. Sistem za upravljanje skladštima je veoma korisno modelirati upravo softverom koji olakšava praćenje dobara od trenutka kada se registruju u skladište, sve do njihovog izvoza, kontrolu i nadzor nad procesima. Cilj ovog softvera je da olakša upravljanje skladištima i ostvari automatizaciju procesa skladištenja kroz centralizaciju informacija i procesa. Softverski pristup problemu pruža jednoj organizaciji mnoge pogodnosti koje bi bilo skupo ostvariti bez softvera.

## Funkcionalnosti

- Administriranje sistemom u smislu nadziranja svakog procesa i mogućnosti dodavanja i ažuriranja profila radnika
- Profili radnika i nivoi pristupa sistemu
- Registracija skladišta i osnovnih podataka o njima u centralizovan informacioni sistem
- Registracija artikala/robe u skladišta prilikom uvoza
- Praćenje svakog artikla u sektorima skladišta
- Korisnikovo izdavanje zahtjeva za artikle
- Odabir artikala, te grupisanje i pakovanje
- Registracija i izvoz pošiljki iz skladišta
- Obični ili hitni zahtjev izvoza

## Procesi

- Kreiranje računa uposlenika u skladištu i unos podataka o njima. Administrator određuje uloge svakog od uposlenika
- Uvoz artikala koje korisnik želi skladištiti, nakon obrade zahtjeva
- Opcionalna validacija ispravnosti i kvalitete artikala prilikom uvoza, te u slučaju neispravnosti ili nekih problema, vraćanje korisniku
- Registracija artikala nakon validacije - unošenje podataka u sistem
- Spremanje artikla u određeni sektor unutar skladišta nakon registracije
- Obrada zahtjeva koji predstavlja listu artikala koje treba preuzeti iz skladišta, te validiranje dovoljne količine takvih artikala u skladištu
- Dati prednost izvršenju hitnih zahtjeva
- Ispunjenje zahtjeva - odabir i pakovanje navedenih artikala
- Izdavanje naloga za izvoz paketa iz skladišta nakon validacije paketa

## Akteri

- Administrator sistema
- Upravnik skladišta
- Radnik - registracija robe
- Skladištar
- Sakupljač artikala
- Menadžer izvoza robe
- Korisnik
- Prevoznik
