/*
 * References:
 * https://docs.unity3d.com/ScriptReference/TextureWrapMode.html
 * https://docs.unity3d.com/ScriptReference/Texture2D.GetPixel.html
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

// object to be placed in a maze
public struct MazeObject
{
    public GameObject obj;
    public Color color;

}

public class MazeReader : MonoBehaviour
{
    // the player object
    public GameObject player;

    // attaches the gameplay manager to objects that need it.
    public GameplayManager gpManager;

    // 
    // private struct MazeObjectItem
    // {
    //     MazeObject obj;
    //     Vector3 position;
    // }

    public Texture2D image; // image itself
    // Vector2 imageSize; // image length and width

    // sets the position of the player if the start point is found (if true).
    public bool SetPlayerPos = true;

    // the number of rows and the number of columns
    public int ROW_COUNT = 0;
    public int COL_COUNT = 0;

    // the size of each cell in the image to pull objects from.
    public int CELL_SIZE = 1;

    // list of possible objects
    public List<GameObject> objectList;
    public List<Color> colorList;

    // public List<MazeObject> mazeObjects;

    // the terrain this script is attached to.
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 terrainSize = terrain.terrainData.size;
        

        if (image != null)
        {
            image.wrapMode = TextureWrapMode.Repeat;
            bool plyrPosSet = false; // becomes 'true' once the player's position has been set.

            // goes through each row and column
            for(int row = 0; row < ROW_COUNT; row++)
            {
                for(int col = 0; col < COL_COUNT; col++)
                {
                    // gets the pixel colour from the image at the provided row and column index.
                    Color imgClr = image.GetPixel(row * CELL_SIZE, col * CELL_SIZE);
                    
                    // if(clr == new Color(1.0F, 0.0F, 0.0F, 1.0F))
                    //     Debug.Log(clr.ToString());

                    // TODO: rewrite to be more efficient
                    // for(int i = 0; i < mazeObjects.Count; i++)
                    for (int i = 0; i < objectList.Count; i++)
                    {
                        // MazeObject obj = mazeObjects[i];
                        GameObject obj = objectList[i];
                        // Color objClr = obj.color;
                        Color objClr = colorList[i];

                        // alpha values of pixels are ignored.
                        imgClr.a = 1.0F;
                        objClr.a = 1.0F;

                        // if the prefab have been found
                        if (imgClr == objClr)
                        {
                            // gets the position of the object
                            Vector3 pos = new Vector3();
                            pos.x = Mathf.Lerp(terrain.transform.position.x, terrain.transform.position.x + terrainSize.x, (col * CELL_SIZE) / (float)image.width);
                            pos.y = transform.position.y;
                            pos.z = Mathf.Lerp(terrain.transform.position.z, terrain.transform.position.z + terrainSize.z, (row * CELL_SIZE) / (float)image.height);

                            // Vector3 pos = new Vector3(col * CELL_SIZE, 0, row * CELL_SIZE);

                            // provides the gameplay manager if it's valid
                            // if it's the starting color
                            if(!plyrPosSet)
                            {
                                // start position object
                                if (imgClr == new Color(1.0F, 0.0F, 0.0F, 1.0F))
                                {
                                    player.transform.position = new Vector3(pos.x, pos.y + 10.0F, pos.z);
                                    plyrPosSet = true;
                                }

                            }

                            // adding manager caller if valid
                            {
                                ManagerCaller mgrCaller = obj.GetComponent<ManagerCaller>();
                                if (mgrCaller != null)
                                    mgrCaller.gpManager = gpManager;
                            }

                            // if it's a moving platform
                            {
                                MovingObject mvgObj = obj.GetComponent<MovingObject>();
                                if(mvgObj != null)
                                {
                                    Vector3 temp = mvgObj.endPosition - mvgObj.startPosition;

                                    // offset using base position
                                    mvgObj.startPosition = pos - temp / 2;
                                    mvgObj.endPosition = pos + temp / 2;
                                }
                            }

                            // instantiates the object.
                            Instantiate(obj, pos, new Quaternion(0, 0, 0, 1));
                            break;
                        }
                    }
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
