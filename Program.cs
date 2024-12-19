using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите задание:");
                Console.WriteLine("1. Стек на основе массива");
                Console.WriteLine("2. Очередь на основе связного списка");
                Console.WriteLine("3. Проверка палиндрома с использованием стека");
                Console.WriteLine("4. Обратная польская нотация");
                Console.WriteLine("5. Переворот массива с использованием стека");
                Console.WriteLine("6. Двусторонняя очередь");
                Console.WriteLine("7. Очередь с ограниченным размером");
                Console.WriteLine("8. Сортировка стека");
                Console.WriteLine("9. Стек с минимальным элементом");
                Console.WriteLine("10. Проверка правильности скобок");
                Console.WriteLine("11. Удалить дубликаты символов");
                Console.WriteLine("12. Очередь ожидания (печать документов)");
                Console.WriteLine("13. Стек с операциями сложения и вычитания");
                Console.WriteLine("0. Выход");
                Console.Write("Введите номер задания: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Ошибка! Пожалуйста, введите число.");
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        StackArrayDemo();
                        break;
                    case 2:
                        QueueLinkedListDemo();
                        break;
                    case 3:
                        PalindromeCheck();
                        break;
                    case 4:
                        ReversePolishNotation();
                        break;
                    case 5:
                        ReverseArrayUsingStack();
                        break;
                    case 6:
                        DequeDemo();
                        break;
                    case 7:
                        CircularQueueDemo();
                        break;
                    case 8:
                        StackSortDemo();
                        break;
                    case 9:
                        MinStackDemo();
                        break;
                    case 10:
                        BracketBalanceCheck();
                        break;
                    case 11:
                        RemoveDuplicateCharacters();
                        break;
                    case 12: 
                        PrintQueueDemo();
                        break;
                    case 13:
                        ArithmeticStackDemo();
                        break;


                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Попробуйте снова.");
                        break;
                }
            }
        }
        class StackArray
        {
            private int[] arr;
            private int top;
            private int size;

            public StackArray(int size)
            {
                this.size = size;
                arr = new int[size];
                top = -1;
            }

            public void Push(int value)
            {

                if (top == size - 1)
                    Console.WriteLine("Стек переполнен!");
                else
                    arr[++top] = value;
            }

            public void Pop()
            {
                if (top == -1)
                    Console.WriteLine("Стек пуст!");
                else
                    top--;
            }

            public int Peek()
            {
                if (top == -1)
                    throw new InvalidOperationException("Стек пуст!");
                return arr[top];
            }
        }
        static void StackArrayDemo()
        {
            Console.Write("Введите размер стека: ");
            int size = Convert.ToInt32(Console.ReadLine());
            StackArray stack = new StackArray(size);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Посмотреть верхний элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    stack.Push(value);
                }
                else if (action == 2)
                {
                    stack.Pop();
                }
                else if (action == 3)
                {
                    try
                    {
                        Console.WriteLine($"Верхний элемент: {stack.Peek()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Стек пуст!");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        class Node
        {
            public int Value;
            public Node Next;
        }

        class QueueLinkedList
        {
            private Node head;
            private Node tail;

            public void Enqueue(int value)
            {
                Node newNode = new Node { Value = value };
                if (tail != null)
                    tail.Next = newNode;
                tail = newNode;

                if (head == null)
                    head = newNode;
            }

            public void Dequeue()
            {
                if (head == null)
                    Console.WriteLine("Очередь пуста!");
                else
                    head = head.Next;
            }

            public int Peek()
            {
                if (head == null)
                    throw new InvalidOperationException("Очередь пуста!");
                return head.Value;
            }
        }
        static void QueueLinkedListDemo()
        {
            QueueLinkedList queue = new QueueLinkedList();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Посмотреть первый элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    queue.Enqueue(value);
                }
                else if (action == 2)
                {
                    queue.Dequeue();
                }
                else if (action == 3)
                {
                    try
                    {
                        Console.WriteLine($"Первый элемент: {queue.Peek()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Очередь пуста!");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        static void PalindromeCheck()
        {
            Console.Write("Введите строку для проверки на палиндром: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            bool isPalindrome = true;
            foreach (char c in input)
            {
                if (stack.Pop() != c)
                {
                    isPalindrome = false;
                    break;
                }
            }

            Console.WriteLine(isPalindrome ? "Строка является палиндромом" : "Строка не является палиндромом");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        public static double Evaluate(string expression)
        {
            Stack<double> stack = new Stack<double>();

            string[] tokens = expression.Split(' ');

            Console.WriteLine("Шаги вычисления:");

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double number)) 
                {
                    stack.Push(number); 
                    Console.WriteLine($"Число {token} добавлено в стек.");
                }
                else 
                {
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    double result = 0;

                    switch (token)
                    {
                        case "+":
                            result = operand1 + operand2;
                            break;
                        case "-":
                            result = operand1 - operand2;
                            break;
                        case "*":
                            result = operand1 * operand2;
                            break;
                        case "/":
                            if (operand2 != 0)
                                result = operand1 / operand2;
                            else
                                throw new InvalidOperationException("Ошибка: деление на ноль!");
                            break;
                        default:
                            throw new InvalidOperationException("Неизвестный оператор: " + token);
                    }

                    stack.Push(result); 
                    Console.WriteLine($"Выполняем операцию: {operand1} {token} {operand2} = {result}");
                }
            }

            if (stack.Count != 1)
                throw new InvalidOperationException("Ошибка: неверное количество операндов или операторов.");

            return stack.Pop();
        }

        static void ReversePolishNotation()
        {
            Console.WriteLine("Введите выражение в обратной польской нотации (например, '5 3 + 8 2 - *'):");
            string expression = Console.ReadLine();

            try
            {
                double result = Evaluate(expression);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        static void ReverseArrayUsingStack()
        {
            Console.Write("Введите массив чисел через пробел: ");
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            Console.WriteLine("Перевернутый массив:");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        class Deque
        {
            private List<int> deque = new List<int>();
            public void AddFront(int value)
            {
                deque.Insert(0, value);
            }

            public void AddRear(int value)
            {
                deque.Add(value);
            }

            public void RemoveFront()
            {
                if (deque.Count > 0)
                    deque.RemoveAt(0);
                else
                    Console.WriteLine("Очередь пуста!");
            }

            public void RemoveRear()
            {
                if (deque.Count > 0)
                    deque.RemoveAt(deque.Count - 1);
                else
                    Console.WriteLine("Очередь пуста!");
            }

            public int PeekFront()
            {
                if (deque.Count > 0)
                    return deque[0];
                else
                    throw new InvalidOperationException("Очередь пуста!");
            }

            public int PeekRear()
            {
                if (deque.Count > 0)
                    return deque[deque.Count - 1];
                else
                    throw new InvalidOperationException("Очередь пуста!");
            }
        }
        static void DequeDemo()
        {
            Deque deque = new Deque();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент в начало");
                Console.WriteLine("2. Добавить элемент в конец");
                Console.WriteLine("3. Удалить элемент с начала");
                Console.WriteLine("4. Удалить элемент с конца");
                Console.WriteLine("5. Посмотреть первый элемент");
                Console.WriteLine("6. Посмотреть последний элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    deque.AddFront(value);
                }
                else if (action == 2)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    deque.AddRear(value);
                }
                else if (action == 3)
                {
                    deque.RemoveFront();
                }
                else if (action == 4)
                {
                    deque.RemoveRear();
                }
                else if (action == 5)
                {
                    try
                    {
                        Console.WriteLine($"Первый элемент: {deque.PeekFront()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Очередь пуста!");
                    }
                }
                else if (action == 6)
                {
                    try
                    {
                        Console.WriteLine($"Последний элемент: {deque.PeekRear()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Очередь пуста!");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        class CircularQueue
        {
            private int[] queue;
            private int front;
            private int rear;
            private int size;

            public CircularQueue(int capacity)
            {
                queue = new int[capacity];
                front = -1;
                rear = -1;
                size = capacity;
            }

            public void Enqueue(int value)
            {
                if ((rear + 1) % size == front)
                {
                    Console.WriteLine("Очередь переполнена!");
                }
                else
                {
                    if (front == -1)
                        front = 0;

                    rear = (rear + 1) % size;
                    queue[rear] = value;
                }
            }

            public void Dequeue()
            {
                if (front == -1)
                    Console.WriteLine("Очередь пуста!");
                else
                {
                    front = (front + 1) % size;
                    if (front == (rear + 1) % size)
                    {
                        front = rear = -1;
                    }
                }
            }
            public int Peek()
            {
                if (front == -1)
                    throw new InvalidOperationException("Очередь пуста!");
                return queue[front];
            }
        }

        static void CircularQueueDemo()
        {
            Console.Write("Введите размер кольцевой очереди: ");
            int size = Convert.ToInt32(Console.ReadLine());
            CircularQueue queue = new CircularQueue(size);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Посмотреть первый элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    queue.Enqueue(value);
                }
                else if (action == 2)
                {
                    queue.Dequeue();
                }
                else if (action == 3)
                {
                    try
                    {
                        Console.WriteLine($"Первый элемент: {queue.Peek()}");
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Очередь пуста!");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        static void StackSortDemo()
        {
            Stack<int> stack = new Stack<int>();
            Console.WriteLine("Введите элементы стека (через пробел):");
            string[] elements = Console.ReadLine().Split();

            foreach (var element in elements)
            {
                stack.Push(int.Parse(element));
            }

            Stack<int> sortedStack = new Stack<int>();

            while (stack.Count > 0)
            {
                int temp = stack.Pop();
                while (sortedStack.Count > 0 && sortedStack.Peek() > temp)
                {
                    stack.Push(sortedStack.Pop());
                }
                sortedStack.Push(temp);
            }

            Console.WriteLine("Отсортированный стек:");
            while (sortedStack.Count > 0)
            {
                Console.Write(sortedStack.Pop() + " ");
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        class MinStack
        {
            private Stack<int> stack;
            private Stack<int> minStack;

            public MinStack()
            {
                stack = new Stack<int>();
                minStack = new Stack<int>();
            }

            public void Push(int value)
            {
                stack.Push(value);
                if (minStack.Count == 0 || value <= minStack.Peek())
                    minStack.Push(value);
            }

            public void Pop()
            {
                if (stack.Count == 0) return;

                int poppedValue = stack.Pop();
                if (poppedValue == minStack.Peek())
                    minStack.Pop();
            }

            public int Peek()
            {
                return stack.Peek();
            }

            public int GetMin()
            {
                if (minStack.Count == 0)
                    throw new InvalidOperationException("Стек пуст!");
                return minStack.Peek();
            }
        }
        static void MinStackDemo()
        {
            MinStack stack = new MinStack();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Посмотреть верхний элемент");
                Console.WriteLine("4. Получить минимальный элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    stack.Push(value);
                }
                else if (action == 2)
                {
                    stack.Pop();
                }
                else if (action == 3)
                {
                    Console.WriteLine($"Верхний элемент: {stack.Peek()}");
                }
                else if (action == 4)
                {
                    Console.WriteLine($"Минимальный элемент: {stack.GetMin()}");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        static void BracketBalanceCheck()
        {
            Console.Write("Введите строку для проверки скобок: ");
            string expression = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in expression)
            {
                if (c == '(' || c == '[' || c == '{')
                    stack.Push(c);
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) // Нет открывающей скобки
                    {
                        isValid = false;
                        break;
                    }

                    char top = stack.Pop();
                    if (!((top == '(' && c == ')') || (top == '[' && c == ']') || (top == '{' && c == '}')))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (stack.Count > 0) // Если в стеке остались открывающие скобки
                isValid = false;

            Console.WriteLine(isValid ? "Скобки расставлены правильно." : "Скобки расставлены неправильно.");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        static void RemoveDuplicateCharacters()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            HashSet<char> seen = new HashSet<char>();
            StringBuilder result = new StringBuilder();

            foreach (char c in input)
            {
                if (!seen.Contains(c))
                {
                    seen.Add(c);
                    stack.Push(c);  // Добавляем в стек только уникальные символы
                }
            }

            // Извлекаем элементы из стека, так как они будут в обратном порядке
            while (stack.Count > 0)
            {
                result.Insert(0, stack.Pop());  // Формируем строку
            }

            Console.WriteLine("Результат: " + result.ToString());
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
        class PrintQueue
        {
            private Queue<string> queue = new Queue<string>();

            public void AddDocument(string document)
            {
                queue.Enqueue(document);
                Console.WriteLine($"Документ '{document}' добавлен в очередь.");
            }

            public void PrintNextDocument()
            {
                if (queue.Count > 0)
                {
                    string document = queue.Dequeue();
                    Console.WriteLine($"Документ '{document}' распечатан.");
                }
                else
                {
                    Console.WriteLine("Очередь пуста. Нет документов для печати.");
                }
            }

            public void ViewQueue()
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine("Очередь на печать:");
                    foreach (var document in queue)
                    {
                        Console.WriteLine(document);
                    }
                }
                else
                {
                    Console.WriteLine("Очередь пуста.");
                }
            }
        }

        static void PrintQueueDemo()
        {
            PrintQueue printQueue = new PrintQueue();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить документ в очередь");
                Console.WriteLine("2. Распечатать следующий документ");
                Console.WriteLine("3. Просмотреть очередь");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите имя документа: ");
                    string document = Console.ReadLine();
                    printQueue.AddDocument(document);
                }
                else if (action == 2)
                {
                    printQueue.PrintNextDocument();
                }
                else if (action == 3)
                {
                    printQueue.ViewQueue();
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
        class ArithmeticStack
        {
            private Stack<int> stack = new Stack<int>();

            public void Push(int value)
            {
                stack.Push(value);
            }

            public void Add()
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Недостаточно элементов для сложения.");
                    return;
                }

                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(a + b);
            }

            public void Subtract()
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Недостаточно элементов для вычитания.");
                    return;
                }

                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(a - b);
            }

            public int Peek()
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("Стек пуст!");
                    return 0;
                }

                return stack.Peek();
            }
        }

        static void ArithmeticStackDemo()
        {
            ArithmeticStack stack = new ArithmeticStack();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Сложить два элемента");
                Console.WriteLine("3. Вычесть два элемента");
                Console.WriteLine("4. Посмотреть верхний элемент");
                Console.WriteLine("0. Назад");
                Console.Write("Выберите действие: ");
                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 0) break;
                else if (action == 1)
                {
                    Console.Write("Введите элемент: ");
                    int value = Convert.ToInt32(Console.ReadLine());
                    stack.Push(value);
                }
                else if (action == 2)
                {
                    stack.Add();
                }
                else if (action == 3)
                {
                    stack.Subtract();
                }
                else if (action == 4)
                {
                    Console.WriteLine($"Верхний элемент: {stack.Peek()}");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}

