using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //at first i thought i had to display UI text for the score...whoops
    //(i might end up doing that if i have extra time)

    public bool flag;
    //how much ore has the player collected?
    public int bronzeScore;
    public int silverScore;

    public float miningSpeed;
    public float mineNow;

    //how much ore is there to mine?
    public int bronzeSupply;
    public int silverSupply;
    // Start is called before the first frame update
    void Start()
    {
        flag = true;
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
        if (Time.time > mineNow) //could use %?
        {
            mineNow += miningSpeed;
            if (bronzeSupply > 0) //this might all be able to fit into a forloop and look better
            {
                bronzeSupply--;
                bronzeScore++;
                print("Bronze: " + bronzeScore);
            }

            else if (silverSupply > bronzeSupply)
            {
                silverSupply--;
                silverScore++;
                print("Silver: " + silverScore);
            }
        }
        if (bronzeSupply == 0 && silverSupply == 0 && flag) //prints once
        {
            print("There are no more ores to mine! You are the ruler of minecraft");
            flag = false;
        }
    }
           
}
