using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // https://www.kodeco.com/847-object-pooling-in-unity

    [SerializeField] private GameObject[] blockPrefab; 
    [SerializeField] private Transform spawnPosition;

    BlockController blockController;

    public void SpawnBlock()
    {
        int randomNum = Random.Range(0,101);
        int choosenBlock;
        if (randomNum <= 35) // city - 35%
            choosenBlock = 0; 
        else if (randomNum <= 45) // city wall - 10%
            choosenBlock = 12;   
        else if (randomNum <= 50) // city wall brous - 5%
            choosenBlock = 13;            
        else if (randomNum <= 52) // bottom coins - 2%
            choosenBlock = 1; 
        else if (randomNum <= 55) // top coins - 3%
            choosenBlock = 2; 
        else if (randomNum <= 59) // hole - 4%
            choosenBlock = 3; 
        else if (randomNum <= 60) // sewer entrance - 1%
            choosenBlock = 14; 
        else if (randomNum <= 65) // hole bottom coins - 5%
            choosenBlock = 4;
        else if (randomNum <= 70) // construction easel - 5%
            choosenBlock = 5;
        else if (randomNum <= 75) // scaffolding - 5%
            choosenBlock = 6;
        else if (randomNum <= 80) // bulldozer - 5%
            choosenBlock = 7; 
        else if (randomNum <= 86) // orc 01 - 6% 
            choosenBlock = 8;
        else if (randomNum <= 92) // orc 02 - 6%
            choosenBlock = 9;
        else if (randomNum <= 98) // enemy box - 6%
            choosenBlock = 10;
        else // power up life - 2%  
            choosenBlock = 11;     

        // choosenBlock = 0;     
        
        Instantiate(blockPrefab[choosenBlock],spawnPosition);
    }

}
