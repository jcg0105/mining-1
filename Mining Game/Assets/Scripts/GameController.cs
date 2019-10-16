using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /*
   Completed the following Challenge by Choices: 
    -feedback to player (mouse-over ore, display score)
    */

    //how fast will ore show up on the screen
    public float miningSpeed;
    public float mineNow;

    //num of ore for player to mine
    public static int bronzeSupply;
    public static int silverSupply;
    public static int goldSupply;

    //ore points
    public static int bronzePoints;
    public static int silverPoints;
    public static int goldPoints;
    
    //score after mining ore
    public static int totalScore;

    public GameObject cubePreFab;
    GameObject myCube;
    Ore recentOre;
    //create vector for cubes
    public Vector3 cubePos;
    float xPos;
    float yPos;

    // Start is called before the first frame update
    void Start()
    {
        xPos = 0;
        yPos = 0;
        bronzePoints = 1;
        silverPoints = 10;
        goldPoints = 100;
        bronzeSupply = 0;
        silverSupply = 0;
        goldSupply = 0;
        miningSpeed = 3;
        recentOre = Ore.Bronze;
     

    }

    void SpawnCube (Ore oreType)
    {
        Color cubeColor;

        switch (oreType)
        {
            case Ore.Silver:
                cubeColor = Color.white;
                break;
            case Ore.Gold:
                cubeColor = Color.yellow;
                break;
            default:
                cubeColor = Color.red;
                break;
        }
      
        cubePos = new Vector3(xPos, yPos, 0);
        myCube = Instantiate(cubePreFab, cubePos, Quaternion.identity);
        myCube.GetComponent<Renderer>().material.color = cubeColor; //change color
        myCube.GetComponent<CubeController>().myOre = oreType; //store cube type in cubeCont

        xPos += 2;
        if (xPos > 6)
        {
            xPos = -5;
            yPos = Random.Range(-5, 6);
        }
        recentOre = oreType;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow) //nine an ore every miningSpeed seconds
        {
            mineNow += miningSpeed;

            if (silverSupply == 2 && bronzeSupply == 2 && recentOre != Ore.Gold)
            {
                goldSupply++;
                SpawnCube(Ore.Gold);

            }
           else if (bronzeSupply < 4) 
            {
                bronzeSupply++;
                SpawnCube(Ore.Bronze);
            }

            else if (bronzeSupply >= 4)
            {
                silverSupply++;               
                SpawnCube(Ore.Silver);
            }

            print("Total Points: " + totalScore);
        }
    }
           
}
