﻿using System.Web.Mvc;

namespace Web.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Blog_RssFeed",
                "Blog/feed.xml",
                new { controller = "Rss", action = "Feed" }
            );

            context.MapRoute(
                "Blog_PostByUrl",
                "Blog/Posts/{url}",
                new { controller = "Posts", action = "PostByUrl" }
            );

            context.MapRoute(
                "Blog_default",
                "Blog/{controller}/{action}/{id}",
                new { action = "Index", controller = "Posts", id = UrlParameter.Optional }
            );

        }
    }
}
