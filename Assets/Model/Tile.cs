using System.Collections;
using System.Collections.Generic;

public class Tile {

    public enum TileType { Empty, Floor };
    public TileType Type { get; set; } = TileType.Empty;

    // Each Tile can have an object.
    LoosObject loosObject;
    InstalledObject installedObject;

    World world;
    public int X { get; }
    public int Y { get; }

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.X = x;
        this.Y = y;
    }
}
