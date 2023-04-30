using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    [SerializeField] private List<Grass> possibleGrass;
    [SerializeField] private float tileSize;
    [SerializeField] private int numberOfRows;
    [SerializeField] private int numberOfCols;

    private int currentCol;
    private int currentRow;

    // Start is called before the first frame update
    void Start()
    {


        for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
        {
            //one col at a time
            for (int currentCol = 0; currentCol < numberOfCols; currentCol++)
            {
                //instantiate random room
                Grass newGrass = Instantiate(GetNextGrass()) as Grass;

                //move it to correct pos
                Vector3 newPos = new Vector3(currentRow * tileSize + this.transform.position.x, currentCol * tileSize + this.transform.position.y, 0.0f);
                newGrass.transform.position = newPos;
                //give name
                newGrass.gameObject.name = "Grass(" + currentCol + ", " + currentRow + ")";
                //organize hierarchy
                newGrass.gameObject.transform.parent = this.transform;
            }
        }
    }

    private Grass GetNextGrass()
    {
        return possibleGrass[Random.Range(0, possibleGrass.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
