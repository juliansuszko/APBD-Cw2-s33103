using System.Collections.Generic;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public class DataStore
{
    public List<Equipment> EquipmentList { get; } = new();
    public List<User> Users { get; } = new();
    public List<Rental> Rentals { get; } = new();
    
    public void AddEquipment(Equipment equipment)
    {
        EquipmentList.Add(equipment);
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void AddRental(Rental rental)
    {
        Rentals.Add(rental);
    }
}