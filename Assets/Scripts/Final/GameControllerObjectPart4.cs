using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerObjectPart4

    
    : MonoBehaviour
{
    public static int bronze, silver, gold;
    public static int points, bronzePoints, silverPoints, goldPoints;
    float mineNow;
    float miningSpeed;
    public GameObject cubePrefab;
    GameObject myCube;
    Vector3 cubePos;
    float xPos, yPos;
    Ore recentOre;

    // Start is called before the first frame update
    void Start()
    {
        bronze = 0;
        silver = 0;
        

        miningSpeed = 3;
        mineNow = miningSpeed;
        xPos = -5;
        //this allows the red blocks to start at -5
        yPos = 0;
        //this allows the white blocks to start at 0
        recentOre = Ore.Bronze;
        bronzePoints = 1;
        silverPoints = 10;
        goldPoints = 100;
    }
    public static void ProcessClickedCube (Ore ore)
    {
        if (ore == Ore.Bronze)
        {
            bronze--;
            points += bronzePoints;
        }
        else if (ore == Ore.Silver)
        {
            silver--;
            points += silverPoints;
        }
        else
        {
            gold--;
            points += goldPoints;
        }


    }
    void SpawnCube(Ore ore)
    {
        Color cubeColor;
        if (ore==Ore.Bronze)
        {
            cubeColor = Color.red;
        } else if (ore == Ore.Silver)
        {
            cubeColor = Color.white;
        } else
        {
            cubeColor = Color.yellow;
        }


        cubePos = new Vector3(xPos, yPos, 0);
        myCube = Instantiate(cubePrefab, cubePos, Quaternion.identity);
        myCube.GetComponent<Renderer>().material.color = cubeColor;
        myCube.GetComponent<CubeController>().myOre = ore;

        xPos += 2;
        if (xPos>14)
            //This will allow four rows of blocks to show up
        {
            xPos = 0;
            yPos += 2;
        }
        recentOre = ore;

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > mineNow)
        {
            mineNow += miningSpeed;

            if (bronze==2 && silver==2 && recentOre != Ore.Gold)
            {
                gold++;
                SpawnCube(Ore.Gold);
              

            }
            else if (bronze<4)
            {
                bronze++;
                SpawnCube(Ore.Bronze);
              
            }
            else 
            {
                silver++;
                SpawnCube(Ore.Silver);
            
            }
            print("Total Points: " + points);
           
        }

    }
}