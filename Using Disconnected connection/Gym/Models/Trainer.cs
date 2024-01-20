
namespace App.Models;

public class Trainer
{
    public int Id{get; set;}
    public string Name{get;set;}
    public string Email{get; set;}
    public string MobileNumber{get; set;}
    public string Address{get; set;}
    public string Special{get; set;}
    public int Exp{get; set;}
    public DateTime Joining{get; set;}
    public string Remuneration{get; set;}
    public Status Status{get; set;}
}