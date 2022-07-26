internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //双链表测试
        //LinkedList.DoubleLinkedList.DoubleLinkedListTest.DoTest();

        //循环链表测试
        //LinkedList.CircleLinkedList.CircleLinkedListTest.DoTest();

        //循环链表约瑟夫问题
        LinkedList.CircleLinkedList.CircleLinkedListTest.JosephusTest(41,3);
    }
}