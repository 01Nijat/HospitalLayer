using System;
using Utilies.Helper;

namespace Hospital.Controller;

public class MenuController
{
  DepartamentController departamentController=new DepartamentController();
   public void DepartamentMenu()
    {
        while (true)
        {
            Helper.TextColor(ConsoleColor.White, "Departament ucun bir secim edin");
            Helper.TextColor(ConsoleColor.White, "please correct opnion: 1-Create, 2-DepartamenUpdate, 3-DeleteDepartament, 4-GetDepartamentwithName, 5-GetDepartamentWithId, 6-GetAllDe,7-GetAllEmplooye");
            string secim=Console.ReadLine();
            int menu;
            bool isTrue=int.TryParse(secim, out menu);
            if (isTrue)
            {
     switch (menu)
   {
          case (int)Menu.Create:
           departamentController.Create();
           break;
        case  (int)Menu.Update:
        departamentController.Update();        
        break;
        case (int)Menu.Delete:
        departamentController.Delete();
        break;
        case (int)Menu.GetByName:
        departamentController.GetByName();
        break;
        case (int)Menu.GetById:
        departamentController.GetById();
        break;
        case (int)Menu.GetAll:
        departamentController.GetAll();
        break;
        case (int)Menu.GetAllEmployee:
        departamentController.GetAllEmplooye();       
        break;
        case 0: Helper.TextColor(ConsoleColor.Red,"Cixis edildi"); return;
    default: Helper.TextColor(ConsoleColor.Red, "Yanlish secim"); break;
                }
            }
        }
    }
   public void DoctorMenu()
    {
        DoctorsController doctorsController=new DoctorsController();
        while (true)
        {
            Helper.TextColor(ConsoleColor.White, "Doctor ucun bir secim edin");
            Helper.TextColor(ConsoleColor.White, "please correct opnion: 1-Create, 2-Delete");
            string secim=Console.ReadLine();
            int menu;
            bool isTrue=int.TryParse(secim, out menu);
        if (isTrue)
        {
            switch (menu)
     {
        
        case (int)Menu.CreateDoctor:
        doctorsController.Create();
        break;
        case (int)Menu.DeleteDoctor:
        doctorsController.Delete();
        break;
        case 0: Helper.TextColor(ConsoleColor.Red,"Cixis edildi"); return;
        default: Helper.TextColor(ConsoleColor.Red, "Yanlish secim"); break;
     }
        }
        }
    }
}
