using UnityEngine;

public class WorldController : MonoBehaviour {

    public Sprite floorSprite;

    World world;

	// Use this for initialization
	void Start () {
        // Create an emtpy world
        world = new World();

        Debug.Log("World is created with width of " + world.Width 
            + " and height of " + world.Height);

        // Create a GameObject for each generated Tile.
        for (int x = 0; x < world.Width; x++)
        {
            for (int y = 0; y < world.Height; y++)
            {
                Tile tile_data = world.GetTileAt(x, y);

                // Creating a new GameObject and adding it to the scene.
                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_" + x + "_" +  y;
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);
                tile_go.transform.SetParent(this.transform, true);

                // Add a SpriteRenderer for each tile but don't set the sprite.
                tile_go.AddComponent<SpriteRenderer>();

                // Register the Tile callback
                tile_data.RegisterTileTypeChangeCallBack(
                    (tile) => {
                        OnTileTypeChanged(tile, tile_go);
                    }
                );
            }
        }

        world.RandomizeTile();
    }

    // Update is called once per frame
    void Update () {

	}

    // Callback function on TileType change
    // Assign the Sprite to a Tile
    void OnTileTypeChanged(Tile tile_data, GameObject tile_go) {
        if (tile_data.Type == Tile.TileType.Floor) {
            tile_go.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (tile_data.Type == Tile.TileType.Empty) {
            tile_go.GetComponent<SpriteRenderer>().sprite = null;
        }
        else {
            Debug.LogError("OnTileTypeChanged - Unrecognized tile type!");
        }
    }
}
