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
            if (departamentService.Create(departament)!= null)
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
  public void GetAll()
    {
        
        Helper.TextColor(ConsoleColor.Cyan, "Departament All");
        var list=departamentService.GetAll();
        if (list == null)
        {
            Helper.TextColor(ConsoleColor.Red, "Nulldir");
            return;
        }
        if (list.Count == 0)
        {
            Helper.TextColor(ConsoleColor.Red, "Bosdu");
            return;
        }
         foreach(Departament departament in departamentService.GetAll())
        {
            Helper.TextColor(ConsoleColor.Cyan, $"{departament.Id} {departament.Name}");
        }           
    
    }
}
