using System;
using System.Collections;
using System.Collections.Generic;

public class Tile {

    // Array of Callbacks to be called after the Type is set.
    Action<Tile> tileTypeChangeCallBack;

    // Each Tile can have an object.
    LoosObject loosObject;
    InstalledObject installedObject;

    // Tile Types
    public enum TileType { Empty, Floor };

    World world;
    public int X { get; }
    public int Y { get; }
    // Type Getter/Setter
    TileType type = TileType.Empty;
    public TileType Type {
        get {
            return type;
        }
        set {
            TileType oldType = type;
            type = value;
            // Call a callback so we know the type is changed.
            if (tileTypeChangeCallBack != null && oldType != type) {
                tileTypeChangeCallBack(this);
            }
        }
    }

    public Tile(World world, int x, int y)
    {
        this.world = world;
        this.X = x;
        this.Y = y;
    }

    public void RegisterTileTypeChangeCallBack(Action<Tile> callback) {
        this.tileTypeChangeCallBack += callback;
    }

    public void UnregisterTileTypeChangeCallBack(Action<Tile> callback) {
        this.tileTypeChangeCallBack -= callback;
    }
}
