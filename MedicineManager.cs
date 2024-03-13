using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class MedicineManager
    {
        private List<Medicine> medicines = new List<Medicine>();

        // Thêm thuốc mới vào danh sách
        public void AddMedicine(Medicine medicine)
        {
            medicines.Add(medicine);
        }

        // Hiển thị danh sách thuốc theo danh mục
        public void DisplayMedicinesByCategory(string category)
        {
            Console.WriteLine($"Danh sách thuốc trong danh mục '{category}':");
            foreach (var medicine in medicines)
            {
                if (medicine.Category == category)
                {
                    Console.WriteLine($"Tên: {medicine.Name}, Số lượng: {medicine.Quantity}, Giá bán: {medicine.Price}");
                }
            }
        }

        // Hiển thị thông tin chi tiết của một loại thuốc
        public void DisplayMedicineDetails(string medicineName)
        {
            foreach (var medicine in medicines)
            {
                if (medicine.Name == medicineName)
                {
                    Console.WriteLine($"Thông tin chi tiết của thuốc '{medicineName}':");
                    Console.WriteLine($"Số lượng: {medicine.Quantity}, Giá bán: {medicine.Price}");
                    Console.WriteLine("Danh sách các dược phẩm bên trong:");
                    foreach (var ingredient in medicine.Ingredients)
                    {
                        Console.WriteLine($"- {ingredient.Name}: {ingredient.Amount}mg");
                    }
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy thuốc có tên '{medicineName}'");
        }

        // Tìm kiếm thuốc theo tên
        public void SearchMedicine(string medicineName)
        {
            foreach (var medicine in medicines)
            {
                if (medicine.Name == medicineName)
                {
                    Console.WriteLine($"Tìm thấy thuốc '{medicineName}':");
                    Console.WriteLine($"Số lượng: {medicine.Quantity}, Giá bán: {medicine.Price}");
                    Console.WriteLine("Danh sách các dược phẩm bên trong:");
                    foreach (var ingredient in medicine.Ingredients)
                    {
                        Console.WriteLine($"- {ingredient.Name}: {ingredient.Amount}mg");
                    }
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy thuốc có tên '{medicineName}'");
        }

        // Cập nhật thông tin của một loại thuốc
        public void UpdateMedicine(string medicineName, int quantity, double price)
        {
            foreach (var medicine in medicines)
            {
                if (medicine.Name == medicineName)
                {
                    medicine.Quantity = quantity;
                    medicine.Price = price;
                    Console.WriteLine($"Đã cập nhật thông tin của thuốc '{medicineName}'");
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy thuốc có tên '{medicineName}'");
        }

        // Xóa một loại thuốc khỏi danh sách
        public void RemoveMedicine(string medicineName)
        {
            for (int i = 0; i < medicines.Count; i++)
            {
                if (medicines[i].Name == medicineName)
                {
                    medicines.RemoveAt(i);
                    Console.WriteLine($"Đã xóa thuốc '{medicineName}' khỏi danh sách");
                    return;
                }
            }
            Console.WriteLine($"Không tìm thấy thuốc có tên '{medicineName}'");
        }
    }
}
