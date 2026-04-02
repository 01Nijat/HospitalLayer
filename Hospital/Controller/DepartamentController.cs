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
            if (departamentService.Create(departament)!= null) //burada (departament) obyektni gondermemisdim
            {                                            //mtod code segmentde null deil deye true olur, ve obyekt yoxdu deye errorda yoxdu ele bilirik dbcontekste yazilir halbuki obyekt gondermirik sintak error yox logic sehfi var. gerek diqqetli olaq
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
    public void Update()
    {
       GetAll();
       Helper.TextColor(ConsoleColor.Cyan,"Deyisiklik etmek isdediyinizi secin");
       string selectItem=Console.ReadLine();
       int itemId;
       bool isTrue=int.TryParse(selectItem, out itemId);
        if (isTrue)
        {
            
            Helper.TextColor(ConsoleColor.White, "AD GUNCELLE");
            string nameU=Console.ReadLine();
            Helper.TextColor(ConsoleColor.White, "MaxEmployee Guncelle" );
            string maxEmplooyeU=Console.ReadLine();
            int maxEmU;
            bool trueEu=int.TryParse( maxEmplooyeU, out maxEmU);
            if (trueEu)
            {
                Departament Depar=new Departament{Name=nameU, MaxEmployees=maxEmU};
                Departament departament=departamentService.Update(itemId, Depar);
                Helper.TextColor(ConsoleColor.Cyan, $"{departament.Name} ve {departament.MaxEmployees} - ugurla guncellendi");
            }
            else
            {
                Helper.TextColor(ConsoleColor.Red, "Tapilmadi");
            }

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
   public void Delete()
    {
        GetAll();
        Helper.TextColor(ConsoleColor.Cyan, "Silmek Bir Id Secin");
        string selectItem=Console.ReadLine();
        int deleteNum;
        bool isTrue=int.TryParse(selectItem, out deleteNum);
        if (isTrue)
        {
            Departament departament=departamentService.Delete(deleteNum);
            if (deleteNum != null)
            {
                Helper.TextColor(ConsoleColor.Cyan, $"{departament.Id} {departament.Name}");
                return;
            }
            else
            {
                Helper.TextColor(ConsoleColor.Red,"departament not found");
                return;
            }
        }

    }
    public void GetByName()
    {
        GetAll();
      
        Helper.TextColor(ConsoleColor.Cyan, "Enter By Name");
        string name=Console.ReadLine();
        Departament departament=departamentService.Get(name);
        if (departament != null)
        {
            Helper.TextColor(ConsoleColor.Cyan, $"{departament.Name}");
            return;
        }
        else {
            Helper.TextColor(ConsoleColor.Cyan, "Name is not find");
            return;
        }

    }
    public void GetById()
    {
        GetAll();
        Helper.TextColor(ConsoleColor.Cyan,"Id ni qeyd edin sistemde varsa gosterek.");
        string selectItem=Console.ReadLine();
        int itemId;
        
        bool isTrue=int.TryParse(selectItem, out itemId);
        if (isTrue)
        {
            Departament departament=departamentService.Get(itemId);
            Helper.TextColor(ConsoleColor.Green, $"{departament.Id},{departament.Name},{departament.MaxEmployees}");
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red, "id Is not Found");
        }
    }
    public void GetAllEmplooye()
    {
        GetAll();
        Helper.TextColor(ConsoleColor.Cyan,"Enter Maxsize");
        string selectItem=Console.ReadLine();
        int itemmax;
        bool isTrue=int.TryParse(selectItem, out itemmax);
        if (isTrue)
        {
            Helper.TextColor(ConsoleColor.Cyan,$"with max size {itemmax}");
            foreach(Departament departament in departamentService.GetAll(itemmax))
            {
                Helper.TextColor(ConsoleColor.Cyan, $"{departament.Id} - {departament.Name} - {departament.MaxEmployees}");
            }
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red, "503 forbidden");
            return;
        }
    }
}
