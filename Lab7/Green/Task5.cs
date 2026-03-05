namespace Lab7.Green
{
    public class Task5
    {
        public struct Student
        {
            private string _name;
            private string _surname;

            // 5 оценок
            private int[] _marks;

            public Student(string name, string surname)
            {
                _name = name == null ? "" : name;
                _surname = surname == null ? "" : surname;

                _marks = new int[5];
            }

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }

            public int[] Marks
            {
                get
                {
                    // Копия массива что бы не могли изменить
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
                    // Если всё 0, то средняя 0
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

                    int sum = 0;
                    for (int i = 0; i < _marks.Length; i++)
                        sum += _marks[i];

                    return (double)sum / _marks.Length;
                }
            }

            public void Exam(int mark)
            {
                // Пишу оценку в первый предмет, который ещё не сдавали
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
                        return;
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AverageMark}");
            }
        }

        public struct Group
        {
            private string _name;

            // список студентов группы
            private Student[] _students;

            public Group(string name)
            {
                _name = name == null ? "" : name;

                // сначала группа создаётся пустой
                _students = new Student[0];
            }

            public string Name { get { return _name; } }

            public Student[] Students
            {
                get
                {
                    // Опять копия массива
                    Student[] copy = new Student[_students.Length];
                    for (int i = 0; i < _students.Length; i++)
                        copy[i] = _students[i];
                    return copy;
                }
            }

            public double AverageMark
            {
                get
                {
                    if (_students.Length == 0) return 0;

                    double sum = 0;
                    for (int i = 0; i < _students.Length; i++)
                        sum += _students[i].AverageMark;

                    return sum / _students.Length;
                }
            }

            public void Add(Student elem)
            {
                // Увеличиваю массив на 1 и добавляю студента в конец
                Student[] newArr = new Student[_students.Length + 1];

                for (int i = 0; i < _students.Length; i++)
                    newArr[i] = _students[i];

                newArr[newArr.Length - 1] = elem;

                _students = newArr;
            }

            public void Add(Student[] array)
            {
                if (array == null) return;

                // Добавляю сразу пачкой студентов
                Student[] newArr = new Student[_students.Length + array.Length];

                for (int i = 0; i < _students.Length; i++)
                    newArr[i] = _students[i];

                for (int j = 0; j < array.Length; j++)
                    newArr[_students.Length + j] = array[j];

                _students = newArr;
            }

            public static void SortByAverageMark(Group[] array)
            {
                // Сортировка групп по сред баллу
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AverageMark < array[j + 1].AverageMark)
                        {
                            Group temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {AverageMark}");
            }
        }
    }
}
