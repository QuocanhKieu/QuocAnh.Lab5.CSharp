using System;
using System.Collections.Generic;

class Drug
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Drug(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}

class DrugCategory
{
    public string CategoryName { get; set; }
    public List<Drug> Drugs { get; set; }

    public DrugCategory(string categoryName)
    {
        CategoryName = categoryName;
        Drugs = new List<Drug>();
    }
}

class HospitalInventory
{
    private List<DrugCategory> drugCategories;

    public HospitalInventory()
    {
        drugCategories = new List<DrugCategory>();
    }

    public void AddDrug(string categoryName, string drugName, int quantity, double price)
    {
        DrugCategory category = GetOrCreateCategory(categoryName);
        category.Drugs.Add(new Drug(drugName, quantity, price));
    }

    public void DisplayDrugsByCategory(string categoryName)
    {
        DrugCategory category = GetCategory(categoryName);
        if (category != null)
        {
            Console.WriteLine($"Drugs in Category: {category.CategoryName}");
            foreach (var drug in category.Drugs)
            {
                Console.WriteLine($"Name: {drug.Name}, Quantity: {drug.Quantity}, Price: {drug.Price}");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public void DisplayDrugDetails(string categoryName, string drugName)
    {
        DrugCategory category = GetCategory(categoryName);
        if (category != null)
        {
            Drug drug = category.Drugs.Find(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));
            if (drug != null)
            {
                Console.WriteLine($"Details for Drug: {drug.Name}");
                Console.WriteLine($"Quantity: {drug.Quantity}, Price: {drug.Price}");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public void SearchDrug(string drugName)
    {
        foreach (var category in drugCategories)
        {
            Drug drug = category.Drugs.Find(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));
            if (drug != null)
            {
                Console.WriteLine($"Drug Found in Category: {category.CategoryName}");
                Console.WriteLine($"Quantity: {drug.Quantity}, Price: {drug.Price}");
                return;
            }
        }

        Console.WriteLine("Drug not found.");
    }

    public void UpdateDrug(string categoryName, string drugName, int newQuantity, double newPrice)
    {
        DrugCategory category = GetCategory(categoryName);
        if (category != null)
        {
            Drug drug = category.Drugs.Find(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));
            if (drug != null)
            {
                drug.Quantity = newQuantity;
                drug.Price = newPrice;
                Console.WriteLine("Drug updated successfully.");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    public void DeleteDrug(string categoryName, string drugName)
    {
        DrugCategory category = GetCategory(categoryName);
        if (category != null)
        {
            Drug drug = category.Drugs.Find(d => d.Name.Equals(drugName, StringComparison.OrdinalIgnoreCase));
            if (drug != null)
            {
                category.Drugs.Remove(drug);
                Console.WriteLine("Drug deleted successfully.");
            }
            else
            {
                Console.WriteLine("Drug not found.");
            }
        }
        else
        {
            Console.WriteLine("Category not found.");
        }
    }

    private DrugCategory GetOrCreateCategory(string categoryName)
    {
        DrugCategory category = drugCategories.Find(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
        if (category == null)
        {
            category = new DrugCategory(categoryName);
            drugCategories.Add(category);
        }
        return category;
    }

    private DrugCategory GetCategory(string categoryName)
    {
        return drugCategories.Find(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        HospitalInventory hospitalInventory = new HospitalInventory();

        // Add some drugs for testing
        hospitalInventory.AddDrug("Painkillers", "Paracetamol", 100, 5.99);
        hospitalInventory.AddDrug("Antibiotics", "Amoxicillin", 50, 7.99);
        hospitalInventory.AddDrug("Antipyretics", "Ibuprofen", 80, 8.49);

        // Display drugs by category
        hospitalInventory.DisplayDrugsByCategory("Painkillers");
        hospitalInventory.DisplayDrugsByCategory("Antibiotics");
        hospitalInventory.DisplayDrugsByCategory("Antipyretics");

        // Display drug details
        hospitalInventory.DisplayDrugDetails("Painkillers", "Paracetamol");
        hospitalInventory.DisplayDrugDetails("Antibiotics", "Amoxicillin");
        hospitalInventory.DisplayDrugDetails("Antipyretics", "Ibuprofen");

        // Search for a drug
        hospitalInventory.SearchDrug("Paracetamol");

        // Update drug information
        hospitalInventory.UpdateDrug("Painkillers", "Paracetamol", 120, 6.49);

        // Delete a drug
        hospitalInventory.DeleteDrug("Antibiotics", "Amoxicillin");

        // Display updated list of drugs
        hospitalInventory.DisplayDrugsByCategory("Painkillers");
        hospitalInventory.DisplayDrugsByCategory("Antibiotics");
        hospitalInventory.DisplayDrugsByCategory("Antipyretics");
    }
}
