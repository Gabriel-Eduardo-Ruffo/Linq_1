int[] numeros = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine("Numeros pares de una lista, forma clasica");

//recurrido de una lista (forma comun)
List<int>listaNumerosPares = new List<int>();
foreach(int numero in numeros)
{
    if(numero%2 == 0)
        {
            listaNumerosPares.Add(numero);
        }
}
foreach(int numero in listaNumerosPares)
{
    Console.WriteLine(numero);
}


//Recorrido de una estructura usando LINQ
Console.WriteLine("Numeros pares de una estructura usando LINQ");
IEnumerable<int> estructuraNumerosPares = from numero in numeros where numero % 2 == 0 select numero;
foreach (int numero in estructuraNumerosPares)
{
    Console.WriteLine(numero);
}