using Backend_Controller_Burhan.Dtos;
using Backend_Controller_Burhan.Models;
using System;
public static class EtintionesMethod
{
    public static ArticleDto AsArticleDto(this Article article)
    {
        return new ArticleDto()
        {
            slug = article.slug,
            title = article.title,
            description = article.description,
            body = article.body,
            createdAt = article.createdAt,
            updatedAt = article.updatedAt,
            favorited = article.favorited,
            favoratesCount = article.favoratesCount,
            author = article.author,
            comment = article.comment,
            favorite = article.favorite
        };
    }
    public static UserDto AsUserDto(this User user)
    {
        return new UserDto()
        {
              Password = user.Password,
              Email = user.Email,
              profile = user.profile
        };
    }
    public static ProfileDto AsProfileDto(this Profile profile)
    {
        return new ProfileDto()
        {
         UserName = profile.UserName,
         bio = profile.bio,
         image = profile.image,
         follow = profile.follow
        };
    }
    public static CommentDto AsCommentDto(this Comment comment)
    {
        return new CommentDto()
        {
            Id = comment.Id,
            createdAt = comment.createdAt,
            updatedAt = comment.updatedAt,
            body = comment.body,
            author = comment.author
        };
    }
    public static User AsUser(this UserDto user)
    {
        return new User()
        {
            Password = user.Password,
            Email = user.Email,
            profile = user.profile
        };
    }
    public static Comment AsComment(this CommentDto commentDto)
    {
        return new Comment()
        {
            Id = commentDto.Id,
            createdAt = commentDto.createdAt,
            updatedAt = commentDto.updatedAt,
            body = commentDto.body,
            author = commentDto.author
        };
    }
}