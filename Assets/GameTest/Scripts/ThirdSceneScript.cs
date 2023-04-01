using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class ThirdSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;
    private List<DialogData> dialogTexts;
    private void Awake()
    {
        dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/emote:Happy/That was fun!", "Li"));

        switch (ResponseManager.firstResponse)
        {
            case "Classic":
                dialogTexts.Add(new DialogData("You told me that my house is classic, /emote:Happy/you are super nice!", "Li"));
            break;
            case "Comfortable":
                dialogTexts.Add(new DialogData("/emote:Normal/I hope you have been as comfortable as you found my house.", "Li"));
            break;
            case "Negative":
                dialogTexts.Add(new DialogData("/emote:Sad/You said my house is small, but I forgive you, no problem.", "Li"));
            break;
        }

        string response = "";

        switch (ResponseManager.gameResponse)
        {
            case "1":
                response = "left";
            break;
            case "2":
                response = "middle";
            break; 
            case "3":
                response = "right";
            break;
        }

        dialogTexts.Add(new DialogData($"/emote:Normal/Then, you've chose the {response} cup in my game and..."));

        if (ResponseManager.gameResult)
        {
            dialogTexts.Add(new DialogData("/emote:Happy/And you won my game! You are awesome! /sound:haha/Haha"));
        }
        else
        {
            dialogTexts.Add(new DialogData($"/emote:Sad/Sadly, you missed and lost my game..."));
        }
        
        dialogTexts.Add(new DialogData("/emote:Normal/Well, that's it. /emote:Happy/See you!"));

        DialogManager.Show(dialogTexts);
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            DialogManager.Click_Window();
        }
    }
}
