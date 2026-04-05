using System;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic.Service;
using Entities.Model;
using Utilies.Helper;

namespace Hospital.Controller;

public class DoctorsController
{ 
    private DoctorService doctorService{get;}
    public DoctorsController()
    {
        doctorService=new DoctorService();
    }
  public void Create()
    {
        Helper.TextColor(ConsoleColor.Cyan, "Enter Departament name");
        string departamentName=Console.ReadLine();
        Helper.TextColor(ConsoleColor.Cyan, "Enter Doctor Name");
        string name=Console.ReadLine();
        Helper.TextColor(ConsoleColor.Cyan,"Enter Doctor Surname");
        string surname=Console.ReadLine();
        Doctors doctors=new Doctors{Name=name, Surname=surname};
       Doctors newDct=doctorService.Create(doctors, departamentName);
        if (newDct != null)
        {
             Helper.TextColor(ConsoleColor.Green, $"Doctor {newDct.Name} {newDct.Surname} created successfully in Departament {departamentName}");
        
        }
        else
        {
          Helper.TextColor(ConsoleColor.Red, $"Failed to create doctor in departament {departamentName}. departament may not exist or is full.");
        }
    }
    public void Delete()
     
    {
       
        Helper.TextColor(ConsoleColor.Cyan, "Zehmet olmasa Id secin silek");
        string selectedId=Console.ReadLine();
        int itemId;
        bool isTrue=int.TryParse(selectedId, out itemId);
        
        if (isTrue != null)
        {
            Doctors doctors=doctorService.Delete(itemId);
            Helper.TextColor(ConsoleColor.Cyan, $"{doctors.Id} - {doctors.Name}-silindi");
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red, "Id not found");
        }
    }
    public void GetId()
    {
        Helper.TextColor(ConsoleColor.Cyan, "Please select Id");
        string selectItem=Console.ReadLine();
        int selectedId;
        bool isTrue=int.TryParse(selectItem, out selectedId);
        if (isTrue)
        {
          
         Doctors doctors=doctorService.Get(selectedId);
            if (doctors != null)
            {
                 Helper.TextColor(ConsoleColor.Cyan,$"{doctors.Id} {doctors.Departament.Name} {doctors.Name} {doctors.Surname}");
            }
        
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red, "Not Found");
        }
    }
    public void GetName()
    {
        Helper.TextColor(ConsoleColor.Cyan,"Bir Ad secin");
        string name=Console.ReadLine();
        List<Doctors> doctors=doctorService.Get(name);
        if (doctors != null)
        {
            foreach(Doctors doctor in doctors)
            {
                Helper.TextColor(ConsoleColor.Yellow,$"{doctor.Id} - {doctor.Name}");
            }
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red,"Not found");
        }
    }
}
