using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleApp.Model
{
    public class Apple
    {
        public int ID { get; set; }

        public int Rank { get; set; }
        public string Name { get; set; } 

        public string Location { get; set; }

        //[Column(TypeName = "double(2, 1)")]
        public double Rate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImgUrl { get; set; }

        [ValidateNever]
        public ICollection<Recipe> Recipes { get; set; }


    }
}
