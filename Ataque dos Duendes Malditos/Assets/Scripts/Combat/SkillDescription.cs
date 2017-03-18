using UnityEngine;
using System.Collections;

public class SkillDescription : MonoBehaviour {
    public GameObject Description;
    void OnMouseOver()
    {   
        Description.SetActive(true);
    }

    void OnMouseExit()
    {
        Description.SetActive(false);
    }

}
