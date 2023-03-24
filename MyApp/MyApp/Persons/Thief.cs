namespace MyApp;

//персонаж Вор
public class Thief : Person
{
    //конструктор для создания по умолчанию Вора
    public Thief()
    {
        //присваивается навык Украсть вещь
        Skill = Skills.Steal;
        //по умолчанию задаем количество жизней
        Live = 4;
        //по умолчанию задаем количество очков здоровья
        Health = 4;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 1;
        //пустой список бонусных вещей
        BonusThings = new List<BonusThing>() { };
    }
    
    //конструктор для создания Вора с бонусной вещью
    public Thief(BonusThing bonusThing)
    {
        //присваивается навык Украсть вещь
        Skill = Skills.Steal;
        //по умолчанию задаем количество жизней
        Live = 4;
        //по умолчанию задаем количество очков здоровья
        Health = 4;
        //по умолчанию задаем количество очков атаки
        AttackPoints = 1;
        //добавляем бронусную вещь
        BonusThings = new List<BonusThing>() { bonusThing };
    }

    //украсть случайную вещь у соперника
    public void StealThing(Person person)
    {
        //проверяем, есть ли у соперника какие-то бонусные вещи. 
        //если нет - прекращаем выполнение метода
        if (person.BonusThings.Count == 0)
        {
            return;
        }
        //получаем случайное число в диапазоне от 1 до количества вещей
        //в списке соперника
        var rnd = new Random();
        var index = rnd.Next(1, person.BonusThings.Count);
        
        //находим вещь с таким индексом
        var thing = person.BonusThings[index];
        
        //удаляем эту вещь из списка соперника и добавляем в свой список
        person.BonusThings.Remove(thing);
        this.BonusThings.Add(thing);
    }

    //метод, который осуществляет ход персонажа
    public void MakeMove(MoveType moveType, Person person)
    {
        switch (moveType)
        {
            case MoveType.Attack:
            {
                //посчитаем наши очки атаки
                var attackPoints = this.AttackPoints;
                //выберем все вещи с бонусом на атаку
                var bonusThings = this.BonusThings.Where(x => x.Property == Property.Attack);
                foreach (var bs in BonusThings)
                {
                    //добавим их бонус к нашим очкам атаки
                    attackPoints += bs.Point;

                }
                //атакуем противника, снимая из очков его здоровья 
                if (person.Health >= attackPoints)
                {
                    person.Health -= attackPoints;
                }
                //если очков здоровья не хватает - отнимаем одну жизнь
                person.Live--;
                break;
            }
            case MoveType.Skill:
            {
                //применяем метод навыка
                StealThing(person);
                break;
            }
            case MoveType.Pass:
            {
                //пропускаем ход, ничего не делая
                break;
            }
        }
    } 
}