using System.Collections;
using System.Collections.Generic;

public class Tile {

    public enum TileType { Empty, Floor };

    // Default Tile.
    TileType type = TileType.Empty;

    // Each Tile can have an object.
    LoosObject loosObject;
    InstalledObject installedObject;

    World world;
    int x;
    int y;

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.x = x;
        this.y = y;
    }
}
