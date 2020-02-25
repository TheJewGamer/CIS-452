using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCreator : MonoBehaviour
{
    public abstract GameObject CreateCharacter(string type);
}
