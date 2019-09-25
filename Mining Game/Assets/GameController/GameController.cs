using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //at first i thought i had to display UI text for the score...whoops
    //(i might end up doing that if i have extra time)

    public GameObject BronzeCubePreFab;
    public GameObject SilverCubePreFab;

    int xPos;
    int yPos;
    int zPos;

    //how much ore has the player collected?
    public int bronzeScore;
    public int silverScore;

    //create vector for bronze/silver cubes
    public Vector3 bronzeCubePosition;
    public Vector3 silverCubePosition;

    public float miningSpeed;
    public float mineNow;

    //how much ore is there to mine?
    public int bronzeSupply;
    public int silverSupply;
    // Start is called before the first frame update
    void Start()
    {
        xPos = 0;
        yPos = 0;
        zPos = 0;
        bronzeScore = 0;
        silverScore = 0;
        bronzeSupply = 3;
        silverSupply = 2;
        miningSpeed = 3;
        print("Bronze: " + bronzeScore);
        print("Silver: " + silverScore);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow) //nine an ore every miningSpeed seconds
        {
            mineNow += miningSpeed;
            if (bronzeSupply > 0) //this might all be able to fit into a forloop and look better
            {
                bronzeSupply--;
                bronzeScore++;

                xPos = Random.Range(-5, 6) + 2;
                yPos = Random.Range(-6, 6) + 2;
               // zPos = Random.Range(-2, 6) + 2;
                bronzeCubePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(BronzeCubePreFab, bronzeCubePosition, Quaternion.identity);

                print("Bronze: " + bronzeScore);
            }

            else if (silverSupply > 0)
            {
                silverSupply--;
                silverScore++;

                xPos = Random.Range(-6, 6) + 2;
                yPos = Random.Range(-6, 6) + 2;
                // zPos = Random.Range(-2, 6) + 2;
                silverCubePosition = new Vector3(xPos, yPos, zPos);
                Instantiate(SilverCubePreFab, silverCubePosition, Quaternion.identity);

                print("Silver: " + silverScore);
            }
        }
    }
           
}
