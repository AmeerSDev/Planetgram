using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Planetgram.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planetgram.Handler
{
    public static class Scraper
    {
        public static async Task<User> ScrapeInstagram(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    // create html document
                    var htmlBody = await response.Content.ReadAsStringAsync();
                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(htmlBody);

                    // select script tags
                    var scripts = htmlDocument.DocumentNode.SelectNodes("/html/body/script");

                    // preprocess result
                    var uselessString = "window._sharedData = ";
                    var scriptInnerText = scripts[0].InnerText
                        .Substring(uselessString.Length)
                        .Replace(";", "");

                    // serialize objects and fetch the user data
                    dynamic jsonStuff = JObject.Parse(scriptInnerText);
                    dynamic userProfile = jsonStuff["entry_data"]["ProfilePage"][0]["graphql"]["user"];

                    // create an InstagramUser
                    var instagramUser = new User
                    {
                        UserAlias = userProfile.full_name,
                        UserFollowers = userProfile.edge_followed_by.count,
                        UserFollowings = userProfile.edge_follow.count
                    };
                    Debug.Print($"Name: {instagramUser.UserAlias},Followers: {instagramUser.UserFollowers} , Following: {instagramUser.UserFollowings}");
                    return instagramUser;
                }
                else
                {
                    throw new Exception($"Something wrong happened {response.StatusCode} - {response.ReasonPhrase} - {response.RequestMessage}");
                }
            }
        }
    }
}
