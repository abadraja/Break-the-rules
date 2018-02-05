using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static int Skinns;

    public static void AddSkins(int skinnId)
    {
        Skinns += skinnId;
    }
}
