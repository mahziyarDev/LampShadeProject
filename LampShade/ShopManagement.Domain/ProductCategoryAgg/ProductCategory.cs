﻿using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg;

public class ProductCategory : EntityBase
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Picture { get; private set; }
    public string PictureAlt { get; private set; }
    public string PictureTitle { get; private set; }
    public string Keywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string Slug { get; private set; }
    
    
    public ProductCategory(string name, string description, string picture, string pictureAlt, string pictureTitle, string metaDescription, string slug, string keywords)
    {
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDescription = metaDescription;
        Slug = slug;
        Keywords = keywords;
    }

    public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string metaDescription, string slug, string keywords)
    {
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDescription = metaDescription;
        Slug = slug;
        Keywords = keywords;
    }
}