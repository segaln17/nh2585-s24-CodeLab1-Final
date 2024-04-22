using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create asset menu
[CreateAssetMenu
(fileName = "NewCharacter", 
   menuName = "NewCharacter", order = 0),]
public class CharacterScriptableObject : ScriptableObject
{
    public string godName;
    public string godDialogue;

    //name of character --> this will be the god you get out of an array after the prayers are dequeued

    //character dialogue --> what the god will say
}
