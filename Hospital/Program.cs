// See https://aka.ms/new-console-template for more information

using System.Data;
using Hospital.Controller;
using Utilies.Helper;

Helper.TextColor(ConsoleColor.Cyan, "Welcome");
MenuController menuController=new MenuController();
while(true)
{
   Helper.TextColor(ConsoleColor.Green,"Select Opnion: 1-Departament Menu, 2-Doctor Menu");
 string selectItem=Console.ReadLine();
 int menu;
 bool isTrue=int.TryParse(selectItem, out menu);
  if(isTrue)
  {
      switch (menu)
      {
         
         case 1: menuController.DepartamentMenu();break;       
         case 2: menuController.DoctorMenu(); break;
         case 0: Helper.TextColor(ConsoleColor.Red,"Cixis edildi"); return;
         default: Helper.TextColor(ConsoleColor.Red,"Bir secim edin"); break;
         
      }
   }
}
