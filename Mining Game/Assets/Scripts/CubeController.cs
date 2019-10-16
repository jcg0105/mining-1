using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Ore myOre;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
       transform.localScale = new Vector3(1.2F, 1.2F, 1.2F);
    }

    private void OnMouseExit()
    {
       transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        switch (myOre)
        {
            case Ore.Gold:
                GameController.goldSupply--;
                GameController.totalScore += GameController.goldPoints;
                ScoreScript.scoreValue += GameController.goldPoints;
                break;

            case Ore.Silver:
                GameController.silverSupply--;
                GameController.totalScore += GameController.silverPoints;
                ScoreScript.scoreValue += GameController.silverPoints;
                break;

            default:
                GameController.bronzeSupply--;
                GameController.totalScore += GameController.bronzePoints;
                ScoreScript.scoreValue += GameController.bronzePoints;
                break;
        }
        
    }
}
