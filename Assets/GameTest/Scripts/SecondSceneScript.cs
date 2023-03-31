using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class SecondSceneScript : MonoBehaviour
{

    public DialogManager DialogManager;
    [SerializeField] private GameObject MiniGame;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>()
        {
            new DialogData("I'm going to hide a ball under a cup.", "Li"),
            new DialogData("I'm going to mix them.", "Li"),
            new DialogData("And the you arge going to guess where it is.", "Li"),
            new DialogData("/emote:Happy/Simple, right?", "Li"),
        };
        
        DialogData lastDialog = new DialogData("/emote:Normal/Are you /size:up/ready?", "Li");

        lastDialog.Callback = () =>
        {
               MiniGame.SetActive(true);
        };

        dialogTexts.Add(lastDialog);
        
        DialogManager.Show(dialogTexts);
    }
}
