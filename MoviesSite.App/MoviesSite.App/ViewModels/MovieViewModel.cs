using MoviesSite.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSite.App.ViewModels
{
    /* a "view model" is a type of model in the MVC pattern that is tightly bound
     * to a particular view
     * 
     * basically when the (business logic) models that we have in our application
     * don't match exactly what the view needs in order to have its data,
     * then we make a new class meant for that view to use.
     * 
     * often, with layered architecture (multiple projects with separated concerns)
     * the MVC layer is not really using our business logic classes and definitely
     * not our EF entity framework classes, instead it's using view models for to be each views model
     * 
     * 
     */

    public class MovieViewModel
    {
        public int Id { get; set; }
        //public string LoggedInUser { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public List<Genre> Genres { get; set; }


    }
}
