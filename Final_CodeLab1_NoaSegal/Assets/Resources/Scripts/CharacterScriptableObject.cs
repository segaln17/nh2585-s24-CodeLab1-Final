using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create asset menu
[CreateAssetMenu
(fileName = "NewCharacter", 
   menuName = "NewCharacter", order = 0),]
public class CharacterScriptableObject : ScriptableObject
{
    //name of character --> this will be the god you get out of an array after the prayers are dequeued
    public string godName;
    
    //character dialogue --> what the god will say
    public string godDialogue;
}
