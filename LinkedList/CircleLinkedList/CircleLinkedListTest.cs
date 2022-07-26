using System.Text;

namespace LinkedList.CircleLinkedList
{
    public static class CircleLinkedListTest
    {
        public static void DoTest()
        {
            CircleLinkedList<int> list = new CircleLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < 11; i++)
            {
                list.MoveNext();
            }
            for (int i = 0; i < 10; i++)
            {
                list.Remove();
            }
        }

        /// <summary>
        /// 约瑟夫环
        /// </summary>
        /// <param name="count"></param>
        /// <param name="step"></param>
        public static void JosephusTest(int count, int step)
        {
            CircleLinkedList<int> list = new CircleLinkedList<int>();
             Action<CircleLinkedList<int>> Reader = (list) => {
                StringBuilder stringBuilder = new StringBuilder();
                CNode<int> tempNode = list.First;
                for (int i = 0; i < list.Count; i++)
                { 
                    stringBuilder.Append(tempNode.Item + "  ");
                    tempNode = tempNode.Next;
                }
                Console.WriteLine(stringBuilder.ToString());
                stringBuilder.Clear();
             };
             for (int i = 1; i <= count; i++)
             {
                list.Add(i);
             }
             while(list.Count > 0){
                for (int i = 1; i < step; i++)
                {
                    list.MoveNext();
                }
                Console.WriteLine("Remove:" + list.Current.Item);
                list.Remove();
                Reader(list);
             }
        }


    }
}