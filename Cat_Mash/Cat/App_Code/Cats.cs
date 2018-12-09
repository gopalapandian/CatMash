using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model class to store cats informations
/// </summary>
public class Cats
{
    [JsonProperty("images")]
    public List<Cat> cats { get; set; }
  

}
public class Cat
{
    public string url { get; set; }
    public string id { get; set; }
    public int nbvotesgagnants { get; set; }
    public int nbvotesperdants { get; set; }
    public int nbmatchsnuls { get; set; }
    public double score { get; set; }
   
}