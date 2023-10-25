﻿using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain;

namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogResponseDto, Domain.Blog>().ReverseMap();
        CreateMap<CommentResponseDto, Comment>().ReverseMap();
        CreateMap<Comment, CommentCreateDto>().ReverseMap().ConstructUsing(x => new Comment(x.AuthorId, x.BlogId, x.CreatedAt, null, x.Text));
        CreateMap<CommentCreateDto, CommentResponseDto>().ReverseMap();
    }
}