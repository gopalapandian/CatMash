using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Helper used get cats image, create randon instance, check image exists
/// </summary>
public class CatsHelper
{
    /// <summary>
    /// Method used to get the cats images
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static List<Cat> GetCats(string url)
    {

        #region Get Cats data from URL             
        using (var client = new WebClient())
        {
            var json = client.DownloadString(url);
            var cats = JsonConvert.DeserializeObject<Cats>(json).cats.ToList();            
            cats.ForEach(c => { c.nbvotesgagnants = c.nbmatchsnuls = c.nbvotesperdants = 0; c.score = 1000; });
            return cats;
        }

        /*
        using (StreamReader r = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("Model\\cat.json")))
           {
               string json = r.ReadToEnd();
               var cats = JsonConvert.DeserializeObject<Cats>(json).cats.ToList();
               cats.ForEach(c => { c.nbvotesgagnants = c.nbmatchsnuls = c.nbvotesperdants = 0; c.score = 1000; });
               return cats;
           }
        */
        #endregion
    }

    private static bool IsImageExists(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "HEAD";

        bool exists = true;
        try
        {
            request.GetResponse();
            exists = true;
        }
        catch
        {
            exists = false;
        }
        return exists;
    }
    /// <summary>
    /// creating a Random instance each call may not be correct for you consider a thread-safe static instance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static IEnumerable<T> Random<T>(IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable));
        }

        var r = new Random();
        var list = enumerable as IList<T> ?? enumerable.ToList();
        var first = list[r.Next(0, list.Count)];
        var second = list.Except(new List<T>() { first }).ToList()[r.Next(0, list.Count - 1)];
        return new List<T>() { first, second };
    }
}