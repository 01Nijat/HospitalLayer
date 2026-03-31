using System;
using BusinessLogic.Service;
using Entities.Model;
using Utilies.Helper;

namespace Hospital.Controller;

public class DepartamentController
{ 
    private DepartamentService departamentService{get;}
 public DepartamentController()
 {
    departamentService=new DepartamentService();
 }
 public void Create()
    {
        EnterName : Helper.TextColor(ConsoleColor.Cyan,"Departament Name");
        string name=Console.ReadLine();
        Helper.TextColor(ConsoleColor.Cyan,"Enter Max Emplooyee");
        string selectItem=Console.ReadLine();
        int maxEmplooye;
        bool isTrue=int.TryParse(selectItem, out maxEmplooye);
        if (isTrue)
        {
          Departament departament=new Departament{Name=name, MaxEmployees=maxEmplooye};
            if (departamentService.Create != null)
            {
                Helper.TextColor(ConsoleColor.DarkCyan, $"{departament.Name} Departament is Created");
                return;
            }
            else
            {
                Helper.TextColor(ConsoleColor.Red, "Something is Wrong");
                return;
            }

        }
        else
        {
            Helper.TextColor(ConsoleColor.Yellow, "Select Correct Size");
             goto EnterName;
        }

    }
}
