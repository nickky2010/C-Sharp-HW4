# C-Sharp-HW4
ITStep(Gomel)-C# Home work 4

Если в квадратной матрице A сумма элементов столбцов, состоящих из положительных элементов, 
больше чем такая же сумма в квадратной матрице В, заменить все нулевые элементы матрицы В на 
значение суммы элементов диагоналей этой матрицы. 
В противном случае определить сумму элементов диагоналей матрицы А. 
При создании объектов класса матрицы-аргументы конструктора создавать с использованием синтаксиса инициализаторов. 
С клавиатуры не вводить. 

Для решения задачи создать класс Matrix, содержащий 

  	закрытое поле-массив для хранения данных, 

  	конструктор без параметров для создания единичной матрицы 3×3, 

  	конструктор с параметрами (параметр – матрица целых чисел),

  	метод  ToString(), возвращающий строковое представление  матрицы, 

  	индексатор для доступа к элементам поля-массива, 

  	метод GetLenth – аналог одноименного метода из Array,

  	закрытый (private) метод, возвращающий true, если столбец состоит из положительных элементов (параметр – номер столбца),

  	метод, возвращающий сумму элементов столбцов, состоящих из положительных элементов,

  	свойство, возвращающее сумму элементов диагоналей матрицы.
