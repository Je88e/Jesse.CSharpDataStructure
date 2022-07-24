namespace LinkedList;
public class Node<T>
{
    public T item { get; set; }
    public Node<T> Next { get; set; }
    public Node()
    {

    }
    public Node(T item)
    {
        this.item = item;
    }

}
public class SingleLinkedList<T>
{
    private int count { get; set; }
    private Node<T> head { get; set; }

    public SingleLinkedList()
    {
        this.count = 0;
        this.head = null;
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    //indexer
    public T this[int index]
    {
        get
        {
            return this.GetNodeByIndex(index).item;
        }
        set
        {
            this.GetNodeByIndex(index).item = value;
        }
    }

    /// <summary>
    /// 根据索引获取元素
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private Node<T> GetNodeByIndex(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException("index", "索引超出范围");
        }

        Node<T> tempNode = this.head;
        for (int i = 0; i < index; i++)
        {
            tempNode = tempNode.Next;
        }

        return tempNode;
    }

    /// <summary>
    /// 添加元素
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            this.head = newNode;
        }
        else
        {
            Node<T> trailNode = this.GetNodeByIndex(this.count - 1);
            trailNode.Next = newNode;
        }
        count++;
    }

    /// <summary>
    /// 指定位置插入元素
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void Insert(int index, T value)
    {
        if (index < 0 || index > this.count)
        {
            throw new ArgumentOutOfRangeException("index", "索引超出范围");
        }
        else if (index == 0)
        {
            if (head == null)
            {
                Node<T> newNode = new Node<T>(value);
                this.head = newNode;
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
                newNode.Next = this.head;
                this.head = newNode;
            }
        }
        else
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> prevNode = this.GetNodeByIndex(index - 1);
            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
        }
        count++;
    }

    /// <summary>
    /// 删除指定索引值的元素
    /// </summary>
    /// <param name="index"></param>
    public void Remove(int index)
    {
        if (index == 0)
        {
            this.head = this.head.Next;
        }
        else
        {
            Node<T> prevNode = this.GetNodeByIndex(index - 1);
            if (prevNode == null)
            {
                throw new ArgumentOutOfRangeException("index", "索引超界");
            }
            Node<T> removeNode = prevNode.Next;
            prevNode.Next = removeNode.Next;

            removeNode = null;
        }
        count--;
    }
}
