// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

double x = 5.5;
double y = 0;
var obj = Double.IsNaN(x / y) ? double.NaN : x/y;
Console.WriteLine(obj);
