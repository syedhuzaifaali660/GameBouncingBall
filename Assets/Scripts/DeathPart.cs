
using UnityEngine;

public class DeathPart : MonoBehaviour
{

    //public void ChangeColorDeathPart(Color StageColor)
    //{
    //    GetComponent<Renderer>().material.color=Color.StageColor;
    //}

    public void HitDeathPart()
    {
        //GameManager.singleton.RestartLevel();
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        GameManager.singleton.PauseGame();
        //GameObject.Find("Ball").GetComponent<Material>().color = Color.green;
    }


    

}
