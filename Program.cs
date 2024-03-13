using lab5;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        MedicineManager manager = new MedicineManager();

        // Thêm một số thuốc vào danh sách
        List<Ingredient> ingredients1 = new List<Ingredient> {
            new Ingredient("Paracetamol", 500),
            new Ingredient("Aspirin", 100)
        };
        Medicine medicine1 = new Medicine("Panadol", 100, 50000, "Thuốc giảm đau", ingredients1);
        manager.AddMedicine(medicine1);

        List<Ingredient> ingredients2 = new List<Ingredient> {
            new Ingredient("Ibuprofen", 200)
        };
        Medicine medicine2 = new Medicine("Advil", 50, 70000, "Thuốc giảm đau", ingredients2);
        manager.AddMedicine(medicine2);

        // Hiển thị danh sách thuốc theo danh mục
        manager.DisplayMedicinesByCategory("Thuốc giảm đau");

        // Hiển thị chi tiết của một loại thuốc
        manager.DisplayMedicineDetails("Panadol");

        // Tìm kiếm thuốc
        manager.SearchMedicine("Advil");

        // Cập nhật thông tin của một loại thuốc
        manager.UpdateMedicine("Panadol", 150, 55000);

        // Xóa một loại thuốc khỏi danh sách
        manager.RemoveMedicine("Advil");

        manager.DisplayMedicinesByCategory("Thuốc giảm đau");


        Console.ReadLine();
    }
}
