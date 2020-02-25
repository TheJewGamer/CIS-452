using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCreator : MonoBehaviour
{
    public abstract Character CreateCharacter(string allegiance);
}
