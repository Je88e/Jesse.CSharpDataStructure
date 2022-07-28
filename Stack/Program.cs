// See https://aka.ms/new-console-template for more information
using Stack;

Console.WriteLine("Hello, World!");

//数组实现的栈测试
//Stack.ArrayStackTest.DoTest();

//链表实现的栈测试
//Stack.LinkedListStackTest.DoTest();

//进制转换测试
Console.WriteLine(DecConvert(new ArrayStack<char>(),6,2));


Console.WriteLine(DecConvert(new LinkedListStack<char>(),7,2));


string DecConvert(IStack<char> stack, int num, int dec)
{
    if (dec < 2 || dec > 16)
    {
        throw new ArgumentOutOfRangeException("dec", "只支持将十进制数转换为二进制到十六进制数");
    }

    int residue;
    // 余数入栈
    while (num != 0)
    {
        residue = num % dec;
        if (residue >= 10)
        {
            // 如果是转换为16进制且余数大于10则需要转换为ABCDEF
            residue = residue + 55;
        }
        else
        {
            // 转换为ASCII码中的数字型字符1~9
            residue = residue + 48;
        }
        stack.Push((char)residue);
        num = num / dec;
    }
    // 反序出栈
    string result = string.Empty;
    while (stack.Count > 0)
    {
        result += stack.Pop();
    }

    return result;
}