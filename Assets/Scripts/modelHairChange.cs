using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelHairChange : MonoBehaviour
{
    public GameObject hair;
    private SkinnedMeshRenderer hairMeshRenderer;
    public Mesh [] hairList;

    void Start()
    {
        hairMeshRenderer = hair.GetComponent<SkinnedMeshRenderer>();
    }

    public void changeHair(int num)
    {
        hairMeshRenderer.sharedMesh = hairList[num];
    }
}
