using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    public int id {get;set;}
    public string title { get;set;}
    public string description { get;set;}

    public Dialog(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
    }
    public Dialog()
    {
        this.id = 0;
        this.title = "";
        this.description = "";
    }
}
