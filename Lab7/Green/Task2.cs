using System.Collections;

namespace Lab7.Green
{
    public class Task2
    {
        public struct Student
        {
            // Данные студента
            private string _name;
            private string _surname;

            // 4 оценки (сначала 0, типа ещё не сдавал)
            private int[] _marks;

            public Student(string name, string surname)
            {
                // Если null возвращаю пустую строку
                _name = name == null ? "" : name;
                _surname = surname == null ? "" : surname;

                // По условию 4 предмета
                _marks = new int[4];
            }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public int[] Marks
            {
                get
                {
                    // Отдаю копию массива, что бы нельзя было поменять снаружи
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < _marks.Length; i++)
                        copy[i] = _marks[i];
                    return copy;
                }
            }

            public double AverageMark
            {
                get
                {
                    // Если ещё ничего не сдавал, то средний равен нулю
                    bool allZero = true;
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] != 0)
                        {
                            allZero = false;
                            break;
                        }
                    }
                    if (allZero) return 0;

                    // Среднее по всем четырём
                    int sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                        sum += _marks[i];

                    return (double)sum / _marks.Length;
                }
            }

            public bool IsExcellent
            {
                get
                {
                    // Если есть 0 значит что-то не сдано, отличником не считаем
                    for (int i = 0; i < _marks.Length; i++)
                        if (_marks[i] == 0) return false;

                    // Отличник, если все оценки >= 4
                    for (int i = 0; i < _marks.Length; i++)
                        if (_marks[i] < 4) return false;

                    return true;
                }
            }

            public void Exam(int mark)
            {
                // Предмет можно сдать только 1 раз, поэтому ищу первый 0
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }

            public static void SortByAverageMark(Student[] array)
            {
                // Сортировка пузырьком
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AverageMark} {IsExcellent}");
            }
        }
    }
}
