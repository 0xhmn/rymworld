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

                GameObject tile_go = new GameObject();
                tile_go.name = "Tile_" + x + "_" +  y;
                tile_go.transform.position = new Vector3(tile_data.X, tile_data.Y, 0);

                // Add a SpriteRenderer for each tile but don't set the sprite.
                tile_go.AddComponent<SpriteRenderer>();
            }
        }

        world.RandomizeTile();
    }

    // Randomize the tiles every 2 seconds
    float randomizeTileTimer = 2f;

    // Update is called once per frame
    void Update () {
		randomizeTileTimer -= Time.deltaTime;

        if (randomizeTileTimer < 0) {
            world.RandomizeTile();
            randomizeTileTimer = 2f;
        }
	}

    // Callback function on TileType change
    void OnTileTypeChanged(TargetJoint2D tile_data, GameObject tile_go) {

    }
}
