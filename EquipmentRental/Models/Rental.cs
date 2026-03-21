using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Rental
{
    public static int IdCounter = 1;

    public int Id { get; private set; }

    public User RentingUser { get; private set; }
    public Equipment RentedEquipment { get; private set; }

    public DateTime RentDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public Rental(User rentingUser, Equipment rentedEquipment, int rentingDays)
    {
        Id = IdCounter++;
        RentingUser = rentingUser;
        RentedEquipment = rentedEquipment;
        RentDate = DateTime.Now;
        EndDate = RentDate.AddDays(rentingDays);

        RentedEquipment.Status = EquipmentStatus.Rented;
    }

    public void EndRental(DateTime returnDate)
    {
        ReturnDate = returnDate;
        RentedEquipment.Status = EquipmentStatus.Available;
    }

    public bool IsReturnLate()
    {
        return ReturnDate > EndDate;
    }
}