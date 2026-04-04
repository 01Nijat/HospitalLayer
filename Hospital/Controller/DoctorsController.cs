using System;
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
             Helper.TextColor(ConsoleColor.Green, $"Student {newDct.Name} {newDct.Surname} created successfully in group {departamentName}");
        
        }
        else
        {
                            Helper.TextColor(ConsoleColor.Red, $"Failed to create doctor in departament {departamentName}. departament may not exist or is full.");
        }
    }
}
