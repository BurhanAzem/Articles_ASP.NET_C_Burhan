using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend_Controller_Burhan.Services;
using Backend_Controller_Burhan.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_Controller_Burhan.Repository;
using Microsoft.AspNetCore.Authorization;
using Backend_Controller_Burhan.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Diagnostics;

public static class ServiceExtenion
{
    public static ArticleDto AsArticleDto(this Article article, User user)
    {
        return new ArticleDto()
        {
            slug = article.slug,
            title = article.title,
            description = article.description,
            body = article.body,
            createdAt = article.createdAt,
            updatedAt = article.updatedAt,
            favoritesCount = article.favoritesCount,
            author = article.author,
            //favorited = article.favorite.Contains(user.profile),
        };
    }
    public static Article AsArticle(this ArticleDto articleDto, User user)
    {
        List<Tag> listtag = new List<Tag>();
        for (int i = 0; i < articleDto.tagList.Count; i++)
        {
            Tag tag = new Tag();
            tag.tag = articleDto.tagList[i];
            listtag.Add(tag);
        }
        return new Article()
        {
            title = articleDto.title,
            description = articleDto.description,
            body = articleDto.body,
            profileusername = user.profile.username,
            tagList = listtag,
            author = user.profile,
        };
    }
    public static UserDto AsUserDto(this User user)
    {
        return new UserDto()
        {
              token = user.password,
              email = user.email,
              image = user.profile.image,
              bio = user.profile.bio,
              username = user.profile.username, 
        };
    }
    public static ProfileDto AsProfileDto(this Profile profile, User user)
    {
        return new ProfileDto()
        {
            username = profile.username,
            bio = profile.bio,
            image = profile.image,
            //follow = profile.followers.Contains(user.profile)
        };
    }
    public static CommentDto AsCommentDto(this Comment comment)
    {
        return new CommentDto()
        {
            id = comment.id,
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
            password = user.token,
            email = user.email,
            profile = new Profile()
            {
                image = user.image,
                bio = user.bio,
                username = user.username,  
            }
        };
    }
    public static Comment AsComment(this CommentDto commentDto, User user)
    {
        return new Comment()
        {
            body = commentDto.body,
            author = user.profile
        };
    }
}