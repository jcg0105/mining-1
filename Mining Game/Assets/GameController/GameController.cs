using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    

    public GameObject BronzeCubePreFab;
    public GameObject SilverCubePreFab;
    public GameObject GoldCubePrefab;

    int xPos;
    int yPos;
    int zPos;

    //how much ore has the player collected?
    public int bronzeScore;
    public int silverScore;
    public int goldScore;

    //create vector for bronze/silver cubes
    public Vector3 bronzeCubePosition;
    public Vector3 silverCubePosition;
    public Vector3 goldCubePosition;

    public float miningSpeed;
    public float mineNow;

    //how much ore is there to mine?
    public int bronzeSupply;
    public int silverSupply;
    public int goldSupply;
    // Start is called before the first frame update
    void Start()
    {
       xPos = 0;
       yPos = 0;
       zPos = 0;
        bronzeScore = 0;
        silverScore = 0;
        goldScore = 0;
        bronzeSupply = 0;
        silverSupply = 0;
        goldSupply = 0;
        miningSpeed = 1;
     

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow) //nine an ore every miningSpeed seconds
        {
            mineNow += miningSpeed;

            if (silverSupply == 2 && bronzeSupply == 2)
            {
                goldSupply++;
               
                xPos = Random.Range(-5, 6);
                yPos = Random.Range(-6, 5);
            
                goldCubePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(GoldCubePrefab, goldCubePosition, Quaternion.identity);

            }
           else if (bronzeSupply < 4) 
            {
                bronzeSupply++;
               

                xPos = Random.Range(-5, 6);
                yPos = Random.Range(-6, 5);
  
                bronzeCubePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(BronzeCubePreFab, bronzeCubePosition, Quaternion.identity);
            }

            else if (bronzeSupply >= 4)
            {
                silverSupply++;
                

                xPos = Random.Range(-6, 6);
                yPos = Random.Range(-6, 5);

                silverCubePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(SilverCubePreFab, silverCubePosition, Quaternion.identity);
            }
           print("Bronze: " + bronzeSupply + " .... Silver: " + silverSupply + " ... Gold: " + goldSupply);
        }
    }
           
}
