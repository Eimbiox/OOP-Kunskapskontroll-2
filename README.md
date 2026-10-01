## Buggar:
1. Första buggen är en System.IndexOutOfRangeException  
detta händer eftersom det skapas 4 lines istället för 3 där en line     
har bara en part som är tom. och när man försöker lägga till part[1]    
så finns den inte och då får man en crash.  
Man får även en extra \r på slutet som man behöver ta bort  

2. Total metoden räknar fel på total price  

3. Om man lägger till en vara kan den läggas till med en tom sträng 

4. Programmet crashar om man skriver något annat än en int när man lägger till en vara  

5. Programmet crashar om man väljer ett nummer som inte finns på remove 

6. Programmet crashar om man inte väljer en av dem 5 alternativen i menyn   

7. Programmet skriver inte ut om varan hittades eller inte när man söker efter den  

8. Programmet crashar om den inte hittar filen (items.txt)
### Fix:
1. Ändra ReadAllText => ReadAllLines som automatiskt tar bort \r i slutet och skapar inte en extra tom line.   
Lägger till en if som kollar om det finns en tom line i txt. Om det finns blir den ignorerad.   

2. Fixat genom att ändra int i = 1 till int i = 0   

3. Fixat genom att använda metoder som kollar att string inte är empty   

4. Fixat genom att använda metoder som kollar att det är en int och inte är negativt    

5. Fixat genom att använda helper metoderna och en egen metod för just remove så att man kan bara ta bort om man skriver ett nummer som finns på listan.    

6. Fixat genom att lägga en if innan meny valen som kollar att man väljer en av de 5 alternativen.  

7. Fixat genom att lägga till Console.ReadKey() efter utskriften   

8. Fixat genom att lägga till File.Exists(path) i load. Den kollar om det finns en fil vid det namnet i path och returnerar en boolean. 

Om den är true så går den vidare eftersom !true blir false och kör resten av koden. Om den är false så kommer den gå in i if och bara gå ut från metoden. Då har man en tom lista där man kan forfarande lägga till grejer.     

Om man sedan sparar listan så skapas det en ny items.txt automatiskt. Detta är eftersom File.WriteAllText kollar om det finns en fil vid det namnet. Om det inte finns så skapar den det automatiskt och skriver i den. 

Om filen finns så rensar den allt i filen och skriver om det.

