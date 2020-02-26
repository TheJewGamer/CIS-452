/*
    * Jacob Cohen
    * CharacterCreator.cs
    * Assignment #6
    * abstract class for the design pattern
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCreator
{
    public abstract GameObject CreateCharacter(string type);
}
