using Syroot.BinaryData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatfestEditor
{
    [Serializable]
    public class ByamlException : Exception
    {
        public ByamlException() { }
        public ByamlException(string message) : base(message) { }
        public ByamlException(string message, Exception inner) : base(message, inner) { }
        protected ByamlException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public enum ByamlNodeType
    {
        StringValue = 0xA0,
        PathValue = 0xA1,
        Array = 0xC0,
        Dictionary = 0xC1,
        StringTable = 0xC2,
        PathTable = 0xC3,
        BooleanValue = 0xD0,
        IntegerValue = 0xD1,
        FloatValue = 0xD2,
    }

    public class ByamlKeyAttribute : Attribute
    {
        public string Key;
        public ByamlKeyAttribute(string name)
        {
            Key = name;
        }
    }

    public class ByamlTreeNode : TreeNode
    {
        public ByamlEntry ByamlNode { get; set; }

        public ByamlTreeNode(ByamlEntry entry, string name)
        {
            ByamlNode = entry;
            Text = name;
        }
    }

    public class ByamlEntry
    {
        public ByamlNodeType NodeType { get; set; }
        public object Value { get; set; }

        public ByamlEntry(ByamlNodeType NodeType, object Value)
        {
            this.Value = Value;
            this.NodeType = NodeType;
        }
    }

    public class ByamlContext
    {
        private static class ByamlParser
        {
            private readonly static Dictionary<ByamlNodeType, Predicate<Type>> correctType = new Dictionary<ByamlNodeType, Predicate<Type>>()
            {
                { ByamlNodeType.BooleanValue, (type) => type == typeof(bool)},
                { ByamlNodeType.FloatValue, (type) => type == typeof(float)},
                { ByamlNodeType.IntegerValue, (type) => type == typeof(int)},
                { ByamlNodeType.StringValue, (type) => type == typeof(string)},
                { ByamlNodeType.Array, (type) => { return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>); } },
                { ByamlNodeType.Dictionary, (type) => (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>) && type.GetGenericArguments()[0] == typeof(string)) || type.IsClass},
            };

            public static bool NodeIsValue(ByamlNodeType nodetype)
            {
                switch (nodetype)
                {
                    case ByamlNodeType.BooleanValue:
                    case ByamlNodeType.IntegerValue:
                    case ByamlNodeType.FloatValue:
                    case ByamlNodeType.StringValue:
                    case ByamlNodeType.PathValue:
                        return true;
                    case ByamlNodeType.Array:
                    case ByamlNodeType.Dictionary:
                    case ByamlNodeType.StringTable:
                    case ByamlNodeType.PathTable:
                    default:
                        return false;
                }
            }

            //read byaml
            public static ByamlEntry ParseStringTable(ByamlContext ctx, BinaryDataReader br)
            {
                long startPos = br.Position;

                ByamlNodeType type = (ByamlNodeType)br.ReadByte();
                if (type != ByamlNodeType.StringTable)
                    throw new ByamlException("Invalid String table");

                int count = br.ReadInt24();
                List<uint> offs = br.ReadUInt32s(count + 1).ToList();

                List<string> values = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    br.Position = startPos + offs[i];
                    values.Add(Encoding.UTF8.GetString(br.ReadBytes((int)(offs[i + 1] - offs[i]))).Replace("\0", ""));
                }
                return new ByamlEntry(type, values);
            }
            public static ByamlEntry ParseDictionary(ByamlContext ctx, BinaryDataReader br)
            {
                Dictionary<string, ByamlEntry> dict = new Dictionary<string, ByamlEntry>();

                long startPos = br.Position;

                ByamlNodeType t = (ByamlNodeType)br.ReadByte();
                if (t != ByamlNodeType.Dictionary)
                    throw new ByamlException("Invalid Dictionary");

                int count = br.ReadInt24();

                for (int i = 0; i < count; i++)
                {
                    string name = ctx.NameTable[br.ReadInt24()];
                    Console.WriteLine(name);
                    ByamlNodeType t2 = (ByamlNodeType)br.ReadByte();

                    if (!NodeIsValue(t2))
                    {
                        uint off = br.ReadUInt32();
                        using (br.TemporarySeek(off, SeekOrigin.Begin))
                            dict.Add(name, ParseEntry(ctx, t2, br));
                    }
                    else
                        dict.Add(name, ParseEntry(ctx, t2, br));
                }

                return new ByamlEntry(t, dict);
            }
            public static ByamlEntry ParseArray(ByamlContext ctx, BinaryDataReader br)
            {
                List<ByamlEntry> array = new List<ByamlEntry>();

                long startPos = br.Position;

                ByamlNodeType t = (ByamlNodeType)br.ReadByte();
                if (t != ByamlNodeType.Array)
                    throw new ByamlException("Invalid Array");

                int count = br.ReadInt24();

                List<ByamlNodeType> types = new List<ByamlNodeType>();
                for (int i = 0; i < count; i++)
                    types.Add((ByamlNodeType)br.ReadByte());

                br.Align(4);

                for (int i = 0; i < count; i++)
                {
                    if (!NodeIsValue(types[i]))
                        using (br.TemporarySeek(br.ReadUInt32(), SeekOrigin.Begin))
                            array.Add(ParseEntry(ctx, types[i], br));
                    else
                        array.Add(ParseEntry(ctx, types[i], br));
                }

                return new ByamlEntry(t, array);
            }
            public static ByamlEntry ParseEntry(ByamlContext ctx, ByamlNodeType t, BinaryDataReader br)
            {
                switch (t)
                {
                    case ByamlNodeType.StringValue: return new ByamlEntry(t, ctx.Stringtable[br.ReadInt32()]);
                    case ByamlNodeType.PathValue: throw new ByamlException("Paths not supported");
                    case ByamlNodeType.PathTable: throw new ByamlException("Paths not supported");
                    case ByamlNodeType.BooleanValue: return new ByamlEntry(t, Convert.ToBoolean(br.ReadInt32()));
                    case ByamlNodeType.IntegerValue: return new ByamlEntry(t, br.ReadInt32());
                    case ByamlNodeType.FloatValue: return new ByamlEntry(t, br.ReadSingle());

                    case ByamlNodeType.Dictionary: return ParseDictionary(ctx, br);
                    case ByamlNodeType.Array: return ParseArray(ctx, br);
                    case ByamlNodeType.StringTable: return ParseStringTable(ctx, br);

                    default: throw new ByamlException($"Invalid or unknow node type : 0x{t:X}");
                }
            }
            //deserialize byaml
            public static object ProcessArrayDeserialization(ByamlEntry entry, Type t)
            {
                if (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(List<>))
                    throw new ByamlException("Invalid List");

                IList list = (IList)Activator.CreateInstance(t);

                var byamlArray = (List<ByamlEntry>)entry.Value;

                foreach (var item in byamlArray)
                {
                    list.Add(ProcessEntryDeserialization(item, t.GetGenericArguments()[0]));
                }

                return list;
            }
            public static object ProcessDictionaryDeserialization(ByamlEntry entry, Type t)
            {
                var o = Activator.CreateInstance(t);
                var byamlDict = (Dictionary<string, ByamlEntry>)entry.Value;

                foreach (var item in byamlDict)
                {
                    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                    {
                        var dict = (IDictionary)o;
                        dict.Add(item.Key, ProcessEntryDeserialization(item.Value, t.GetGenericArguments()[1]));
                    }
                    else
                    {
                        var props = t.GetProperties();
                        bool found = false;
                        foreach (var prop in props)
                        {
                            ByamlKeyAttribute nameAttr = (ByamlKeyAttribute)prop.GetCustomAttribute(typeof(ByamlKeyAttribute));
                            string name = nameAttr?.Key ?? prop.Name;
                            if (name == item.Key)
                            {
                                prop.SetValue(o, ProcessEntryDeserialization(item.Value, prop.PropertyType));
                                found = true;
                            }
                        }
                        if (!found)
                            throw new ByamlException($"Could not find {item.Key} type : {item.Value.NodeType} in {t.FullName}");
                    }
                }
                return o;
            }
            public static object ProcessEntryDeserialization(ByamlEntry entry, Type t)
            {
                if ((!correctType.ContainsKey(entry.NodeType) || !correctType[entry.NodeType](t)) && t != typeof(object))
                    throw new ByamlException($"Cannot convert {entry.NodeType} to {t.FullName}");

                switch (entry.NodeType)
                {
                    case ByamlNodeType.Array:
                        return ProcessArrayDeserialization(entry, t);
                    case ByamlNodeType.Dictionary:
                        return ProcessDictionaryDeserialization(entry, t);
                    case ByamlNodeType.BooleanValue:
                    case ByamlNodeType.StringValue:
                    case ByamlNodeType.IntegerValue:
                    case ByamlNodeType.FloatValue:
                        return entry.Value;
                    case ByamlNodeType.PathValue:
                    case ByamlNodeType.StringTable:
                    case ByamlNodeType.PathTable:
                    default:
                        throw new ByamlException("Invalid or unsupported node type");
                }
            }
            //write byaml
            public static void WriteStringList(List<string> list, BinaryDataWriter bw)
            {
                long startPos = bw.Position;
                bw.Write((byte)ByamlNodeType.StringTable);
                bw.WriteInt24(list.Count);
                bw.Write(new byte[4*(list.Count+1)]); //temp

                long tempPos;

                for (int i = 0; i < list.Count; i++)
                {
                    tempPos = bw.Position;
                    using (bw.TemporarySeek(startPos + 4 + i * 4, SeekOrigin.Begin))
                        bw.Write((int)(tempPos - startPos));

                    bw.Write(Encoding.UTF8.GetBytes(list[i] + "\0"));
                }
                tempPos = bw.Position;
                using (bw.TemporarySeek(startPos + 4 + list.Count * 4, SeekOrigin.Begin))
                    bw.Write((int)(tempPos - startPos));

                bw.Align(4);
            }
            public static void WriteDictionary(ByamlContext ctx, ByamlEntry entry, BinaryDataWriter bw)
            {
                var dict = (Dictionary<string, ByamlEntry>)entry.Value;
                bw.Write((byte)entry.NodeType);
                bw.WriteInt24(dict.Count);

                List<long> tempOffs = new List<long>();

                //value
                foreach (var item in dict)
                {
                    bw.WriteInt24(Array.IndexOf(ctx.NameTable.ToArray(), item.Key));
                    bw.Write((byte)item.Value.NodeType);

                    if (NodeIsValue(item.Value.NodeType))
                        WriteValue(ctx, item.Value, bw);
                    else
                    {
                        tempOffs.Add(bw.Position);
                        bw.Write(0); //temp
                    }
                }

                //array/dictionary
                int index = 0;
                foreach (var item in dict)
                {
                    if (!NodeIsValue(item.Value.NodeType))
                    {
                        long curPos = bw.Position;
                        using (bw.TemporarySeek(tempOffs[index++], SeekOrigin.Begin))
                            bw.Write((int)curPos);

                        if (item.Value.NodeType == ByamlNodeType.Array)
                            WriteArray(ctx, item.Value, bw);
                        else if (item.Value.NodeType == ByamlNodeType.Dictionary)
                            WriteDictionary(ctx, item.Value, bw);
                    }
                }
            }
            public static void WriteArray(ByamlContext ctx, ByamlEntry entry, BinaryDataWriter bw)
            {
                var list = (List<ByamlEntry>)entry.Value;
                bw.Write((byte)entry.NodeType);
                bw.WriteInt24(list.Count);

                List<long> tempOffs = new List<long>();

                //node types
                foreach (var item in list)
                    bw.Write((byte)item.NodeType);

                bw.Align(4);

                //values
                foreach (var item in list)
                {
                    if (NodeIsValue(item.NodeType))
                        WriteValue(ctx, item, bw);
                    else
                    {
                        tempOffs.Add(bw.Position);
                        bw.Write(0); //temp
                    }
                }

                //array/dictionary
                int index = 0;
                foreach (var item in list)
                {
                    if (!NodeIsValue(item.NodeType))
                    {
                        long curPos = bw.Position;
                        using (bw.TemporarySeek(tempOffs[index++], SeekOrigin.Begin))
                            bw.Write((int)curPos);

                        if (item.NodeType == ByamlNodeType.Array)
                            WriteArray(ctx, item, bw);
                        else if (item.NodeType == ByamlNodeType.Dictionary)
                            WriteDictionary(ctx, item, bw);
                    }
                }
            }
            public static void WriteValue(ByamlContext ctx, ByamlEntry entry, BinaryDataWriter bw)
            {
                switch (entry.NodeType)
                {
                    case ByamlNodeType.StringValue:
                        bw.Write(Array.IndexOf(ctx.Stringtable.ToArray(), (string)entry.Value));
                        break;
                    case ByamlNodeType.BooleanValue:
                        bw.Write((bool)entry.Value, BooleanDataFormat.Dword);
                        break;
                    case ByamlNodeType.IntegerValue:
                        bw.Write((int)entry.Value);
                        break;
                    case ByamlNodeType.FloatValue:
                        bw.Write((float)entry.Value);
                        break;
                    case ByamlNodeType.PathTable:
                    case ByamlNodeType.StringTable:
                    case ByamlNodeType.Array:
                    case ByamlNodeType.Dictionary:
                    case ByamlNodeType.PathValue:
                        throw new ByamlException("Invalid Node Type");
                    default:
                        throw new ByamlException("Invalid or unknown node type");
                }
            }
            //serialize byaml
            public static ByamlEntry ProcessDictionarySerialization(object obj)
            {
                var dict = new Dictionary<string, ByamlEntry>();

                //dictionary
                if (obj.GetType().IsGenericType && obj.GetType().GetGenericTypeDefinition() == typeof(Dictionary<,>) && obj.GetType().GetGenericArguments()[0] == typeof(string))
                {
                    var objDict = (IDictionary)obj;

                    foreach (dynamic item in objDict)
                    {
                        if (item.Value != null)
                            dict.Add(item.Key, ProcessEntrySerialization(item.Value));
                    }
                }
                //class
                else
                {
                    foreach (var prop in obj.GetType().GetProperties())
                        if (prop.GetValue(obj) != null)
                            dict.Add(prop.Name, ProcessEntrySerialization(prop.GetValue(obj)));
                }

                return new ByamlEntry(ByamlNodeType.Dictionary, dict);
            }
            public static ByamlEntry ProcessArraySerialization(IList list)
            {
                List<ByamlEntry> array = new List<ByamlEntry>();
                foreach (var item in list)
                    array.Add(ProcessEntrySerialization(item));

                return new ByamlEntry(ByamlNodeType.Array, array);
            }
            public static ByamlEntry ProcessEntrySerialization(object obj)
            {
                ByamlNodeType type = 0;
                bool found = false;

                foreach (var item in correctType)
                    if (item.Value(obj.GetType()))
                    {
                        found = true;
                        type = item.Key;
                        break;
                    }

                if (found)
                {
                    switch (type)
                    {
                        case ByamlNodeType.Array: return ProcessArraySerialization((IList)obj);
                        case ByamlNodeType.Dictionary: return ProcessDictionarySerialization(obj);

                        case ByamlNodeType.StringValue:
                        case ByamlNodeType.BooleanValue:
                        case ByamlNodeType.IntegerValue:
                        case ByamlNodeType.FloatValue:
                            return new ByamlEntry(type, obj);

                        case ByamlNodeType.PathValue:
                        case ByamlNodeType.PathTable:
                        case ByamlNodeType.StringTable:
                            throw new ByamlException("Unsupported Node Type");
                        default:
                            throw new ByamlException("Unsupported or unknown node type");
                    }
                }
                throw new ByamlException($"Could not match object type : {obj.GetType().FullName}");
            }
        }

        private List<string> Stringtable { get; set; } = new List<string>();
        private List<string> NameTable { get; set; } = new List<string>();
        public ushort ByamlVersion { get; set; } = 1;
        public ByteOrder BOM { get; set; } = ByteOrder.LittleEndian;
        public ByamlEntry RootNode { get; set; }

        public ByamlContext()
        {
        }
        public ByamlContext(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryDataReader br = new BinaryDataReader(ms);
                ReadByaml(br);
            }
        }
        public ByamlContext(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                BinaryDataReader br = new BinaryDataReader(fs);
                ReadByaml(br);
            }
        }
        public ByamlContext(Stream s)
        {
            BinaryDataReader br = new BinaryDataReader(s);
            ReadByaml(br);
        }
        public ByamlContext(BinaryDataReader br)
        {
            ReadByaml(br);
        }

        public static ByamlContext FromObject(object obj)
        {
            ByamlContext ctx = new ByamlContext();
            ctx.SerializeObject(obj);
            return ctx;
        }

        public void Write(Stream stream)
        {
            BinaryDataWriter bw = new BinaryDataWriter(stream);
            WriteByaml(bw);
        }
        public void Write(string path)
        {
            using (var fs = File.Open(path, FileMode.Create))
                Write(fs);
        }
        public byte[] Write()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryDataWriter bw = new BinaryDataWriter(ms);
                WriteByaml(bw);
                return ms.GetBuffer().Take((int)bw.Position).ToArray();
            }
        }


        public ByamlTreeNode GetTreeNode()
        {
            ByamlTreeNode root = new ByamlTreeNode(RootNode, "Root");
            MakeTreenode(root);

            return root;
        }

        public T Deserialize<T>()
        {
            return (T)ByamlParser.ProcessEntryDeserialization(RootNode, typeof(T));
        }
        public void SerializeObject(object obj)
        {
            RootNode = ByamlParser.ProcessEntrySerialization(obj);
        }

        public List<string> GetNameList()
        {
            GenerateStringLists();
            return NameTable;
        }

        private void GenerateStringLists()
        {
            Stringtable.Clear();
            NameTable.Clear();
            AddToLists(NameTable, Stringtable, RootNode);

            NameTable.Sort(CompareString);
            Stringtable.Sort(CompareString);
        }

        private static int CompareString(string a, string b)
        {
            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] == b[i])
                    continue;
                else if (a[i] < b[i])
                    return -1;
                else return 1;
            }
            if (a.Length == b.Length)
                return 0;
            else if (a.Length < b.Length)
                return -1;
            else
                return 1;
        }

        private static void AddToLists(List<string> names, List<string> strings, ByamlEntry entry)
        {
            switch (entry.NodeType)
            {
                case ByamlNodeType.StringValue:
                    if (!strings.Contains((string)entry.Value))
                        strings.Add((string)entry.Value);
                    break;
                case ByamlNodeType.Array:
                    var array = (List<ByamlEntry>)entry.Value;
                    foreach (var item in array)
                        AddToLists(names, strings, item);
                    break;
                case ByamlNodeType.Dictionary:
                    var dict = (Dictionary<string, ByamlEntry>)entry.Value;
                    foreach (var item in dict)
                    {
                        if (!names.Contains(item.Key))
                            names.Add(item.Key);
                        AddToLists(names, strings, item.Value);
                    }
                    break;
                case ByamlNodeType.PathValue:
                case ByamlNodeType.StringTable:
                case ByamlNodeType.PathTable:
                case ByamlNodeType.BooleanValue:
                case ByamlNodeType.IntegerValue:
                case ByamlNodeType.FloatValue:
                    break;
                default:
                    break;
            }
        }

        private void ReadByaml(BinaryDataReader br)
        {
            string magic = Encoding.ASCII.GetString(br.ReadBytes(2));
            switch (magic)
            {
                case "BY": br.ByteOrder = ByteOrder.BigEndian; break;
                case "YB": br.ByteOrder = ByteOrder.LittleEndian; break;
                default: throw new ByamlException("Invalid Header");
            }
            BOM = br.ByteOrder;

            ByamlVersion = br.ReadUInt16();
            uint headerSize = br.ReadUInt32();
            uint stringTableOffset = br.ReadUInt32();
            uint dataOffset = br.ReadUInt32();

            br.Seek(headerSize, SeekOrigin.Begin);
            NameTable = (List<string>)ByamlParser.ParseStringTable(this, br).Value;

            br.Seek(stringTableOffset, SeekOrigin.Begin);
            Stringtable = (List<string>)ByamlParser.ParseStringTable(this, br).Value;

            br.Seek(dataOffset, SeekOrigin.Begin);
            ByamlNodeType t = (ByamlNodeType)br.ReadByte();
            switch (t)
            {
                case ByamlNodeType.Array:
                case ByamlNodeType.Dictionary:
                    br.Position--;
                    RootNode = ByamlParser.ParseEntry(this, t, br);
                    break;

                default: throw new ByamlException("Invalid Root Node");
            }
        }
        private void WriteByaml(BinaryDataWriter bw)
        {

            string magic = (BOM == ByteOrder.BigEndian || (BOM == ByteOrder.System && !BitConverter.IsLittleEndian))
                ? "BY"
                : "YB";
            bw.Write(Encoding.ASCII.GetBytes(magic));
            bw.Write(ByamlVersion);
            bw.Write(0x10);

            GenerateStringLists();

            long tempStrTableOff = bw.Position;
            bw.Write(0); //temp
            long tempRootNodeOff = bw.Position;
            bw.Write(0); //temp

            ByamlParser.WriteStringList(NameTable, bw);
            long tempPos = bw.Position;
            using (bw.TemporarySeek(tempStrTableOff, SeekOrigin.Begin))
                bw.Write((int)tempPos);

            ByamlParser.WriteStringList(Stringtable, bw);
            tempPos = bw.Position;
            using (bw.TemporarySeek(tempRootNodeOff, SeekOrigin.Begin))
                bw.Write((int)tempPos);

            if (RootNode.NodeType == ByamlNodeType.Array)
                ByamlParser.WriteArray(this, RootNode, bw);
            else if (RootNode.NodeType == ByamlNodeType.Dictionary)
                ByamlParser.WriteDictionary(this, RootNode, bw);
        }

        private static void MakeTreenode(ByamlTreeNode node)
        {
            if (node.ByamlNode.NodeType == ByamlNodeType.Array)
            {
                var array = (List<ByamlEntry>)node.ByamlNode.Value;

                for (int i = 0; i < array.Count; i++)
                    if (!ByamlParser.NodeIsValue(array[i].NodeType))
                    {
                        var child = new ByamlTreeNode(array[i], i.ToString());
                        node.Nodes.Add(child);
                        MakeTreenode(child);
                    }
            }
            else if (node.ByamlNode.NodeType == ByamlNodeType.Dictionary)
            {
                var dict = (Dictionary<string, ByamlEntry>)node.ByamlNode.Value;

                foreach (var item in dict)
                    if (!ByamlParser.NodeIsValue(item.Value.NodeType))
                    {
                        var child = new ByamlTreeNode(item.Value, item.Key);
                        node.Nodes.Add(child);
                        MakeTreenode(child);
                    }
            }
        }
    }

}
