using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nistor_Andreea_Proiect.Data;

namespace Nistor_Andreea_Proiect.Models
{
    public class DrugCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Nistor_Andreea_ProiectContext context, Drug drug)
        {
            var allCategories = context.Category;
            var drugCategories = new HashSet<int>(
            drug.DrugCategories.Select(c => c.DrugID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = drugCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateDrugCategories(Nistor_Andreea_ProiectContext context, string[] selectedCategories, Drug drugToUpdate)
        {
            if (selectedCategories == null)
            {
                drugToUpdate.DrugCategories = new List<DrugCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var drugCategories = new HashSet<int>
            (drugToUpdate.DrugCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!drugCategories.Contains(cat.ID))
                    {
                        drugToUpdate.DrugCategories.Add(
                        new DrugCategory
                        {
                            DrugID = drugToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (drugCategories.Contains(cat.ID))
                    {
                        DrugCategory courseToRemove
                        = drugToUpdate
                        .DrugCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}

