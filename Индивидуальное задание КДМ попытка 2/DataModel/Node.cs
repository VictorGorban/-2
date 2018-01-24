using System.Collections.Generic;

namespace Индивидуальное_задание_КДМ_попытка_2.DataModel
{
    public class Node
    {
        public string Key; //null по умолчанию
        public SortedList<string, Node> AdjoiningNodes = new SortedList<string, Node>(capacity: 11);

        public Node(string key) //будет как минимум not null
        {
            Key = key.Clone() as string;
        }

        public bool TryConnectWith(Node value)
        {
            if (AdjoiningNodes.ContainsValue(value: value)) return false;

            AdjoiningNodes.Add(key: value.Key, value: value);
            return true;
        }

        public bool TryDisconnectWith(Node value)
        {
            if (!AdjoiningNodes.ContainsValue(value: value)) return false;

            AdjoiningNodes.Remove(key: value.Key);
            return true;
        }
    }
}