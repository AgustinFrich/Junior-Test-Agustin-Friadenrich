using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class FirstSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;
    private void Awake()
    {
        var dialogTexts = new List<DialogData>();
        var rosa = "/color:#dd5555/";
        var blanco = "/color:white/";

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Li. ", "Li"));
        dialogTexts.Add(new DialogData($"Welcome to {rosa}my house{blanco}."));

        var Text1 = new DialogData("Do you like my place?", "Li");
            Text1.SelectList.Add("Classic", "Yes, it's classic!");
            Text1.SelectList.Add("Comfortable", "It is comfortable.");
            Text1.SelectList.Add("Negative", "No... It's a bit small.");

            Text1.Callback = () => Check_Correct();

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
         }

    private void Check_Correct()
    {
        var dialogTexts = new List<DialogData>();

        switch (DialogManager.Result)
        {
            case "Classic":
                dialogTexts.Add(new DialogData("/emote:Happy/Thank you! That's the answer I expected", "Li"));
                break;
            case "Comfortable":
                dialogTexts.Add(new DialogData("/emote:Happy/Thanks, that is nice.", "Li"));
                break;
            case "Negative":
                dialogTexts.Add(new DialogData("/emote:Sad/Oh... Sorry...", "Li"));
                break;
        }
        DialogManager.Show(dialogTexts);

    }
}
