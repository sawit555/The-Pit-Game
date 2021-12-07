using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace AutoTileGenerator.Scripts
{
    public class TileType
    {

        //Tile Color Val Range : (0,0,0,0) => (255,7,0,0) = 2048 different types
        public const uint GRASS_01 = 0;
        public const uint GRASS_02 = 1;
        public const uint WATER = 2;
        public const uint TREE_01 = 3;
        public const uint TREE_02 = 4;
        public const uint GRASS_03 = 5;
        public const uint FLOWERS_01 = 6;
        public const uint GRASS_AT_START = 7;

        //Next type is 53

        
        public Color32 val;
        public string name;
        public uint typeID;
        public string spritePath;

        public static ColliderSpecs[] typeSpecsLibrary = new ColliderSpecs[2048];

        public TileType(Color32 v, string n, string p)
        {
            this.val = v;
            this.name = n;
            this.typeID = ColorTypeToInt();
            this.spritePath = p;
        }

        public uint ColorTypeToInt()
        {
            return (uint)(val.r + (val.g << 8) + (val.b << 16) + (val.a << 24));
        }

        public static bool HasCollider(TileType t)
        {
            return !(t == null || t.typeID == WATER || t.typeID == TREE_01 || t.typeID == TREE_02);
        }

        public static ColliderSpecs GetColliderSpecs(TileType t)
        {
            return typeSpecsLibrary[t.typeID];
        }

        public static Color32 UIntToColor32(uint val)
        {
            return new Color32((byte)(val << 24 >> 24) , (byte)(val << 16 >> 24)  , (byte)(val << 8 >> 24) , (byte)(val >> 24));
        }

        public static void InitColliderSpecsLibrary()
        {
            //Water Specs
            typeSpecsLibrary[WATER] = new ColliderSpecs();
            typeSpecsLibrary[WATER].scale = 1f;
            typeSpecsLibrary[WATER].isTrigger = false;
            typeSpecsLibrary[WATER].isCircle = false;
            typeSpecsLibrary[WATER].onTriggerFunction = () => {  };

            //Tree01 Specs
            typeSpecsLibrary[TREE_01] = new ColliderSpecs();
            typeSpecsLibrary[TREE_01].scale = .85f;
            typeSpecsLibrary[TREE_01].isTrigger = false;
            typeSpecsLibrary[TREE_01].isCircle = true;
            typeSpecsLibrary[TREE_01].onTriggerFunction = () => {  };

            //Tree02 Specs
            typeSpecsLibrary[TREE_02] = new ColliderSpecs();
            typeSpecsLibrary[TREE_02].scale = .85f;
            typeSpecsLibrary[TREE_02].isTrigger = false;
            typeSpecsLibrary[TREE_02].isCircle = true;
            typeSpecsLibrary[TREE_02].onTriggerFunction = () => {  };
        }

        public static List<TileType> LoadTypeFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            TileType[] types;
            int count;
            uint ctype;
            string cname, cpath;

            reader.ReadLine();//Read descriptor

            count = int.Parse(reader.ReadLine().Replace("TypeCount :", ""));

            types = new TileType[count];

            for (int i = 0; i < count; i++)
            {
                ctype = uint.Parse(reader.ReadLine().Replace("TypeID :", ""));
                cname = reader.ReadLine().Replace("Name :", "");
                cpath = reader.ReadLine().Replace("SPath :", "");
                reader.ReadLine();//Read descriptor
                types[i] = new TileType(TileType.UIntToColor32(ctype), cname, cpath);
            }


            return new List<TileType>(types);
        }

        public static List<TileType> LoadTypeFileFromResources(string path)
        {
            TextAsset ta = Resources.Load(path) as TextAsset;
            StringReader reader = new StringReader(ta.text);
            TileType[] types;
            int count;
            uint ctype;
            string cname, cpath;

            reader.ReadLine();//Read descriptor

            count = int.Parse(reader.ReadLine().Replace("TypeCount :", ""));

            types = new TileType[count];

            for (int i = 0; i < count; i++)
            {
                ctype = uint.Parse(reader.ReadLine().Replace("TypeID :", ""));
                cname = reader.ReadLine().Replace("Name :", "");
                cpath = reader.ReadLine().Replace("SPath :", "");
                reader.ReadLine();//Read descriptor
                types[i] = new TileType(TileType.UIntToColor32(ctype), cname, cpath);
            }


            return new List<TileType>(types);
        }

        public static void SaveTypeFile(string path, List<TileType> types)
        {
            StreamWriter writer = new StreamWriter(path);

            writer.WriteLine("- Tile Type Library - ");

            writer.WriteLine("TypeCount :" + types.Count);

            for (int i = 0; i < types.Count; i++)
            {
                writer.WriteLine("TypeID :" + types[i].typeID);
                writer.WriteLine("Name :" + types[i].name);
                writer.WriteLine("SPath :" + types[i].spritePath);
                writer.WriteLine("-");
            }

            writer.Close();

        }


        //Overloaded comparison operators to only check the type value since colors cannot be compared
        public static bool operator== (TileType a, TileType b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return ReferenceEquals(b, null) && ReferenceEquals(a, null);
            }

            return a.typeID == b.typeID;
        }
        public static bool operator!= (TileType a, TileType b)
        {
            return !(a.typeID == b.typeID);
        }

    }

    public struct TileNeighborhood
    {
        public TileType north;
        public TileType east;
        public TileType west;
        public TileType south;
        public TileType center;
        public TileType northeast;
        public TileType northwest;
        public TileType southeast;
        public TileType southwest;
    }

    public struct ColliderSpecs
    {
        public float scale;
        public bool isTrigger;
        public bool isCircle;
        public ExecOnTrigger onTriggerFunction;
    }

    public delegate void ExecOnTrigger();

}


