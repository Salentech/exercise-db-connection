using AutoMapper;
using exercise_db_connection.Models.Dtos;

namespace exercise_db_connection.Models.Mappers;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<ReviewDto, Review>()
            .ForMember(r => r.Book, opt => opt.NullSubstitute(new Book()));

        CreateMap<Review, ReviewDto>();
    }
}