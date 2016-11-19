#Szyfrowanie
by. Piotr Grabowski

##Szyfry
- szyfr Bacona
- szyfr Cezara
- szyfr AtBash
- alfabet morsa

##U�ywanie
###Argumenty
```
uruchamianie: Cipher.exe plik_�r�d�owy plik_do_zapisu algorygm kierunek
przyk�ad: Cipher.exe text.txt encrypted.txt morse to

options:
   plik_�r�d�owy  - plik z tekstem do zakodowania/odkodowania
   plik_do_zapisu - plik do zapisania rezultatu zakodowania/odkodowania
   algorytm       - bacon|morse|cezar|atbash
   kierunek       - from|to
```
###R�czne wpisywanie tekstu
Uruchom Cipher.exe i wybierz spos�b dzia�ania z Menu
```
+-------------------------------------------+
|                                           |
|  Szyfrowanie                              |
|                                           |
|  .autor                                   |
|  Piotr Grabowski                          |
|                               05.11.2016  |
|                                           |
+-------------------------------------------+

Wybierz algorytm szyfrowania

1. Szyfr Cezara
2. Szyfr AtBash
3. Szyfr Bacona
4. Kod Morse'a
```

##Przyk�ady
W katalogu Cipher\Examples mo�na uruchomi� plik `run.bat` kt�ry uruchamia Cipher.exe dla przyk�adowego pliku tekstowego dla wszystkich mo�liwych sposob�w szyfrowania i odszyfrowania.

```Cipher.exe original.txt bacon.encrypted bacon to
Cipher.exe original.txt cezar.encrypted cezar to
Cipher.exe original.txt atbash.encrypted atbash to
Cipher.exe original.txt morse.encrypted morse to

Cipher.exe bacon.encrypted bacon.decrypted bacon from
Cipher.exe cezar.encrypted cezar.decrypted cezar from
Cipher.exe atbash.encrypted atbash.decrypted atbash from
Cipher.exe morse.encrypted morse.decrypted morse from```
