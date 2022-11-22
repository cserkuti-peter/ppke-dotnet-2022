using AutoMapper;
using RecipeBook.API.Dtos;
using RecipeBook.API.Models;
using RecipeBook.API.ViewModels;

namespace RecipeBook.API.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<NewRecipeDto, Recipe>();
            CreateMap<UpdateRecipeDto, Recipe>();
            CreateMap<Recipe, RecipeRowVM>()
                .ForMember(
                    dest => dest.RecipeBookName,
                    opt => opt.MapFrom(src => src.RecipeBook.Name)
                );
            CreateMap<Recipe, RecipeVM>()
                .ForMember(
                    dest => dest.CookTimeMinutes,
                    opt => opt.MapFrom(src => src.CookTime)
                );
        }
    }
}
