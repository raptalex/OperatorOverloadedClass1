using System;

class aMatrix<T> where T : IComparable<T>
{
    protected T[] data;
    public aMatrix(params T[] vals)
    {
        data = new T[vals.Length];

        for (uint i = 0; i < vals.Length; i++)
            data[i] = vals[i];
    }
    public T this[int i]
    {
        get { return data[i]; }
        set { data[i] = value; }
    }
    public override string ToString()
    {
        string temp = "[";

        for (uint i = 0; i < data.Length; i++)
        {
            if (i < data.Length - 1)
                temp += data[i].ToString() + ", ";
            else
                temp += data[i].ToString();
        }

        temp += "]";
        return temp;
    }
    // Create a unary overloaded operator (+, -, !, ~, ++, – –)
    public static aMatrix<T> operator -(aMatrix<T> obj)
    {
        for (uint i = 0; i < obj.data.Length; i++)
        {
            dynamic temp = obj.data[i];
            obj.data[i] = -temp;
        }

        return obj;
    }
    public static aMatrix<T> operator +(aMatrix<T> obj)
    {
        for (uint i = 0; i < obj.data.Length; i++)
        {
            dynamic temp = obj.data[i];
            obj.data[i] = +temp;
        }

        return obj;
    }
    public static aMatrix<T> operator ++(aMatrix<T> obj)
    {
        for (uint i = 0; i < obj.data.Length; i++)
        {
            dynamic temp = obj.data[i];
            obj.data[i] = ++temp;
        }

        return obj;
    }
    public static aMatrix<T> operator --(aMatrix<T> obj)
    {
        for (uint i = 0; i < obj.data.Length; i++)
        {
            dynamic temp = obj.data[i];
            obj.data[i] = --temp;
        }

        return obj;
    }
    // Create a binary overloaded operator (+, -, *, /, %)
    public static aMatrix<T> operator +(aMatrix<T> obj1, T val)
    {
        dynamic temp = val;
        for (uint i = 0; i < obj1.data.Length; i++)
            obj1.data[i] += temp;

        return obj1;
    }
    public static aMatrix<T> operator -(aMatrix<T> obj1, T val)
    {
        dynamic temp = val;
        for (uint i = 0; i < obj1.data.Length; i++)
            obj1.data[i] -= temp;

        return obj1;
    }
    public static aMatrix<T> operator +(aMatrix<T> obj1, aMatrix<T> obj2)
    {
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            obj1.data[i] += temp;
        }

        return obj1;
    }
    public static aMatrix<T> operator -(aMatrix<T> obj1, aMatrix<T> obj2)
    {
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            obj1.data[i] -= temp;
        }

        return obj1;
    }
    // Create a comparison overloaded operator (==, !=, =, >, <) 
    public static bool operator ==(aMatrix<T> obj1, aMatrix<T> obj2) {
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            if (obj1.data[i] != temp)
                return false;
        }
        return true;
    }
    public static bool operator !=(aMatrix<T> obj1, aMatrix<T> obj2)
    {
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            if (obj1.data[i] != temp)
                return true;
        }
        return false;
    }
    public static bool operator >(aMatrix<T> obj1, aMatrix<T> obj2)
    {
        uint greater = 0;
        uint notgreater = 0;
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            if (obj1.data[i] > temp)
                greater++;
            else
                notgreater++;
        }
        return greater > notgreater;
    }
    public static bool operator <(aMatrix<T> obj1, aMatrix<T> obj2)
    {
        uint greater = 0;
        uint notgreater = 0;
        for (uint i = 0; i < obj1.data.Length; i++)
        {
            dynamic temp = obj2.data[i];
            if (obj1.data[i] > temp)
                greater++;
            else
                notgreater++;
        }
        return greater < notgreater;
    }
}
class Program
{
    public static void Main()
    {
        aMatrix<double> matrix1 = new aMatrix<double>(8, 3, 1, 2, 3, 5);
        aMatrix<double> matrix2 = new aMatrix<double>(9, 22, 84, 37, 66, 152);

        Console.WriteLine(matrix1.ToString());

        matrix1++;
        Console.WriteLine(matrix1.ToString());

        matrix1 += new aMatrix<double>(0, 18, 82, 34, 62, 146);
        Console.WriteLine(matrix1.ToString());

        Console.WriteLine("Is {0} equal to {1}? {2}", matrix1.ToString(), matrix2.ToString(), matrix1 == matrix2 ? "Yes." : "No.");

        matrix2--;
        matrix2 -= 3;
        Console.WriteLine("Is {0} not equal to {1}? {2}", matrix1.ToString(), matrix2.ToString(), matrix1 != matrix2 ? "Yes." : "No.");
    }
}