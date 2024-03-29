﻿using Backend_Controller_Burhan.Models;

namespace Backend_Controller_Burhan.Dtos
{
    public class ArticleDto
    {
        public string ?slug { get; set; }
        public string ?title { get; set; }
        public string ?description { get; set; }
        public string ?body { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public List<string> ?tagList { get; set; } = new List<string>();
        public bool ? favorited { get; set; } = false;
        public int ? favoritesCount { get; set; }
        public Profile ?author { get; set; }
    }
}
