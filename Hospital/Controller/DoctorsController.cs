using System;
using System.Security.Cryptography.X509Certificates;
using BusinessLogic.Service;
using Entities.Model;
using Utilies.Helper;

namespace Hospital.Controller;

public class DoctorsController
{ 
    private DoctorService doctorService{get;}
    private DepartamentService departamentService{get;}
    public DoctorsController()
    {
        doctorService=new DoctorService();
        departamentService =new DepartamentService();
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
    public void GetAll()
    {
        Helper.TextColor(ConsoleColor.Cyan,"Butun Hekimler");
        List<Doctors>doctors=doctorService.GetAll();
        if (doctors == null)
        {
            Helper.TextColor(ConsoleColor.Red, "Nulldir");
        }
        if (doctors.Count==0)
        {
            Helper.TextColor(ConsoleColor.Red, "bosdur");
        }
        
            foreach(Doctors doxdur in doctorService.GetAll())
            {
                Helper.TextColor(ConsoleColor.Cyan,$"{doxdur.Id}-{doxdur.Name}");
            }
        
    }
    public void GetAllDoctorForDepartament()
    {   while(true){
        Helper.TextColor(ConsoleColor.Cyan,"Deprtament Adi yazin");
        string depName=Console.ReadLine();
        List<Doctors>doktur=doctorService.GetAll(depName);
        if (depName != null)
        {
            foreach(Doctors doctors in doktur)
            {
                Helper.TextColor(ConsoleColor.Cyan, $"All Doctors {doctors.Name}, - {doctors.Departament.Name}");
            }
        }
        if (doktur == null)
        {
            Helper.TextColor(ConsoleColor.Red, "Nulldir");
        }
        if (doktur.Count==0)
        {
            Helper.TextColor(ConsoleColor.Red, "bosdur");
        }
        else
        {
            Helper.TextColor(ConsoleColor.Red,"Xais edirik duzgun qeyd edin");
        }
    }
    }

public void Update()
    {
        Helper.TextColor(ConsoleColor.Yellow, "Doctors Update Etmek ucun ID secin");
        string select=Console.ReadLine();
        int itemId;
        bool isTrue=int.TryParse(select,out itemId);
        if (isTrue)
        {
            Doctors doctors=doctorService.Get(itemId);
            if (doctors != null)
            {
                Helper.TextColor(ConsoleColor.Cyan,"Departamentler");
                List<Departament> departaments = departamentService.GetAll();              
                 foreach(var d in departaments)
                {
                    Helper.TextColor(ConsoleColor.Cyan,$"{d.Id} - {d.Name}");
                }
                Helper.TextColor(ConsoleColor.Cyan,"Yeni department adi girin");
                string departamentName=Console.ReadLine().ToLower();
              
                doctorService.Update(doctors,departamentName);
                Helper.TextColor(ConsoleColor.Cyan,$"Guncellendi : {doctors.Id} {doctors.Name}-{doctors.Surname} {doctors.Departament.Name}");
            }
            else
            {
                Helper.TextColor(ConsoleColor.Red,"Xeta Duzgun Qeyd Aparin");
            }
        }

    }
}
