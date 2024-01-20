using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gym.Models;
using App.Service;
using App.Models;

namespace Gym.Controllers;

public class GymController : Controller
{
    Disconnected _ds;
    public GymController()
    {
       _ds=new Disconnected();
    }

    public IActionResult Index()
    {
        List<Trainer> trainers=_ds.GetAll();
        return View(trainers);
    }

    public IActionResult Sort()
    {
        List<Trainer> tr=_ds.GetAll();
        List<Trainer> t= tr.OrderBy(t=>t.Status).ToList();
        return View(t);
    }

    public IActionResult Login(int id)
    {
        Trainer trainers=_ds.GetById(id);
        return View(trainers);
    }

    public IActionResult Delete(int id)
    {
        _ds.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Login(Trainer t)
    {
        Trainer trainers=_ds.GetById(t.Id);
        Id I =new Id();
        I.I=t.Id;
        
        if (trainers.MobileNumber.Equals(t.MobileNumber))
        {
            Console.WriteLine(I);
            return RedirectToAction("Details","Gym",I);
        }else
        {
            return RedirectToAction("Login",t.Id);
        }
        
    }

    public IActionResult Details(int i)
    {
        Trainer trainers=_ds.GetById(i);
        return View(trainers);
    }

public IActionResult Add()
    {
        
        return View();
    }
    [HttpPost]
     public IActionResult Add(Trainer t)
    {
        Console.WriteLine(t.Name);
        Console.WriteLine(t.Status.ToString());
        _ds.Add(t);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        Trainer t=_ds.GetById(id);
        return View(t);
    }
    [HttpPost]
     public IActionResult Edit(Trainer t)
    {
        Console .WriteLine("in Edit");
        _ds.Edit(t);
        return RedirectToAction("Index");
    }


}
