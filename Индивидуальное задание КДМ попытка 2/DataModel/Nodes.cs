using System.Collections.Generic;

namespace Индивидуальное_задание_КДМ_попытка_2.DataModel
{
    public static class Nodes
    {
        public static SortedList<string, Node> NodesList = new SortedList<string, Node>(capacity: 20);

        public static int Count => NodesList.Count;

        public static void Clear()
        {
            NodesList.Clear();
        }


        public static void Add(string key, Node value)
        {
            NodesList.Add(key: key, value: value);
        }

        public static bool TryConnect(string first, string second)
        {
//строки можно сравнивать ==, это перегруженный оператор
            var currNode = NodesList[key: first];
            return currNode != null && currNode.TryConnectWith(value: NodesList[key: second]);
        }

        public static bool TryDisconnect(string first, string second)
        {
//строки можно сравнивать ==, это перегруженный оператор
            var currNode = NodesList[key: first];
            return currNode != null && currNode.TryDisconnectWith(value: NodesList[key: second]);
        }

        public static void Remove(string key)
        {
            var index = NodesList.IndexOfKey(key: key);
            NodesList.Remove(key: key);
            ReindexingAfterRemove(indexFrom: index);
            foreach (var nodesListKey in NodesList.Keys)
            {
                NodesList[key: nodesListKey].AdjoiningNodes.Remove(key: key);
            }
        }

        private static void ReindexingAfterRemove(int indexFrom)
        {
            //начиная с этого индекса(или строки?) "уменьшаю" на единицу ключи.
            if (indexFrom >= NodesList.Count)
                return;

            var a = NodesList.Keys;
            var firstNumber = int.Parse(s: a[index: indexFrom]); //это я просто пропарсил ключ.
            var number = firstNumber;

            for (var i = indexFrom; i < a.Count; i++)
            {
                NodesList[key: a[index: i]].Key = (number - 1).ToString();

                var deletedItem = NodesList[key: a[index: i]];
                NodesList.Remove(key: a[index: i]);
                NodesList.Add(key: deletedItem.Key, value: deletedItem);

                number++;
            }
        }
    }
}