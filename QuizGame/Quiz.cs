//By Takplintus
using static System.Console;

namespace QuizGame;

public class Quiz
{
    private static int _input;
    private static int _quest;
    private static int _counter;
    private static int _size;
    private static int _difficult;

    public static void Begin()
    {
        //Генерация массива случайных вопросов
        _size = Answers.Qsize;
        var nums = Enumerable.Range(0, _size).ToList();
        int[] result = new int[_size];
        Random rand = new Random();
        for (int i = 0; i < _size; i++)
        {
            int pos = rand.Next(0, nums.Count);
            result[i] = nums[pos];
            nums.RemoveAt(pos);
        }
        
        Write(@$"Добро пожаловать в QUIZ!
 _______          _________ _______ 
(  ___  )|\     /|\__   __// ___   )
| (   ) || )   ( |   ) (   \/   )  |
| |   | || |   | |   | |       /   )
| |   | || |   | |   | |      /   / 
| | /\| || |   | |   | |     /   /  
| (_\ \ || (___) |___) (___ /   (_/\
(____\/_)(_______)\_______/(_______/
Нажмите Enter для продолжения");
        ReadKey();
        WriteLine("\n");
        
        //Выбор уровня сложности
        _difficult = _size;
        
        WriteLine($@"Выберите уровень сложности:
1. Легкий ({_difficult/5} вопросов)
2. Нормальный ({_difficult/2} вопросов)
3. Сложный ({_difficult}) вопросов");
        
        Write("> ");
        _input = Convert.ToInt32(ReadLine());
        switch (_input)
        {
            case 1:
                _difficult /= 5;
                break;
            case 2:
                _difficult /= 2;
                break;
        }
        
        //Начало опроса
        Clear();
        for (int i = 0; i < _difficult; i++)
        {
            _quest = result[i];
            Print();
            Read();
            Check();
        }

        //Подведение итогов
        if (_counter >= _difficult / 2)
        {
            WriteLine("Вы прошли игру!");
        }
        else
        {
            WriteLine("Вы проиграли!");
        }
        WriteLine($"Верные ответы: {_counter}/{_difficult}");
        ReadKey();
    }
    
    public static void Print()
    {
        WriteLine(Questions.quests[_quest, 0]);
        for (int i = 1; i < 4; i++)
        {
            WriteLine($"{i}. {Questions.quests[_quest, i]}");
        }
    }

    public static void Read()
    {
        Write("> ");
        _input = Convert.ToInt32(ReadLine());
    }

    public static void Check()
    {
        if (Questions.quests[_quest, _input] == Answers.CorrectlyAnswers[_quest])
        {
            ++_counter;
            Write("Ответ верный!");
        }
        else
        {
            Write("Ответ неверный!");
        }

        Questions.quests[_quest, 0] = "";
        WriteLine($"    (Количество верных ответов: {_counter})\n");
        ReadKey();
    }
}