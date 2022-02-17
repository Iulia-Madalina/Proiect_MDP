using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_MDP.Data;

namespace Proiect_MDP.Models
{
    public class FlowerCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_MDPContext context, Flower flower)
        {
            var allCategories = context.Category;
            var flowerCategories = new HashSet<int>(flower.FlowerCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = flowerCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFlowerCategories(Proiect_MDPContext context, string[] selectedCategories, Flower flowerToUpdate)
        {
            if (selectedCategories == null)
            {
                flowerToUpdate.FlowerCategories = new List<FlowerCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var flowerCategories = new HashSet<int>(flowerToUpdate.FlowerCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!flowerCategories.Contains(cat.ID))
                    {
                        flowerToUpdate.FlowerCategories.Add(
                        new FlowerCategory
                        {
                            FlowerID = flowerToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (flowerCategories.Contains(cat.ID))
                    {
                        FlowerCategory courseToRemove
                        = flowerToUpdate
                        .FlowerCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
