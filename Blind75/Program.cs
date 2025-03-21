// See https://aka.ms/new-console-template for more information

using Blind75.Questions;

Console.WriteLine("Hello, World!");

FindMinimumInRotatedSortedArray obj = new FindMinimumInRotatedSortedArray();    
var c = obj.FindMinimum([4,5,6,7,0,1,2,3]);
Console.WriteLine($"Min: {c}");