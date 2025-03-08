using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public static class CategoryManager
{
    private static Dictionary<string, List<string>> categoriesWithSubmenus = new Dictionary<string, List<string>>();

    public static void Initialize(Dictionary<string, List<string>> initialCategoriesWithSubmenus)
    {
        categoriesWithSubmenus = initialCategoriesWithSubmenus;
    }

    public static void AddCategory(string basePath, string category)
    {
        if (!categoriesWithSubmenus.ContainsKey(category))
        {
            categoriesWithSubmenus[category] = new List<string>();
            CreateDirectoryForCategory(basePath, category);
        }
    }

    public static void EditCategory(string basePath, string oldCategory, string newCategory)
    {
        if (categoriesWithSubmenus.ContainsKey(oldCategory) && !categoriesWithSubmenus.ContainsKey(newCategory))
        {
            categoriesWithSubmenus[newCategory] = categoriesWithSubmenus[oldCategory];
            categoriesWithSubmenus.Remove(oldCategory);
            RenameDirectoryForCategory(basePath, oldCategory, newCategory);
        }
    }

    public static void AddSubcategory(string basePath, string category, string subcategory)
    {
        if (categoriesWithSubmenus.ContainsKey(category) && !categoriesWithSubmenus[category].Contains(subcategory))
        {
            categoriesWithSubmenus[category].Add(subcategory);
            CreateDirectoryForSubcategory(basePath, category, subcategory);
        }
    }

    public static void EditSubcategory(string basePath, string category, string oldSubcategory, string newSubcategory)
    {
        if (categoriesWithSubmenus.ContainsKey(category))
        {
            var subcategories = categoriesWithSubmenus[category];
            var index = subcategories.IndexOf(oldSubcategory);
            if (index >= 0 && !subcategories.Contains(newSubcategory))
            {
                subcategories[index] = newSubcategory;
                RenameDirectoryForSubcategory(basePath, category, oldSubcategory, newSubcategory);
            }
        }
    }

    public static void DeleteCategory(string basePath, string category)
    {
        if (categoriesWithSubmenus.ContainsKey(category))
        {
            categoriesWithSubmenus.Remove(category);
            DeleteDirectoryForCategory(basePath, category);
        }
    }

    public static void DeleteSubcategory(string basePath, string category, string subcategory)
    {
        if (categoriesWithSubmenus.ContainsKey(category))
        {
            var subcategories = categoriesWithSubmenus[category];
            if (subcategories.Contains(subcategory))
            {
                subcategories.Remove(subcategory);
                DeleteDirectoryForSubcategory(basePath, category, subcategory);
            }
        }
    }

    public static Dictionary<string, List<string>> LoadCategoriesFromDirectory(string basePath)
    {
        categoriesWithSubmenus.Clear();
        if (Directory.Exists(basePath))
        {
            var categories = Directory.GetDirectories(basePath).Select(Path.GetFileName);
            foreach (var category in categories)
            {
                var subcategories = Directory.GetDirectories(Path.Combine(basePath, category)).Select(Path.GetFileName).ToList();
                categoriesWithSubmenus[category] = subcategories;
            }
        }
        return categoriesWithSubmenus;
    }

    public static Dictionary<string, List<string>> GetCategoriesWithSubmenus()
    {
        return categoriesWithSubmenus;
    }

    public static List<string> GetCategories()
    {
        return categoriesWithSubmenus.Keys.ToList();
    }

    public static List<string> GetSubcategories(string category)
    {
        if (categoriesWithSubmenus.ContainsKey(category))
        {
            return categoriesWithSubmenus[category];
        }
        return new List<string>();
    }

    public static void UpdateComboBoxes(params ComboBox[] comboBoxes)
    {
        foreach (var comboBox in comboBoxes)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(categoriesWithSubmenus.Keys.ToArray());
        }
    }

    private static void CreateDirectoryForCategory(string basePath, string category)
    {
        string categoryPath = Path.Combine(basePath, category);

        if (!Directory.Exists(categoryPath))
        {
            Directory.CreateDirectory(categoryPath);
        }
    }

    private static void RenameDirectoryForCategory(string basePath, string oldCategory, string newCategory)
    {
        string oldCategoryPath = Path.Combine(basePath, oldCategory);
        string newCategoryPath = Path.Combine(basePath, newCategory);

        if (Directory.Exists(oldCategoryPath))
        {
            Directory.Move(oldCategoryPath, newCategoryPath);
        }
    }

    private static void CreateDirectoryForSubcategory(string basePath, string category, string subcategory)
    {
        string subcategoryPath = Path.Combine(basePath, category, subcategory);

        if (!Directory.Exists(subcategoryPath))
        {
            Directory.CreateDirectory(subcategoryPath);
        }
    }

    private static void RenameDirectoryForSubcategory(string basePath, string category, string oldSubcategory, string newSubcategory)
    {
        string oldSubcategoryPath = Path.Combine(basePath, category, oldSubcategory);
        string newSubcategoryPath = Path.Combine(basePath, category, newSubcategory);

        if (Directory.Exists(oldSubcategoryPath))
        {
            Directory.Move(oldSubcategoryPath, newSubcategoryPath);
        }
    }

    private static void DeleteDirectoryForCategory(string basePath, string category)
    {
        string categoryPath = Path.Combine(basePath, category);

        if (Directory.Exists(categoryPath))
        {
            Directory.Delete(categoryPath, true);
        }
    }

    private static void DeleteDirectoryForSubcategory(string basePath, string category, string subcategory)
    {
        string subcategoryPath = Path.Combine(basePath, category, subcategory);

        if (Directory.Exists(subcategoryPath))
        {
            Directory.Delete(subcategoryPath, true);
        }
    }
}