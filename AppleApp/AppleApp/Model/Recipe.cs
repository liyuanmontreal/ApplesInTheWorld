using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AppleApp.Model
{
    public class Recipe
    {
        public int ID { get; set; }

        //public int Rank { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }

        //[Column(TypeName = "double(2, 1)")]
        public double Rate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImgUrl { get; set; }

        //apple id
        [Display(Name = "Apple")]
        public int AppleID { get; set; }

        [ValidateNever]
        public Apple Apple { get; set; }

    }
}
