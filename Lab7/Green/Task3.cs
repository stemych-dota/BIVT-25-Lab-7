using System.Collections;

namespace Lab7.Green
{
    public class Task3
    {
        public struct Student
        {
            private string _name;
            private string _surname;

            // 3 оценки
            private int[] _marks;

            // отчислен или нет
            private bool _isExpelled;

            public Student(string name, string surname)
            {
                _name = name == null ? "" : name;
                _surname = surname == null ? "" : surname;

                _marks = new int[3];
                _isExpelled = false;
            }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public int[] Marks
            {
                get
                {
                    // Копия массива что бы не поменяли снаружи
                    int[] copy = new int[_marks.Length];
                    for (int i = 0; i < _marks.Length; i++)
                        copy[i] = _marks[i];
                    return copy;
                }
            }

            public bool IsExpelled { get { return _isExpelled; } }

            public double AverageMark
            {
                get
                {
                    // Среднее по оценкам которые не 0
                    int sum = 0;
                    int count = 0;

                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] > 0)
                        {
                            sum += _marks[i];
                            count++;
                        }
                    }

                    if (count == 0) return 0;
                    return (double)sum / count;
                }
            }

            public void Exam(int mark)
            {
                // Если отчислен то ничего не сдаёт
                if (_isExpelled)
                    return;

                // Если оценка 2 то отчисление
                if (mark == 2)
                {
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        if (_marks[i] == 0)
                        {
                            _marks[i] = mark;
                            break;
                        }
                    }

                    _isExpelled = true;
                    return;
                }

                // Оценка не 2 — записываю 0 в первый свободный
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
                Console.WriteLine($"{Name} {Surname} {AverageMark} {IsExpelled}");
            }
        }
    }
}
