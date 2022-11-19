using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PeriodicTable
{
    [JsonProperty("table")]
    public List<Element> elements { get; set; }
}

public class Element
{
    [JsonProperty("symbol")]
    public string symbol { get; set; }

    [JsonProperty("atomicNumber")]
    public int atomicNumber { get; set; }
}

