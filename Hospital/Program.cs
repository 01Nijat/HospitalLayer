// See https://aka.ms/new-console-template for more information

using System.Data;
using Hospital.Controller;
using Utilies.Helper;
DepartamentController departamentController=new DepartamentController();

Helper.TextColor(ConsoleColor.Cyan, "Welcome");
ShowMenu();
while(true)
{
 string selectItem=Console.ReadLine();
 int menu;
 bool isTrue=int.TryParse(selectItem, out menu);
  if(isTrue&&menu>=1 && isTrue && menu <= 7)
  { 
    switch (menu)
     {
        case (int)Menu.Create:
           departamentController.Create();
           break;
        case 2 :
        Console.WriteLine("hello3");
        break;
        case 3 :
        Console.WriteLine("hell4o");
        break;
        case 4 :
        break;
        case 5 :
        break;
        case 6 :
        break;
        case 7 :
        Console.WriteLine("heldlo");
        break;
     }
   }
}
static void ShowMenu()
{
    Helper.TextColor(ConsoleColor.Green, "please correct opnion: 1-Create, 2-DepartamenUpdate, 3-DeleteDepartament, 4-GetDepartamentwithName, 5-GetDepartamentWithId, 6-GetAllDe,7-GetAllEmplooye");

}